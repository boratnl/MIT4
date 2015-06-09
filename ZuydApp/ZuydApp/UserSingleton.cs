using System;

namespace ZuydApp
{
	public class UserSingleton
	{
		private static UserSingleton instance;
		public string username;
		private UserSingleton() {}

		public static UserSingleton Instance
		{
			get 
			{
				if (instance == null)
				{
					instance = new UserSingleton();
				}
				return instance;
			}
		}
	}
}

