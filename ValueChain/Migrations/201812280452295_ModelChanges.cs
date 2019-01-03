namespace ValueChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OffTakers", "LoanAffordable", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OffTakers", "DTI", c => c.Single(nullable: false));
            DropColumn("dbo.OffTakers", "PhoneNumber");
            DropColumn("dbo.OffTakers", "LoanApplicable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OffTakers", "LoanApplicable", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OffTakers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.OffTakers", "DTI", c => c.Double(nullable: false));
            DropColumn("dbo.OffTakers", "LoanAffordable");
        }
    }
}
