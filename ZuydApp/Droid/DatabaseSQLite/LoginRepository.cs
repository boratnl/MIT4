using System;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;
using Android.App;
using System.Net;
using System.Data.SqlClient;

namespace ZuydApp.Droid
{
	public class LoginRepository
	{
		public static string db_file = "Login.db3";
		public Login _login;

		public LoginRepository (Login login)
		{
			_login = login;
		}

		public LoginRepository()
		{
			
		}

		public SqliteConnection GetConnection()
		{
			var dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), db_file);
			bool exists = File.Exists (dbPath);

			if (!exists)
				SqliteConnection.CreateFile (dbPath);
		
			var conn = new SqliteConnection ("Data Source="+dbPath);
			if (!exists)
				CreateDatabase (conn);

			return conn;
		}

		public bool ExistDatabase()
		{
			var dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), db_file);
			bool exists = File.Exists (dbPath);

			return exists;
		}

		private void CreateDatabase (SqliteConnection connection)
		{
			var sql = "CREATE TABLE Login (Id INTEGER PRIMARY KEY AUTOINCREMENT, Username ntext, Password ntext, Modified datetime);";
			connection.Open ();

			using(var cmd = connection.CreateCommand()){
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery ();
			}

			sql = "INSERT INTO Login (Username, Password, Modified) VALUES (@Username, @Password, @Modified);";

			using(var cmd = connection.CreateCommand()){
				cmd.CommandText = sql;
				cmd.Parameters.AddWithValue ("@Username", _login.propUsername);
				cmd.Parameters.AddWithValue ("@Password", _login.propPassword);
				cmd.Parameters.AddWithValue ("@Modified",DateTime.Now);
				cmd.ExecuteNonQuery ();
			}

			connection.Close ();
		}

		public Login GetAllUsers()
		{
			var sqlQuery = "SELECT Username, Password FROM Login;";

			using (var conn = GetConnection ()) {
				conn.Open ();
				using(var cmd = conn.CreateCommand()){
					cmd.CommandText = sqlQuery;
					using(var reader = cmd.ExecuteReader()){
						if (reader.Read ()) {
							return new Login (reader.GetString (0), reader.GetString (1));
						} else {
							return null;
						}
					}
				}
			}
		}
	}
}

