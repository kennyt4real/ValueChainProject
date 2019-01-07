namespace ValueChain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDTIDataTypeToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OffTakers", "DTI", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OffTakers", "DTI", c => c.Single(nullable: false));
        }
    }
}
