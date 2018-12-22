using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEB.@class
{
	/// <summary>
	/// 用于帮助连接数据库
	/// </summary>
	public static class SqlHelper
	{
		private static readonly string connStr = ConfigurationManager.ConnectionStrings["hotel"].ConnectionString;
		/// <summary>
		/// 通过sql语句返回一个表
		/// </summary>
		/// <param name="sql">sql语句</param>
		/// <param name="type">命令类型</param>
		/// <param name="pars">sql语句参数</param>
		/// <returns></returns>
		public static DataTable GetTable(string sql, CommandType type, params SqlParameter[] pars)
		{
			using (var atper = new SqlDataAdapter(sql, connStr))
			{
				atper.SelectCommand.CommandType = type;
				if (pars != null)
				{
					atper.SelectCommand.Parameters.AddRange(pars);
				}
				var da = new DataTable();
				atper.Fill(da);
				return da;
			}
		}
		/// <summary>
		/// 返回sql语句受影响的行数
		/// </summary>
		/// <param name="sql">sql语句</param>
		/// <param name="type">命令类型</param>
		/// <param name="pars">sql语句参数</param>
		/// <returns></returns>
		public static int ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] pars)
		{
			using (var conn = new SqlConnection(connStr))
			{
				using (var cmd = new SqlCommand())
				{
					cmd.Connection = conn;
					cmd.CommandText = sql;
					cmd.CommandType = type;
					if (pars != null)
					{
						cmd.Parameters.AddRange(pars);
					}
					conn.Open();
					return cmd.ExecuteNonQuery();
				}
			}
		}
		/// <summary>
		/// 返回sql语句返回的第一行第一列
		/// </summary>
		/// <param name="sql">sql语句</param>
		/// <param name="type">命令类型</param>
		/// <param name="pars">sql语句参数</param>
		/// <returns></returns>
		public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] pars) //返回第一行第一列
		{
			using (var conn = new SqlConnection(connStr))
			{
				using (var cmd = new SqlCommand(sql, conn))
				{
					cmd.CommandType = type;
					if (pars != null)
					{
						cmd.Parameters.AddRange(pars);
					}
					conn.Open();
					return cmd.ExecuteScalar();
				}
			}
		}
	}
}