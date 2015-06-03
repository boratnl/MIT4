using System;
using Android.Content;

namespace ZuydApp.Droid
{
	public class LogOut
	{
		public LogOut ()
		{
			
		}
			
		public void DeleteSqlDatabase(Context context)
		{
			context.DeleteDatabase (LoginRepository.db_file);
		}
	}
}

