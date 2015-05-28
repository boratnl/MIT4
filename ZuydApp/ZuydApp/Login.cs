using System;
using Mono.Data.Sqlite;

namespace ZuydApp
{
	public class Login
	{
		public string _username;
		public string _password;
		public bool _remember;

		public string propUsername {
			get {
				return _username;
			}
			set {
				_username = value;
			}
		}
		public string propPassword {
			get {
				return _password;
			}
			set {
				_password = value;
			}
		}
		public bool propRemember {
			get {
				return _remember;
			}
			set {
				_remember = value;
			}
		}

		public Login ()
		{
			
		}

		public Login (string username, string password, bool remember)
		{
			propUsername = username;
			propPassword = password;
			propRemember = remember;

			SetDataOffline ();
		}

		public Login (int id, string username, string password, DateTime date)
		{
			
		}

		public void SetDataOffline ()
		{

		}

		public bool CheckIfDataIsOffline ()
		{
			return false;
		}

		public bool CheckPassword ()
		{
			string text = "";
			SqliteConnection sqlconn;
			string connsqlstring = string.Format ("Server=pdb14.awardspace.net;Database=1670359_darts;Password=ammi11amkreutz;Username=1670359_darts");
			sqlconn = new SqliteConnection (connsqlstring);

			var sqlQuery = "SELECT * FROM Nieuws;";

			using (sqlconn) {
				sqlconn.Open ();
				using (var cmd = sqlconn.CreateCommand ()) {
					cmd.CommandText = sqlQuery;
					using (var reader = cmd.ExecuteReader ()) {
						if (reader.Read ()) {
							text = reader.ToString();
						} else {
							text = "";
						}
					}
				}
			}

			return false;
		}
	}
}

