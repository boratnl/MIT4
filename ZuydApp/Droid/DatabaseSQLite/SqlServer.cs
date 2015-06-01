using System;
using System.Data.SqlClient;

namespace ZuydApp.Droid
{
	public class SqlServer
	{
		public SqlServer ()
		{
		}

		public void getConnection()
		{
			SqlConnection con = new SqlConnection("Server=pdb14.awardspace.net;Database=1670359_darts;Password=ammi11amkreutz;Username=1670359_darts");
			con.Open();
			SqlCommand cmd = new SqlCommand("SELECT Id FROM Nieuws",con);
			//int time = con.ConnectionTimeout;
			//time = 30;
			int i = cmd.ExecuteNonQuery();
			if (i > 0)
			{
				String txt = "record save!";
			}
			else
			{
				
			}
			con.Close();
		}
	}
}