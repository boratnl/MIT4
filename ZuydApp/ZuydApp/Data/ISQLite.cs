using System;
using SQLite;

namespace ZuydApp
{
	public interface ISQLite
	{
		SQLiteConnection getConnection();
	}
}

