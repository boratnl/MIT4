using System;
using System.Threading.Tasks;
using RestSharp.Portable;
using System.Net.Http;
using Newtonsoft.Json;

namespace ZuydApp
{
	public static class VakkenAPI
	{
		public static async Task<string> Fetch()
		{
			var client = new RestClient ("http://www.sictma.com/zuydapp/getVakken.php");
			var request = new RestRequest ("?Blok={blok}", HttpMethod.Get);
			request.AddUrlSegment ("blok",3);
			var result = await client.Execute (request);
			string resultString = System.Text.Encoding.UTF8.GetString (result.RawBytes, 0, result.RawBytes.Length);
			//var vakken = JsonConvert.DeserializeObject<Vakken> (resultString);
			return resultString;
		}
	}
}

