namespace AddressBook.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableUserLogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phonedirectories", "UserLogin_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Phonedirectories", "UserLogin_UserName", c => c.String());
            AddColumn("dbo.Phonedirectories", "UserLogin_UserPwd", c => c.String());
            AddColumn("dbo.Phonedirectories", "UserLogin_UserEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phonedirectories", "UserLogin_UserEmail");
            DropColumn("dbo.Phonedirectories", "UserLogin_UserPwd");
            DropColumn("dbo.Phonedirectories", "UserLogin_UserName");
            DropColumn("dbo.Phonedirectories", "UserLogin_UserId");
        }
    }
}
