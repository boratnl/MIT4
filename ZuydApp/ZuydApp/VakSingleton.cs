using System;

namespace ZuydApp
{
	public class VakSingleton
	{
		private static VakSingleton instance;
		public int vakid;
		private VakSingleton() {}

		public static VakSingleton Instance
		{
			get 
			{
				if (instance == null)
				{
					instance = new VakSingleton();
				}
				return instance;
			}
		}
	}
}

