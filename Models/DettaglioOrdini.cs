namespace PizzeriaNana.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DettaglioOrdini")]
    public partial class DettaglioOrdini
    {
        [Key]
        public int IdDettaglio { get; set; }

        [Display(Name = "Scegli la pizza che vuoi:")]
        public int? IdProdotto { get; set; }

        public int? Quantità { get; set; }

        public int? IdOrdine { get; set; }

        public virtual Ordini Ordini { get; set; }

        public virtual Prodotti Prodotti { get; set; }
    }
}
