using System;
using Android.Content;
using Mono.Data.Sqlite;
using System.IO;

namespace ZuydApp.Droid
{
	public class LogOut
	{
		public static string db_file = "Login.db3";

		public void LogoutDatabase()
		{
			var dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), db_file);
			bool exists = File.Exists (dbPath);
			var conn = new SqliteConnection ("Data Source="+dbPath);
			if (exists) {

				conn.Open ();

				try {

					var sql = "UPDATE Login SET Username='', Password='' WHERE Username=@Username;";
				//UPDATE Login SET Username='', Password='', Modified='' WHERE Username=@Username;
				using(var cmd = conn.CreateCommand()){
					cmd.CommandText = sql;
					cmd.Parameters.AddWithValue ("@Username", UserSingleton.Instance.username);
					cmd.ExecuteNonQuery ();
				}

				} catch (Exception ex) {
					Console.WriteLine (ex.Message);
				}

				conn.Close ();
			}
		}

		public LogOut ()
		{

		}
	}
}

