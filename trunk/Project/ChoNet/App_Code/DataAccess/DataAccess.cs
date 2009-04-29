using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;

/// <summary>
/// Summary description for DataAccess
/// </summary>
namespace CHONET.DataAccessLayer
{
    public class DataAccess
    {
        private readonly string strSqlConnectionString;
        private SqlTransaction sqlTrans;

        public DataAccess()
        {
            strSqlConnectionString = ConfigurationManager.AppSettings["CHONET"];
        }

        public DataSet ExecuteQuery(SqlCommand sqlCmd, string strTableName)
        {
            using (SqlConnection sqlConn = new SqlConnection())
            {
                try
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    DataSet myDataSet = new DataSet();
                    myDataSet.Locale = CultureInfo.CurrentCulture;
                    sqlConn.ConnectionString = strSqlConnectionString;
                    if (sqlConn.State != ConnectionState.Open)
                    {
                        sqlConn.Open();
                    }

                    sqlCmd.Connection = sqlConn;
                    sqlDataAdapter.SelectCommand = sqlCmd;

                    sqlDataAdapter.Fill(myDataSet, strTableName);
                    return myDataSet;
                }
                catch (SqlException exSql)
                {
                    string strMsg;
                    strMsg = HttpContext.Current.Server.UrlEncode(exSql.Message);
                    HttpContext.Current.Response.Redirect("~/Message.aspx?msg=" + strMsg);
                    return null;
                }
            }
        }

        public DataSet FillDataSet(DataSet dsOriginal, SqlCommand sqlCmd, string strTableName)
        {
            using (SqlConnection sqlConn = new SqlConnection())
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlConn.ConnectionString = strSqlConnectionString;
                if (sqlConn.State != ConnectionState.Open)
                {
                    sqlConn.Open();
                }

                sqlCmd.Connection = sqlConn;
                sqlDataAdapter.SelectCommand = sqlCmd;

                sqlDataAdapter.Fill(dsOriginal, strTableName);
                return dsOriginal;
            }
        }

        public void ExecuteNonQuery(SqlCommand sqlCmd)
        {
            using (SqlConnection sqlConn = new SqlConnection())
            {
                try
                {
                    sqlConn.ConnectionString = strSqlConnectionString;
                    if (sqlConn.State != ConnectionState.Open)
                    {
                        sqlConn.Open();
                    }
                    sqlTrans = sqlConn.BeginTransaction("ExecuteNonQueryTransaction");
                    sqlCmd.Connection = sqlConn;
                    sqlCmd.Transaction = sqlTrans;
                    sqlCmd.ExecuteNonQuery();
                    sqlTrans.Commit();
                }
                catch (SqlException exSql)
                {
                    SqlException ex = exSql;
                    try
                    {
                        if (sqlTrans != null)
                        {
                            sqlTrans.Rollback("ExecuteNonQueryTransaction");
                        }
                    }
                    catch (SqlException exRollback)
                    {
                        ex = exRollback;
                    }
                    throw ex;
                }
            }
        }

        public int ExecuteScalar(SqlCommand sqlCmd)
        {
            using (SqlConnection sqlConn = new SqlConnection())
            {
                int iValue = 0;
                try
                {
                    sqlConn.ConnectionString = strSqlConnectionString;
                    if (sqlConn.State != ConnectionState.Open)
                    {
                        sqlConn.Open();
                    }
                    sqlTrans = sqlConn.BeginTransaction("ExecuteNonQueryTransaction");
                    sqlCmd.Connection = sqlConn;
                    sqlCmd.Transaction = sqlTrans;
                    iValue = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlTrans.Commit();
                }
                catch (SqlException exSql)
                {
                    SqlException ex = exSql;
                    try
                    {
                        if (sqlTrans != null)
                        {
                            sqlTrans.Rollback("ExecuteNonQueryTransaction");
                        }
                    }
                    catch (SqlException exRollback)
                    {
                        ex = exRollback;
                    }
                    throw ex;
                }
                return iValue;
            }
        }

        public DataSet SelectByQuery(string strSQL)
        {
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = strSQL;
                dsResult = ExecuteQuery(sqlCmd, "view");
                return dsResult;
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate, SqlCommand sqlCmd, DataTableMapping dtTblMapping)
        {
            using (SqlConnection sqlConn = new SqlConnection())
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                try
                {
                    sqlConn.ConnectionString = strSqlConnectionString;
                    if (sqlConn.State != ConnectionState.Open)
                    {
                        sqlConn.Open();
                    }

                    sqlTrans = sqlConn.BeginTransaction("UpdateBatch");
                    sqlCmd.Connection = sqlConn;
                    sqlCmd.Transaction = sqlTrans;

                    sqlDataAdapter.UpdateCommand = sqlCmd;
                    sqlDataAdapter.DeleteCommand = sqlCmd;
                    sqlDataAdapter.InsertCommand = sqlCmd;
                    sqlDataAdapter.TableMappings.AddRange(new DataTableMapping[] {dtTblMapping});
                    sqlDataAdapter.UpdateBatchSize = 2; //sends 2 statements to the database at a time 
                    sqlDataAdapter.UpdateCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

                    sqlDataAdapter.Update(rowUpdate);
                    sqlTrans.Commit();
                }

                catch (SqlException exSql)
                {
                    SqlException ex = exSql;
                    try
                    {
                        if (sqlTrans != null)
                        {
                            sqlTrans.Rollback("UpdateBatch");
                        }
                    }
                    catch (SqlException exRollback)
                    {
                        ex = exRollback;
                    }
                    throw ex;
                }
                finally
                {
                    sqlDataAdapter.TableMappings.RemoveAt(0);
                }
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate, SqlCommand sqlCmd, DataTableMapping dtTblMapping)
        {
            using (SqlConnection sqlConn = new SqlConnection())
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                try
                {
                    sqlConn.ConnectionString = strSqlConnectionString;
                    if (sqlConn.State != ConnectionState.Open)
                    {
                        sqlConn.Open();
                    }

                    sqlTrans = sqlConn.BeginTransaction("UpdateBatch");
                    sqlCmd.Connection = sqlConn;
                    sqlCmd.Transaction = sqlTrans;

                    sqlDataAdapter.UpdateCommand = sqlCmd;
                    sqlDataAdapter.DeleteCommand = sqlCmd;
                    sqlDataAdapter.InsertCommand = sqlCmd;
                    sqlDataAdapter.TableMappings.AddRange(new DataTableMapping[] {dtTblMapping});
                    sqlDataAdapter.UpdateBatchSize = 2; //sends 2 statements to the database at a time 
                    sqlDataAdapter.UpdateCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

                    sqlDataAdapter.Update(rowUpdate);
                    sqlTrans.Commit();
                }

                catch (SqlException exSql)
                {
                    SqlException ex = exSql;
                    try
                    {
                        if (sqlTrans != null)
                        {
                            sqlTrans.Rollback("UpdateBatch");
                        }
                    }
                    catch (SqlException exRollback)
                    {
                        ex = exRollback;
                    }
                    throw ex;
                }
                finally
                {
                    sqlDataAdapter.TableMappings.RemoveAt(0);
                }
            }
        }
    }
}