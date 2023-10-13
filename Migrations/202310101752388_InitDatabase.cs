namespace PizzeriaNana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clienti",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                        Cognome = c.String(maxLength: 50),
                        Indirizzo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.Ordini",
                c => new
                    {
                        IdOrdine = c.Int(nullable: false, identity: true),
                        DataOrdine = c.DateTime(),
                        Importo = c.Decimal(storeType: "money"),
                        Indirizzo = c.String(maxLength: 50),
                        Nota = c.String(maxLength: 50),
                        IdCliente = c.Int(),
                    })
                .PrimaryKey(t => t.IdOrdine)
                .ForeignKey("dbo.Clienti", t => t.IdCliente)
                .Index(t => t.IdCliente);
            
            CreateTable(
                "dbo.DettaglioOrdini",
                c => new
                    {
                        IdDettaglio = c.Int(nullable: false, identity: true),
                        IdProdotto = c.Int(),
                        Quantità = c.Int(),
                        IdOrdine = c.Int(),
                    })
                .PrimaryKey(t => t.IdDettaglio)
                .ForeignKey("dbo.Ordini", t => t.IdOrdine)
                .ForeignKey("dbo.Prodotti", t => t.IdProdotto)
                .Index(t => t.IdProdotto)
                .Index(t => t.IdOrdine);
            
            CreateTable(
                "dbo.Prodotti",
                c => new
                    {
                        IdProdotto = c.Int(nullable: false, identity: true),
                        NomeP = c.String(maxLength: 50),
                        Costo = c.Decimal(storeType: "money"),
                        TempoConsegna = c.String(maxLength: 50),
                        Ingredienti = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdProdotto);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Role = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DettaglioOrdini", "IdProdotto", "dbo.Prodotti");
            DropForeignKey("dbo.DettaglioOrdini", "IdOrdine", "dbo.Ordini");
            DropForeignKey("dbo.Ordini", "IdCliente", "dbo.Clienti");
            DropIndex("dbo.DettaglioOrdini", new[] { "IdOrdine" });
            DropIndex("dbo.DettaglioOrdini", new[] { "IdProdotto" });
            DropIndex("dbo.Ordini", new[] { "IdCliente" });
            DropTable("dbo.User");
            DropTable("dbo.Prodotti");
            DropTable("dbo.DettaglioOrdini");
            DropTable("dbo.Ordini");
            DropTable("dbo.Clienti");
        }
    }
}
