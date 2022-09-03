namespace NAZCON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addpagestablewithrelationofroles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RolePages",
                c => new
                    {
                        Role_Id = c.String(nullable: false, maxLength: 128),
                        Page_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Page_Id })
                .ForeignKey("dbo.AspNetRoles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pages", t => t.Page_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Page_Id);
            
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolePages", "Page_Id", "dbo.Pages");
            DropForeignKey("dbo.RolePages", "Role_Id", "dbo.AspNetRoles");
            DropIndex("dbo.RolePages", new[] { "Page_Id" });
            DropIndex("dbo.RolePages", new[] { "Role_Id" });
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropTable("dbo.RolePages");
            DropTable("dbo.Pages");
        }
    }
}
