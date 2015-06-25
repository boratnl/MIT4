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

		public void GetUser()
		{
			var sqlQuery = "SELECT Username, Password FROM Login;";

			using (var conn = GetConnection ()) {
				conn.Open ();
				using(var cmd = conn.CreateCommand()){
					cmd.CommandText = sqlQuery;
					using(var reader = cmd.ExecuteReader()){
						if (reader.Read ()) {
							string x = reader.GetString (0);
							string x2 = reader.GetString (1);
							UserSingleton.Instance.username = reader.GetString (0);
						} else {
							UserSingleton.Instance.username = "";
						}
					}
				}
			}

			/*var dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), db_file);
			bool exists = File.Exists (dbPath);
			var conn2 = new SqliteConnection ("Data Source="+dbPath);
			if (exists) {

				conn2.Open ();

				try {
					// INSERT INTO Login (Username, Password) VALUES ('test', 'test2')
					var sql = "UPDATE Login SET Username=@LoginNaam, Password=@LoginPassword WHERE Username='';";
					//UPDATE Login SET Username='', Password='', Modified='' WHERE Username=@Username;
					using(var cmd = conn2.CreateCommand()){
						cmd.CommandText = sql;
						cmd.Parameters.AddWithValue ("@LoginNaam", "Maikel");
						cmd.Parameters.AddWithValue ("@LoginPassword", "test");
						cmd.ExecuteNonQuery ();
					}

				} catch (Exception ex) {
					Console.WriteLine (ex.Message);
				}

				conn2.Close ();
			}*/
		}

		public void InsertUser()
		{
			var dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), db_file);
			bool exists = File.Exists (dbPath);
			var conn = new SqliteConnection ("Data Source="+dbPath);
			if (exists) {

				conn.Open ();

				try {
					// INSERT INTO Login (Username, Password) VALUES ('test', 'test2')
					var sql = "UPDATE Login SET Username=@LoginNaam, Password=@LoginPassword WHERE Username='';";
					//UPDATE Login SET Username='', Password='', Modified='' WHERE Username=@Username;
					using(var cmd = conn.CreateCommand()){
						cmd.CommandText = sql;
						cmd.Parameters.AddWithValue ("@LoginNaam", _login.propUsername);
						cmd.Parameters.AddWithValue ("@LoginPassword", _login.propPassword);
						cmd.ExecuteNonQuery ();
					}

				} catch (Exception ex) {
					Console.WriteLine (ex.Message);
				}

				conn.Close ();
			}
		}
	}
}

