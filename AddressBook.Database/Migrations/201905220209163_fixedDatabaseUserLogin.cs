namespace AddressBook.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedDatabaseUserLogin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPwd = c.String(),
                        UserEmail = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AlterColumn("dbo.Phonedirectories", "UserLogin_UserId", c => c.Int());
            CreateIndex("dbo.Phonedirectories", "UserLogin_UserId");
            AddForeignKey("dbo.Phonedirectories", "UserLogin_UserId", "dbo.UserLogins", "UserId");
            DropColumn("dbo.Phonedirectories", "UserLogin_UserName");
            DropColumn("dbo.Phonedirectories", "UserLogin_UserPwd");
            DropColumn("dbo.Phonedirectories", "UserLogin_UserEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phonedirectories", "UserLogin_UserEmail", c => c.String());
            AddColumn("dbo.Phonedirectories", "UserLogin_UserPwd", c => c.String());
            AddColumn("dbo.Phonedirectories", "UserLogin_UserName", c => c.String());
            DropForeignKey("dbo.Phonedirectories", "UserLogin_UserId", "dbo.UserLogins");
            DropIndex("dbo.Phonedirectories", new[] { "UserLogin_UserId" });
            AlterColumn("dbo.Phonedirectories", "UserLogin_UserId", c => c.Int(nullable: false));
            DropTable("dbo.UserLogins");
        }
    }
}
