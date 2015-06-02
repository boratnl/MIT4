using System;
using System.Threading.Tasks;
using RestSharp.Portable;
using System.Net.Http; 

namespace ZuydApp
{
	public class Schoolfeedback
	{
		private string _message;
		private string _username;

		public Schoolfeedback (string username, string message)
		{
			_message = message;
			_username = username;
		}

		public async Task<string> SendEmail()
		{
			var client = new RestClient ("http://www.sictma.com/zuydapp/sendSchoolFeedback.php");
			var request = new RestRequest ("?Username={username}&Message={message}", HttpMethod.Get);
			request.AddUrlSegment ("username",_username);
			request.AddUrlSegment ("message",_message);
			var result = await client.Execute (request);
			string resultString = System.Text.Encoding.UTF8.GetString (result.RawBytes, 0, result.RawBytes.Length);
			return resultString;
		}
	}
}

