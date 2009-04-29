using System.Data;
using System.Data.SqlClient;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class SanPhamMau : Base_SanPhamMau
    {
        #region Constructors

        #endregion

        #region Added Code

        public DataSet SelectAllSanPhamMau()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamMau";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamMauPaging(string KeySearch, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamMauPaging";
                sqlCmd.Parameters.Add("@KeySearch", SqlDbType.NVarChar, 1000).Value = KeySearch;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        #endregion
    }
}