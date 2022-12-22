using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET.Helper
{
    static class Sql
    {
		static string connectionString = "Server=DESKTOP-59QHG10;Database=Spotify;Trusted_Connection=True";

        static SqlConnection _connection;

		public static SqlConnection Connection
		{
			get 
			{ 
				if( _connection == null )
				{
				  _connection = new SqlConnection(connectionString);
				}
				  return _connection; 
			}
		}

		public static void ExecCommand(string command)
		{ 
			Connection.Open();
			using (SqlCommand sqlCommand=new SqlCommand(command,Connection))
			{
				sqlCommand.ExecuteNonQuery();
			}
			Connection.Close();
		}
		public static DataTable ExecQuery(string query)
		{ 
			DataTable dt = new DataTable();
			Connection.Open();
			using (SqlDataAdapter sda = new SqlDataAdapter(query,Connection))
			{
				sda.Fill(dt);
			}
			Connection.Close();
			return dt;
		}
	}
}
