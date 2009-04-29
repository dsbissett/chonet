/*
 * My Ajax.NET
 *
 * Release 4
 *
 * See release history at the end of the file for changes.
 *
 * This code is intended to be simple enough so that anybody can
 * understand it and, therefore, feel good about including it in
 * their own projects and even modifying it.
 *
 * Originally written by Jason Diamond but donated to the Public
 * Domain which means anybody can use it for any reason. If you make
 * any modifications and want to contribute them to the "official"
 * release, please send them to <mailto:jason@diamond.name>.
 *
 * Contributors:
 *
 * Jason Diamond <http://jason.diamond.name/>
 * Rick Strahl <http://www.west-wind.com/>
 * Thomas F Kelly, Jr.
 * Chris Payne
 *
 */

using System;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;

namespace CHONET.Ajax
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodAttribute : Attribute
    {
    }

    [Flags]
    public enum Debug
    {
        None = 0,
        RequestText = 1,
        ResponseText = 2,
        Errors = 4,
        All = 7
    }

    public class Manager
    {
        public static string CallBackTarget
        {
            get { return HttpContext.Current.Request.Form["Ajax_CallBackTarget"]; }
        }

        public static bool IsCallBack
        {
            get { return CallBackTarget != null; }
        }

        public static void Register(Control control)
        {
            Register(control, control.GetType().FullName);
        }

        public static void Register(Control control, string prefix)
        {
            Register(control, prefix, Debug.None);
        }

        public static void Register(Control control, Debug debug)
        {
            Register(control, control.GetType().FullName, debug);
        }

        public static void Register(Control control, string prefix, Debug debug)
        {
            string pageScript =
                @"
<script>
function Ajax_GetXMLHttpRequest() {
 	var x = null;
	if (typeof XMLHttpRequest != ""undefined"") {
		x = new XMLHttpRequest();
	} else {
		try {
			x = new ActiveXObject(""Msxml2.XMLHTTP"");
		} catch (e) {
			try {
				x = new ActiveXObject(""Microsoft.XMLHTTP"");
			} catch (e) {
			}
		}
	}
	return x;
}

function Ajax_CallBack(target, args, clientCallBack, debugRequestText, debugResponseText, debugErrors) {
	var x = Ajax_GetXMLHttpRequest();
	var url = document.location.href.substring(0, document.location.href.length - document.location.hash.length);
	x.open(""POST"", url, clientCallBack ? true : false);
	x.setRequestHeader(""Content-Type"", ""application/x-www-form-urlencoded"");
	if (clientCallBack) {
		x.onreadystatechange = function() {
			if (x.readyState != 4) {
				return;
			}
			if (debugResponseText) {
				alert(x.responseText);
			}
			var result = eval(""("" + x.responseText + "")"");
			if (debugErrors && result.error) {
				alert(""error: "" + result.error);
			}
			clientCallBack(result);
		}
	}
	var encodedData = ""Ajax_CallBackTarget="" + target;
	if (args) {
		for (var i in args) {
			encodedData += ""&Ajax_CallBackArgument"" + i + ""="" + encodeURIComponent(args[i]);
		}
	}
	if (document.forms.length > 0) {
		var form = document.forms[0];
		for (var i = 0; i < form.length; ++i) {
			var element = form.elements[i];
			if (element.name) {
				var elementValue = null;
				if (element.nodeName == ""INPUT"") {
					var inputType = element.getAttribute(""TYPE"").toUpperCase();
					if (inputType == ""TEXT"" || inputType == ""PASSWORD"" || inputType == ""HIDDEN"") {
						elementValue = element.value;
					} else if (inputType == ""CHECKBOX"" || inputType == ""RADIO"") {
						if (element.checked) {
							elementValue = element.value;
						}
					}
				} else if (element.nodeName == ""SELECT"") {
					elementValue = element.value;
				}
				if (elementValue) {
					encodedData += ""&"" + element.name + ""="" + encodeURIComponent(elementValue);
				}
			}
		}
	}
	if (debugRequestText) {
		alert(encodedData);
	}
	x.send(encodedData);
	var result = null;
	if (!clientCallBack) {
		if (debugResponseText) {
			alert(x.responseText);
		}
		result = eval(""("" + x.responseText + "")"");
		if (debugErrors && result.error) {
			alert(""error: "" + result.error);
		}
	}
	delete x;
	return result;
}
</script>";
            control.Page.ClientScript.RegisterClientScriptBlock(Type.GetType("System.String"), typeof (Manager).FullName,
                                                                pageScript);
            Type type = control.GetType();
            StringBuilder controlScript = new StringBuilder();
            controlScript.Append("\n<script>\n");
            string[] prefixParts = prefix.Split('.', '+');
            controlScript.AppendFormat("var {0} = {{\n", prefixParts[0]);
            for (int i = 1; i < prefixParts.Length; ++i)
            {
                controlScript.AppendFormat("\"{0}\": {{\n", prefixParts[i]);
            }
            int methodCount = 0;
            foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public))
            {
                object[] attributes = methodInfo.GetCustomAttributes(typeof (MethodAttribute), true);
                if (attributes != null && attributes.Length > 0)
                {
                    ++methodCount;
                    controlScript.AppendFormat("\n\"{0}\": function(", methodInfo.Name);
                    foreach (ParameterInfo paramInfo in methodInfo.GetParameters())
                    {
                        controlScript.Append(paramInfo.Name + ", ");
                    }
                    controlScript.AppendFormat("clientCallBack) {{\n\treturn Ajax_CallBack('{0}.{1}', [", type.FullName,
                                               methodInfo.Name);
                    int paramCount = 0;
                    foreach (ParameterInfo paramInfo in methodInfo.GetParameters())
                    {
                        ++paramCount;
                        controlScript.Append(paramInfo.Name);
                        controlScript.Append(",");
                    }
                    // If parameters were written, remove the
                    // trailing comma.
                    if (paramCount > 0)
                    {
                        --controlScript.Length;
                    }
                    controlScript.AppendFormat("], clientCallBack, {0}, {1}, {2});\n}}",
                                               (debug & Debug.RequestText) == Debug.RequestText ? "true" : "false",
                                               (debug & Debug.ResponseText) == Debug.ResponseText ? "true" : "false",
                                               (debug & Debug.Errors) == Debug.Errors ? "true" : "false");

                    controlScript.Append(",\n");
                }
            }
            // If no methods were found, you probably forget to add
            // [Ajax.Method] attributes to your methods.
            if (methodCount == 0)
            {
                throw new ApplicationException(
                    string.Format("{0} does not contain any public methods with the Ajax.Method attribute.",
                                  type.FullName));
            }
            // Remove the trailing comma and newline.
            controlScript.Length -= 2;
            controlScript.Append("\n\n");
            for (int i = 0; i < prefixParts.Length; ++i)
            {
                controlScript.Append("}");
            }
            controlScript.Append(";\n</script>");
            control.Page.ClientScript.RegisterClientScriptBlock(Type.GetType("System.String"),
                                                                "Ajax.Manager:" + type.FullName,
                                                                controlScript.ToString());
            control.PreRender += OnPreRender;
        }

        private static void OnPreRender(object s, EventArgs e)
        {
            Control control = s as Control;
            if (control != null)
            {
                MethodInfo methodInfo = FindTargetMethod(control);
                if (methodInfo != null)
                {
                    object val = null;
                    string error = null;
                    try
                    {
                        object[] parameters = ConvertParameters(methodInfo, HttpContext.Current.Request);
                        val = InvokeMethod(control, methodInfo, parameters);
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    WriteResult(HttpContext.Current.Response, val, error);
                }
            }
        }

        private static MethodInfo FindTargetMethod(Control control)
        {
            string target = CallBackTarget;
            if (target != null)
            {
                int lastDot = target.LastIndexOf('.');
                if (lastDot != -1)
                {
                    string typeName = target.Substring(0, lastDot);
                    Type type = control.GetType();
                    if (type.FullName == typeName)
                    {
                        string methodName = target.Substring(lastDot + 1);
                        MethodInfo methodInfo = type.GetMethod(methodName);
                        if (methodInfo.GetCustomAttributes(typeof (MethodAttribute), true).Length > 0)
                        {
                            return methodInfo;
                        }
                    }
                }
            }
            return null;
        }

        private static object[] ConvertParameters(
            MethodInfo methodInfo,
            HttpRequest req)
        {
            object[] parameters = new object[methodInfo.GetParameters().Length];
            int i = 0;
            foreach (ParameterInfo paramInfo in methodInfo.GetParameters())
            {
                object param = null;
                string paramValue = req.Form["Ajax_CallBackArgument" + i];
                if (paramValue != null)
                {
                    param = Convert.ChangeType(paramValue, paramInfo.ParameterType);
                }
                parameters[i] = param;
                ++i;
            }
            return parameters;
        }

        private static object InvokeMethod(
            Control control,
            MethodInfo methodInfo,
            object[] parameters)
        {
            object val = null;
            try
            {
                val = methodInfo.Invoke(control, parameters);
            }
            catch (TargetInvocationException ex)
            {
                // TargetInvocationExceptions should have the actual
                // exception the method threw in its InnerException
                // property.
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                else
                {
                    throw ex;
                }
            }
            return val;
        }

        private static void WriteResult(
            HttpResponse resp,
            object val,
            string error)
        {
            resp.ContentType = "application/x-javascript";
            resp.Cache.SetCacheability(HttpCacheability.NoCache);
            StringBuilder sb = new StringBuilder();
            try
            {
                WriteResult(sb, val, error);
            }
            catch (Exception ex)
            {
                // If an exception was thrown while formatting the
                // result value, we need to discard whatever was
                // written and start over with nothing but the error
                // message.
                sb.Length = 0;
                WriteResult(sb, null, ex.Message);
            }
            resp.Write(sb.ToString());
            resp.End();
        }

        private static void WriteResult(StringBuilder sb, object val, string error)
        {
            sb.Append("{\"value\":");
            WriteValue(sb, val);
            sb.Append(",\"error\":");
            WriteValue(sb, error);
            sb.Append("}");
        }

        private static void WriteValue(StringBuilder sb, object val)
        {
            if (val == null || val == DBNull.Value)
            {
                sb.Append("null");
            }
            else if (val is string)
            {
                WriteString(sb, val as String);
            }
            else if (val is bool)
            {
                sb.Append(val.ToString().ToLower());
            }
            else if (val is double ||
                     val is float ||
                     val is long ||
                     val is int ||
                     val is short ||
                     val is byte)
            {
                sb.Append(val);
            }
            else if (val is DateTime)
            {
                sb.Append("new Date(\"");
                sb.Append(((DateTime) val).ToString("MMMM, d yyyy HH:mm:ss"));
                sb.Append("\")");
            }
            else if (val is DataSet)
            {
                WriteDataSet(sb, val as DataSet);
            }
            else if (val is DataTable)
            {
                WriteDataTable(sb, val as DataTable);
            }
            else if (val is DataRow)
            {
                WriteDataRow(sb, val as DataRow);
            }
            else if (val is IEnumerable)
            {
                WriteEnumerable(sb, val as IEnumerable);
            }
            else
            {
                throw new ApplicationException(string.Format("Returning {0} objects is not supported.",
                                                             val.GetType().FullName));
            }
        }

        private static void WriteString(StringBuilder sb, string s)
        {
            sb.Append("\"");
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        int i = c;
                        if (i < 32 || i > 127)
                        {
                            sb.AppendFormat("\\u{0:X04}", i);
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            sb.Append("\"");
        }

        private static void WriteDataSet(StringBuilder sb, DataSet ds)
        {
            sb.Append("{\"Tables\":{");
            foreach (DataTable table in ds.Tables)
            {
                sb.AppendFormat("\"{0}\":", table.TableName);
                WriteDataTable(sb, table);
                sb.Append(",");
            }
            // Remove the trailing comma.
            if (ds.Tables.Count > 0)
            {
                --sb.Length;
            }
            sb.Append("}}");
        }

        private static void WriteDataTable(StringBuilder sb, DataTable table)
        {
            sb.Append("{\"Rows\":[");
            foreach (DataRow row in table.Rows)
            {
                WriteDataRow(sb, row);
                sb.Append(",");
            }
            // Remove the trailing comma.
            if (table.Rows.Count > 0)
            {
                --sb.Length;
            }
            sb.Append("]}");
        }

        private static void WriteDataRow(StringBuilder sb, DataRow row)
        {
            sb.Append("{");
            foreach (DataColumn column in row.Table.Columns)
            {
                sb.AppendFormat("\"{0}\":", column.ColumnName);
                WriteValue(sb, row[column]);
                sb.Append(",");
            }
            // Remove the trailing comma.
            if (row.Table.Columns.Count > 0)
            {
                --sb.Length;
            }
            sb.Append("}");
        }

        private static void WriteEnumerable(StringBuilder sb, IEnumerable e)
        {
            bool hasItems = false;
            sb.Append("[");
            foreach (object val in e)
            {
                WriteValue(sb, val);
                sb.Append(",");
                hasItems = true;
            }
            // Remove the trailing comma.
            if (hasItems)
            {
                --sb.Length;
            }
            sb.Append("]");
        }
    }
}

/*
 * Release History
 *
 * Release 1, 07/06/2005
 *   - Initial release.
 *
 * Release 2, 07/26/2005
 *   - Fixed bug which triggered the last server-side button's
 *     click event when calling back to the page as reported
 *     by Donald Hughes.
 *   - Set cacheability to NoCache for call back requests.
 *
 * Release 3, 07/29/2005
 *   - Merged in changes from Rick Strahl.
 *     - Added support for bool and DBNull.
 *     - Return the InnerException thrown by invoked methods.
 *   - Started using James Curran's technique for removing the
 *     trailing commas when outputting lists.
 *   - Factored out most of the code that was in OnPreRender to
 *     separate methods.
 *   - For security reasons, the code now checks to see if the call
 *     back target has the Ajax.Method on it before trying to invoke
 *     it.
 *
 * Release 4, 08/16/2005
 *   - Made error message more helpful when developers forget to add
 *     the Ajax.Method attribute any public methods.
 *   - Merged in some support for select elements from Thomas F Kelly, Jr.
 *   - Merged in Chris Payne's fixes for empty sets, tables, rows, and
 *     enumerables.
 *
 */