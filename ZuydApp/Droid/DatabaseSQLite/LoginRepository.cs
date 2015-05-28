using System;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;

namespace ZuydApp.Droid
{
	public class LoginRepository
	{
		private static string db_file = "Login.db3";
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
				cmd.Parameters.AddWithValue ("@Username", _login._username);
				cmd.Parameters.AddWithValue ("@Password", _login._password);
				cmd.Parameters.AddWithValue ("@Modified",DateTime.Now);
				cmd.ExecuteNonQuery ();
			}

			connection.Close ();
		}

		public Login GetPassword()
		{
			var sqlQuery = "SELECT * FROM Logins;";

			using (var conn = GetConnection ()) {
				conn.Open ();
				using(var cmd = conn.CreateCommand()){
					cmd.CommandText = sqlQuery;
					using(var reader = cmd.ExecuteReader()){
						if (reader.Read()) {
							return new Login (reader.GetInt32 (0), reader.GetString (1), reader.GetString (2), reader.GetDateTime (3));
						} else {
							return null;
						}
					}
				}
			}
		}
	}
}

