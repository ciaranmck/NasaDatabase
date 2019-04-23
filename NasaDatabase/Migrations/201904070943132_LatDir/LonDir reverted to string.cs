namespace NasaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LatDirLonDirrevertedtostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fireballs", "Lat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Fireballs", "LatDir", c => c.String());
            AlterColumn("dbo.Fireballs", "Lon", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Fireballs", "LonDir", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fireballs", "LonDir", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Fireballs", "Lon", c => c.String());
            AlterColumn("dbo.Fireballs", "LatDir", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Fireballs", "Lat", c => c.String());
        }
    }
}
