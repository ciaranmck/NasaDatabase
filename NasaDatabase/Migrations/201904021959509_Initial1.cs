namespace NasaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fireballs", "Energy", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Fireballs", "ImpactE", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Fireballs", "LatDir", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Fireballs", "Lon", c => c.String());
            AddColumn("dbo.Fireballs", "LonDir", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Fireballs", "Alt", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Fireballs", "Vel", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Fireballs", "Lng");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fireballs", "Lng", c => c.String());
            DropColumn("dbo.Fireballs", "Vel");
            DropColumn("dbo.Fireballs", "Alt");
            DropColumn("dbo.Fireballs", "LonDir");
            DropColumn("dbo.Fireballs", "Lon");
            DropColumn("dbo.Fireballs", "LatDir");
            DropColumn("dbo.Fireballs", "ImpactE");
            DropColumn("dbo.Fireballs", "Energy");
        }
    }
}
