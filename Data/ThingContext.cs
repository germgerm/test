using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Gms.Data;

namespace DbApp.Data
{
	public class ThingContextWithMigrations : ThingContext
	{
		static ThingContextWithMigrations(){
			Console.WriteLine( "ThingContextWithMigrations" );
			Database.SetInitializer<ThingContextWithMigrations>( new WithMigrationsInitializer<ThingContextWithMigrations, Migrations.Configuration>() );	
		}
	}

	public class ThingContextWithoutMigrations : ThingContext
	{
		static ThingContextWithoutMigrations(){
			Console.WriteLine( "ThingContextWithoutMigrations" );
			Database.SetInitializer<ThingContextWithoutMigrations>( new WithoutMigrationsInitializer<ThingContextWithoutMigrations>() );	
		}
	}

	public class ThingContext : GmsDbContext<ThingContext,ThingContextWithMigrations,ThingContextWithoutMigrations>
	{
		public DbSet<Thing1> Thing1s { get; set; }

		public static void DropDB() {
			using( var db = NewContext() ) {
				db.Database.Delete();
			}
		}
		public static void InitDB() {
			using( var db = NewContext() ) {
				db.Database.Delete();
				db.Database.Initialize( true );
			}
		}
		public static void DumpDB() {
			using( var db = NewContext() ) {
				foreach( var t1 in db.Thing1s )
					Console.WriteLine( t1 );
			}
		}
		public override void Seed(IEnumerable<string> PendingMigrations)
		{
			base.Seed(PendingMigrations);

			if ( MigrationPending( "InitialCreate" ) ) {
				Console.WriteLine( "{0}.Seed();", this.GetType().Name );
				Thing1s.AddOrUpdate(
					new Thing1() {
						Name = "1" ,
					},
					new Thing1() {
						Name = "2"
					}
				);

			}
		}

	}

}

