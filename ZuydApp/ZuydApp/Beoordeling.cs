using System;
using System.Threading.Tasks;
using RestSharp.Portable;
using System.Net.Http;
using Newtonsoft.Json;

namespace ZuydApp
{
	public class Beoordeling
	{


		public Beoordeling ()
		{
			
		}

		public static async Task<bool> RatingBeoordelen(int vakId, int rating)
		{
			var client = new RestClient ("http://www.sictma.com/zuydapp/Beoordeling.php");
			var request = new RestRequest ("?Username={username}&VakId={vakId}&Rating={rating}", HttpMethod.Get);
			request.AddUrlSegment ("username",UserSingleton.Instance.username);
			request.AddUrlSegment ("vakId",vakId);
			request.AddUrlSegment ("rating",rating);
			var result = await client.Execute (request);
			string resultString = System.Text.Encoding.UTF8.GetString (result.RawBytes, 0, result.RawBytes.Length);
			//var vakken = JsonConvert.DeserializeObject<List<VakJSON>> (resultString);
			return true;
		}
	}
}

