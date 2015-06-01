using System;
using Newtonsoft.Json.Serialization;

namespace ZuydApp
{
	public class LoginData
	{
		public LoginData ()
		{
			[JsonProperty(PropertyName="")]
			public string Username { get; set;}

		}
	}
}

