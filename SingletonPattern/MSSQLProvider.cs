using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
namespace DesignPattern.SingletonPattern
{
    public class MSSQLProvider : IDataProvider
    {
        public string GetName()
        {
            return "MS-SQL Server Database";
        }
        public string GetDLLFileName()
        {
            return "MSSQLDataProvider.dll";
        }
        private SqlConnection Cn = null;

        public DataProvider()
        {
            string strCn = "Data Source=.\\SQLEXPRESS;Initial Catalog=QLKhachSan;Integrated Security=True;";
            Cn = new SqlConnection(strCn);
        }

        public DataTable ExecuteQuery(string strQuery)
        {
            DataTable dt = new DataTable();

            try
            {
                Cn.Open();

                SqlDataAdapter da = new SqlDataAdapter(strQuery, Cn);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi thuc thi lenh SQL: " + ex.Message);
            }
            finally
            {
                Cn.Close();
            }

            return dt;
        }

        public DataTable ExecuteStoreProc(string storeProcName, IList<string> arrParameterName, ArrayList arrParameterValue)
        {
            DataTable resTable = null;

            try
            {
                Cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = storeProcName;
                cmd.CommandType = CommandType.StoredProcedure;

                //Lay so parameter
                int N = arrParameterName.Count;
                for (int i = 0; i < N; i++)
                {
                    SqlParameter sqlParam = new SqlParameter(arrParameterName[i], arrParameterValue[i]);
                    cmd.Parameters.Add(sqlParam);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(resTable);

                Cn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi thuc thi store procedure: " + ex.Message);
            }

            return resTable;
        }
        public int ExcuteScalar(string strSQL)
        {
            int val;
            try
            {
                // Cn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, Cn);
                cmd.Connection.Open();
                val = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Connection.Close();
                //Cn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi thuc thi store procedure: " + ex.Message);
            }
            return val;
        }
        public string ExcuteScalarString(string strSQL)
        {
            string val;
            try
            {
                // Cn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, Cn);
                cmd.Connection.Open();
                val = cmd.ExecuteScalar().ToString();
                cmd.Connection.Close();
                //Cn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi thuc thi store procedure: " + ex.Message);
            }
            return val;
        }
        public string getStrByString(string strQuery, string Filedname)
        {
            DataTable dt = new DataTable();
            string val = "";
            try
            {
                Cn.Open();

                SqlDataAdapter da = new SqlDataAdapter(strQuery, Cn);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi thuc thi lenh SQL: " + ex.Message);
            }
            finally
            {
                Cn.Close();
            }
            // Khi Table có dữ liệu
            if (dt.Rows.Count > 0)
                val = dt.Rows[0][Filedname].ToString();
            return val;
        }
        public bool ExecuteNonQuery(string strSQL)
        {
            bool flag = false;
            try
            {
                Cn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, Cn);
                cmd.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi thuc thi lenh SQL: " + ex.Message);

            }
            finally
            {
                Cn.Close();
            }
            return flag;
        }
        public int ExecuteNonQuery(string strSQL, string isReturnInt)
        {
            int flag = 0;
            try
            {
                Cn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, Cn);
                cmd.ExecuteNonQuery();
                flag = 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Loi khi thuc thi lenh SQL: " + ex.Message);

            }
            finally
            {
                Cn.Close();
            }
            return flag;
        }
        public string GetLastID(string nameTable, string nameFiled)
        {
            DataTable dt = new DataTable();
            string strSQL = "SELECT TOP 1 " + nameFiled + " FROM " + nameTable + " ORDER BY " + nameFiled + " DESC";
            dt = ExecuteQuery(strSQL);
            if (dt.Rows.Count > 0)
                return dt.Rows[0][nameFiled].ToString();
            return "";
        }
        public string NextID(string lastID, string prefixID)
        {
            if (lastID != "")
            {
                int nextID = int.Parse(lastID.Remove(0, prefixID.Length)) + 1;
                int lengthNumerID = lastID.Length - prefixID.Length;
                string zeroNumber = "";
                for (int i = 1; i <= lengthNumerID; i++)
                {
                    if (nextID < Math.Pow(10, i))
                    {
                        for (int j = 1; j <= lengthNumerID - i; i++)
                        {
                            zeroNumber += "0";
                        }
                        return prefixID + zeroNumber + nextID.ToString();
                    }
                }
                return prefixID + nextID;
            }
            else
                return prefixID + "00000001";
        }
        public bool ExecuteReader(string sql)
        {
            bool flag = false;
            try
            {
                Cn.Open();
                SqlCommand cmd = new SqlCommand(sql, Cn);
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                dar.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            finally
            {
                Cn.Close();
            }
            return flag;
        }
        public int ExecuteReader(string sql, string isReturnInt)
        {
            int flag = 0;
            try
            {
                Cn.Open();
                SqlCommand cmd = new SqlCommand(sql, Cn);
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                }
                dar.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            finally
            {
                Cn.Close();
            }
            return flag;
        }
        protected virtual object GetDataFromDataRow(DataTable dt, int i)
        {
            return null;
        }
    }
}
