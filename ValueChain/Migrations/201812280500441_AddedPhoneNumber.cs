namespace ValueChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OffTakers", "PhoneNumber", c => c.String());
            AddColumn("dbo.OffTakers", "LoanApplicable", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.OffTakers", "LoanAffordable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OffTakers", "LoanAffordable", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.OffTakers", "LoanApplicable");
            DropColumn("dbo.OffTakers", "PhoneNumber");
        }
    }
}
