using Newtonsoft.Json;

namespace ZuydApp
{
	public class VakJSON
	{
		[JsonProperty(PropertyName="Id")]
		public int Id { get; set;}

		[JsonProperty(PropertyName="Titel")]
		public string Titel { get; set;}

		[JsonProperty(PropertyName="Afkorting")]
		public string Afkorting { get; set;}

		[JsonProperty(PropertyName="Docent")]
		public string Docent { get; set;}

		[JsonProperty(PropertyName="Leerjaar")]
		public int Leerjaar { get; set;}

		[JsonProperty(PropertyName="Faculteit")]
		public string Faculteit { get; set;}

		[JsonProperty(PropertyName="Blok")]
		public int Blok { get; set;}

		[JsonProperty(PropertyName="Rating")]
		public int Rating { get; set;}
	}
}

