using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public class DBHelper
{

    public static string connstr = System.Configuration.ConfigurationSettings.AppSettings["hk"];

   private DBHelper()
    {
   
    }
    // ִ��sql������Ӱ������
    public static int execSql(string sql)
    {
        int result;

        SqlConnection conn = new SqlConnection(connstr);

        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        try
        {
            result = cmd.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();

        }
        return result;
    }
    // ִ��sql������Ӱ������
    public static int execSql(string sql, params SqlParameter[] values)
    {
        int result = 0;

        SqlConnection conn = new SqlConnection(connstr);

        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddRange(values);
        conn.Open();
        try
        {
            result = cmd.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();

        }
        return result;

    }
    // ִ��sql������ִ�н���еĵ�һ��
    public static int execScalar(string sql)
    {
        int result;

        SqlConnection conn = new SqlConnection(connstr);

        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        try
        {
            result = Convert.ToInt32(cmd.ExecuteScalar());
        }
        finally
        {
            conn.Close();

        }
        return result;
    }
    public static bool execScalar1(string sql)
    {
        SqlConnection conn = new SqlConnection(connstr);
        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        int count = Convert.ToInt32(cmd.ExecuteScalar());//��count��������ѯ������ֵ���õ���int��
        if (count != 0)//�ж��Ƿ�Ϊ�ա����Ƿ���true���Ƿ���false
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static string IsExist11(string sql)//����Ϊselect
    {
        SqlConnection conn = new SqlConnection(connstr);
        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        string count = cmd.ExecuteScalar().ToString();//��count��������ѯ������ֵ
        return count;//�������ֵ
    }
    // ִ��sql������ִ�н���еĵ�һ��
    public static int execScalar(string sql, params SqlParameter[] values)
    {
        int result;

        SqlConnection conn = new SqlConnection(connstr);

        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddRange(values);
        conn.Open();
        try
        {
            result = Convert.ToInt32(cmd.ExecuteScalar());
        }
        finally
        {
            conn.Close();

        }
        return result;
    }
    // ִ��sql������sqldatareader
    public static SqlDataReader execReader(string sql)
    {
        SqlConnection conn = new SqlConnection(connstr);

        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return reader;
    }
    // ִ��sql�����ػ��sqldatareader
    public static SqlDataReader execReader(string sql, params SqlParameter[] values)
    {
        SqlConnection conn = new SqlConnection(connstr);

        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddRange(values);
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return reader;
    }
    // ִ��sql������DataSet
    public static DataSet execDataSet(string sql)
    {
        SqlConnection conn = new SqlConnection(connstr);

        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        return ds;
    }
    // ִ��sql������DataSet
    public static DataSet execDataSet(string sql, params SqlParameter[] values)
    {
        SqlConnection conn = new SqlConnection(connstr);

        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddRange(values);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        return ds;
    }


}
