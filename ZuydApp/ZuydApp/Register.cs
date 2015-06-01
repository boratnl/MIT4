using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp.Portable;
using System.Net.Http; 

namespace ZuydApp
{
	public class Register
	{
		private string _username;
		private string _email;
		private string _password;

		public Register (string username, string email, string password)
		{
			_username = username;
			_email = email;
			_password = password;
			InsertUserInDatabase ();
		}
		//properties van oma kutjes
		public string propUsername
		{
			get { return _username; }
			set { _username = value; }
		}

		public string propEmail
		{
			get { return _email; }
			set { _email = value; }
		}

		public string propPassword
		{
			get { return _password; }
			set { _password = value; }
		}

		public void sendConfirmEmail()
		{
			
		}

		public async Task<string> InsertUserInDatabase()
		{
			var client = new RestClient ("http://www.sictma.com/zuydapp/insertAccount.php");
			var request = new RestRequest ("?Username={username}&Password={password}&Email={email}", HttpMethod.Get);
			request.AddUrlSegment ("username",propUsername);
			request.AddUrlSegment ("password",propPassword);
			request.AddUrlSegment ("email",propEmail);
			var result = await client.Execute (request);
			string resultString = System.Text.Encoding.UTF8.GetString (result.RawBytes, 0, result.RawBytes.Length);
			return resultString;
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