namespace PizzeriaNana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prodotti", "Foto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prodotti", "Foto");
        }
    }
}
