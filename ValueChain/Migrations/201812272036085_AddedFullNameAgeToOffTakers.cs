namespace ValueChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFullNameAgeToOffTakers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OffTakers", "FullName", c => c.String());
            AddColumn("dbo.OffTakers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.OffTakers", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OffTakers", "PhoneNumber");
            DropColumn("dbo.OffTakers", "Age");
            DropColumn("dbo.OffTakers", "FullName");
        }
    }
}
