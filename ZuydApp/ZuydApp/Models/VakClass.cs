using System;

namespace ZuydApp
{
	public class VakClass
	{
		public string Naam {get;set;}
		public string Docent {get;set;}
		public int Id {get;set;}

		public VakClass (string naam, string docent, int id)
		{
			this.Naam = naam;
			this.Docent = docent;
			this.Id = id;
		}

		public override string ToString ()
		{
			return string.Format ("[Class: Naam={0}, Docent={1}, Id={2}]", Naam, Docent, Id);
		}
	}
}

