using System;
using DbApp.Data;
using Gms.Migrations;

namespace DbApp.Migrations
{
	// this config class has to be in same namespace as migrations !!
	public class Configuration : GmsMigrationsConfiguration<ThingContextWithMigrations>
	{
	}
}