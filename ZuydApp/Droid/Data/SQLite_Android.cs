using System;
using System.IO;
using ZuydApp.Droid;

[assembly: Xamarin.Forms.Dependency (typeof(SQLite_Android))]
namespace ZuydApp.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android ()
		{
		}

		public SQLite.SQLiteConnection getConnection ()
		{
			var name = "LoginData.db3";
			string path = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			var realPath = Path.Combine (path, name);

			var conn = new SQLite.SQLiteConnection (realPath);

			return conn;
		}
	}
}

