using System;
using System.Threading.Tasks;
using RestSharp.Portable;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace ZuydApp
{
	public static class VakkenAPI
	{
		public static async Task<List<VakJSON>> Fetch()
		{
			var client = new RestClient ("http://www.sictma.com/zuydapp/getVakken.php");
			var request = new RestRequest ("?Username={Username}&Blok={blok}", HttpMethod.Get);
			request.AddUrlSegment ("Username", UserSingleton.Instance.username);
			request.AddUrlSegment ("blok",3);
			var result = await client.Execute (request);
			string resultString = System.Text.Encoding.UTF8.GetString (result.RawBytes, 0, result.RawBytes.Length);
			var vakken = JsonConvert.DeserializeObject<List<VakJSON>> (resultString);
			return vakken;
		}
	}
}