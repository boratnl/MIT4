using System;
using System.Threading.Tasks;
using RestSharp.Portable;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

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
			var request = new RestRequest ("?Username={username}&VakId={vakId}&Rating={RatingGetal}", HttpMethod.Get);
			request.AddUrlSegment ("username",UserSingleton.Instance.username);
			request.AddUrlSegment ("vakId",vakId);
			request.AddUrlSegment ("RatingGetal",rating);
			//request.AddUrlSegment ("Rating",rating);
			var result = await client.Execute (request);
			string resultString = System.Text.Encoding.UTF8.GetString (result.RawBytes, 0, result.RawBytes.Length);
			//var vakken = JsonConvert.DeserializeObject<List<VakJSON>> (resultString);
			return result.IsSuccess;
		}

		public static async Task<bool> UitgebreidBeoordelen(int vakId, string docent, string lokaal, string voorkennis, string totaletijd, string inhoudelijk)
		{
			var client = new RestClient ("http://www.sictma.com/zuydapp/BeoordelingUitgebreid.php");
			var request = new RestRequest ("?Username={username}&VakId={vakId}&Docent={docent}&Lokalen={lokalen}&Voorkennis={voorkennis}&totaletijd={totaletijd}&InhoudelijkNiveau={inhoudelijkniveau}", HttpMethod.Get);
			request.AddUrlSegment ("username",UserSingleton.Instance.username);
			request.AddUrlSegment ("vakId",vakId);
			request.AddUrlSegment ("docent",docent);
			request.AddUrlSegment ("lokalen",lokaal);
			request.AddUrlSegment ("voorkennis",voorkennis);
			request.AddUrlSegment ("totaletijd",totaletijd);
			request.AddUrlSegment ("inhoudelijkniveau",inhoudelijk);
			var result = await client.Execute (request);
			string resultString = System.Text.Encoding.UTF8.GetString (result.RawBytes, 0, result.RawBytes.Length);
			//var vakken = JsonConvert.DeserializeObject<List<VakJSON>> (resultString);
			return true;
		}

		public static async Task<string[]> getUitgebreideBeoordeling(int vakId)
		{
			var client = new RestClient ("http://www.sictma.com/zuydapp/getUitgebreideBeoordeling.php");
			var request = new RestRequest ("?Username={username}&Vak_Id={vakId}", HttpMethod.Get);
			request.AddUrlSegment ("username",UserSingleton.Instance.username);
			request.AddUrlSegment ("vakId",vakId);
			var result = await client.Execute (request);
			string resultString = System.Text.Encoding.UTF8.GetString (result.RawBytes, 0, result.RawBytes.Length);
			string[] UitgebreideBeoordelingArray = JsonConvert.DeserializeObject<string[]> (resultString);
			//var vakken = JsonConvert.DeserializeObject<List<VakJSON>> (resultString);

			/*List<string> x = new List<string> ();
			string[] separators = {'"'};
			string[] words = resultString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			foreach (var word in words)
				x.Add (word);*/

			return UitgebreideBeoordelingArray;
		}
	}
}

