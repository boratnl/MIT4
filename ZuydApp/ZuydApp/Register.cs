using System;
using System.Collections.Generic; 

namespace ZuydApp
{
	public class Register
	{
		private string _name;
		private string _email;
		private string _password;

		public Register (string email, string password)
		{
			_email = email;
			_password = password;
			sendConfirmEmail ();
		}
		//properties van oma kutjes
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		public void sendConfirmEmail()
		{
			
		}

		/*public bool Login(string username, string password)
		{
			MySqlConnection con = new MySqlConnection ("host=localhost;username…");
			MySqlCommand cmd = new MySqlCommand ("SELECT * FROM login WHERE username='" + username + "' and password='" + password + ";");

			cmd.Connection = con;

			con.Open (); // Here is the line where I got this message >> Unable to connect to any of the specified MySQL hosts.

			MySqlDataReader reader = cmd.ExecuteReader ();

			if (reader.Read () != false) {

				if (reader.IsDBNull (0) == true) {
					cmd.Connection.Close ();
					reader.Dispose ();
					cmd.Dispose ();
					return false;
				} else {

					cmd.Connection.Close ();

					reader.Dispose ();
					cmd.Dispose ();
					return true;
				}

			} else {
				return false;
			}
		}*/
	}
}