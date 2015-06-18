using System;
using Newtonsoft.Json;

namespace ZuydApp
{
	public class Vak
	{
		[JsonProperty(PropertyName="name")]
		public string Name { get; set; }

		public Vak (){ }

		public override string ToString ()
		{
			return Name;
		}
	}
}

