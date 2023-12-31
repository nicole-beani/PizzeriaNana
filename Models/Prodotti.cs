namespace PizzeriaNana.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodotti")]
    public partial class Prodotti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodotti()
        {
            DettaglioOrdini = new HashSet<DettaglioOrdini>();
        }

        [Key]
        public int IdProdotto { get; set; }

        [StringLength(50)]
        [Display(Name = "Nome della pizza:")]
        public string NomeP { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Prezzo:")]
        public decimal? Costo { get; set; }

        [StringLength(50)]
        [Display(Name = "Tempo di consegna stimata:")]
        public string TempoConsegna { get; set; }

        [StringLength(50)]
        public string Ingredienti { get; set; }
        public string Foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DettaglioOrdini> DettaglioOrdini { get; set; }
    }
}
