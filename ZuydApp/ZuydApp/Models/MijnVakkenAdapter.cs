using System;
using System.Collections.Generic;

namespace ZuydApp
{
	public class MijnVakkenAdapter
	{
		private static List<VakClass> classes = new List<VakClass>{
			new VakClass("MIT4 CrossApp development","Mr. Slot", 1),
			new VakClass("MIT3 Data Visualisatie","Mr. Slot", 2)
		};

		public static List<VakClass> getMijnVakken(){
			return classes;
		}

		public void addClasses(string Titel, string Docent, int ster)
		{
			classes.Add(new VakClass(Titel, Docent, ster));
		}
	}
}

