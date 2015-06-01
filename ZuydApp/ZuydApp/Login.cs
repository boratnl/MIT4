using System;
using Mono.Data.Sqlite;
using System.Net;
using System.Data;
using RestSharp;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp.Portable;
using Newtonsoft.Json;

namespace ZuydApp
{
	public class Login
	{
		private string _username;
		private string _password;
		private bool _remember;

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

		public Login (string username, string password)
		{
			
		}

		public void SetDataOffline ()
		{
			
		}

		public bool CheckIfDataIsOffline ()
		{
			
			return false;
		}
			
		public async Task<string> Fetch()
		{
			string LoginCheck = "false";
			var client = new RestClient ("http://www.sictma.com/zuydapp/getLogin.php");
			var request = new RestRequest ("?Username={username}&Password={password}", HttpMethod.Get);
			request.AddUrlSegment ("username",propUsername);
			request.AddUrlSegment ("password",propPassword);
			var result = await client.Execute (request);
			string resultString = System.Text.Encoding.UTF8.GetString (result.RawBytes, 0, result.RawBytes.Length);
			if (resultString == "true") {
				LoginCheck = "true";
			}
			else if(resultString == "Account niet geactiveerd")
			{
				LoginCheck = "Account niet geactiveerd";
			}
			//var loginData = JsonConvert.DeserializeObject<Login> (resultString);

			return LoginCheck;
		}
	}
}