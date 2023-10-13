namespace PizzeriaNana.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordini()
        {
            DettaglioOrdini = new HashSet<DettaglioOrdini>();
        }

        [Key]
        public int IdOrdine { get; set; }
        [Display(Name = "Per quando la vuoi ordinare? -> gg/mm/dd")]
        public DateTime? DataOrdine { get; set; }

        [Column(TypeName = "money")]
        public decimal? Importo { get; set; }

        [StringLength(50)]

        public string Indirizzo { get; set; }

        [StringLength(50)]
        public string Nota { get; set; }
        [Display(Name = "Inserisci il tuo Nome")]
        public int? IdCliente { get; set; }

        public virtual Clienti Clienti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DettaglioOrdini> DettaglioOrdini { get; set; }
    }
}
