using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.SingletonPattern
{
    interface IDataProvider
    {
        DataTable ExecuteQuery(string strQuery);
        DataTable ExecuteStoreProc(string storeProcName, IList<string> arrParameterName, ArrayList arrParameterValue);
        int ExcuteScalar(string strSQL);
        string ExcuteScalarString(string strSQL);
        string getStrByString(string strQuery, string Filedname);
        bool ExecuteNonQuery(string strSQL);
        int ExecuteNonQuery(string strSQL, string isReturnInt);
        string GetLastID(string nameTable, string nameFiled);
        string NextID(string lastID, string prefixID);
        bool ExecuteReader(string sql);
        int ExecuteReader(string sql, string isReturnInt);
        string GetName();
        string GetDLLFileName();
    }
}
