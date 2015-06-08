using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ZuydApp
{
	public class VakkenJSON
	{
		[JsonProperty(PropertyName="Titel")]
		public List<string> Titel { get; set;}

		[JsonProperty(PropertyName="Afkorting")]
		public List<string> Afkorting { get; set;}

		[JsonProperty(PropertyName="Docent")]
		public List<string> Docent { get; set;}

		[JsonProperty(PropertyName="Leerjaar")]
		public List<int> Leerjaar { get; set;}

		[JsonProperty(PropertyName="Faculteit")]
		public List<string> Faculteit { get; set;}

		[JsonProperty(PropertyName="Blok")]
		public List<int> Blok { get; set;}

		[JsonProperty(PropertyName="Id")]
		public List<int> Id { get; set;}
	}
}

