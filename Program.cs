using System;
using DbApp.Data;
using Gms.Config;

namespace x
{
	class MainClass
	{
		public static void Main( string [] args )
		{
			AppConfig.ProjectFolder( true );
			ThingContext.WithMigrations = false;
			ThingContext.DumpDB();
			Console.WriteLine( "Hello World!" );
		}
	}
}
