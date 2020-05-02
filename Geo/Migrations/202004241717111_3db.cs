namespace Geo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nameof = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Level = c.Int(nullable: false),
                        BuildingId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        PointId = c.Int(nullable: false, identity: true),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                        FloorId = c.Int(),
                        Point_PointId = c.Int(),
                    })
                .PrimaryKey(t => t.PointId)
                .ForeignKey("dbo.Floors", t => t.FloorId)
                .ForeignKey("dbo.Points", t => t.Point_PointId)
                .Index(t => t.FloorId)
                .Index(t => t.Point_PointId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Points", "Point_PointId", "dbo.Points");
            DropForeignKey("dbo.Points", "FloorId", "dbo.Floors");
            DropForeignKey("dbo.Floors", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Points", new[] { "Point_PointId" });
            DropIndex("dbo.Points", new[] { "FloorId" });
            DropIndex("dbo.Floors", new[] { "BuildingId" });
            DropTable("dbo.Points");
            DropTable("dbo.Floors");
            DropTable("dbo.Buildings");
        }
    }
}
