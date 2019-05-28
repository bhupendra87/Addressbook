namespace AddressBook.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialAddressBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phonedirectories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Phonedirectories");
        }
    }
}
