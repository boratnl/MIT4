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

		public static async Task<bool> RatingBeoordelen(int vakid, int rating)
		{
			var client = new RestClient ("http://www.sictma.com/zuydapp/Beoordeling.php");
			var request = new RestRequest ("?Username={username}&Vak_Id={vak_id}&Rating={rating}", HttpMethod.Get);
			request.AddUrlSegment ("username","Maikel");
			request.AddUrlSegment ("vak_id",vakid);
			request.AddUrlSegment ("rating",rating);
			var result = await client.Execute (request);
			string resultString = System.Text.Encoding.UTF8.GetString (result.RawBytes, 0, result.RawBytes.Length);
			//var vakken = JsonConvert.DeserializeObject<List<VakJSON>> (resultString);
			return true;
		}
	}
}

