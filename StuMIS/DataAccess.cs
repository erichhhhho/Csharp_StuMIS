using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StuMIS
{
    class DataAccess
    {
        public static string ConnectionString = "server=.;database=jiaoxuedb;uid=sa;pwd=960109";
        public bool ExecuteSQL(String sql)
        {
            SqlConnection conn = new SqlConnection(DataAccess.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();

            }
        }

        public SqlDataReader GetReader(String sql)
        {
            SqlConnection conn = new SqlConnection(DataAccess.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = null;
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                dr.Close();
                conn.Dispose();
                cmd.Dispose();
                throw new Exception(e.ToString());
            }
            return dr;
        }

        public DataSet GetDataSet(string sql, string tablename)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(DataAccess.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            try
            {
                da.Fill(ds, tablename);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                da.Dispose();
            }
            return ds;
        }

        public int GetCount(string sql)
        {
            SqlConnection conn = new SqlConnection(DataAccess.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();

            }
        }

        public bool CheckAdmin(string strname, string strpwd)
        {
            string sql;
            sql = "Select count(*) from User_Login where UserName='" + strname + "' and UserPwd='" + strpwd + "' ";
            if (GetCount(sql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
