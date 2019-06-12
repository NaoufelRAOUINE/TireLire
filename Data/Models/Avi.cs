namespace Tirelires
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Avi
    {
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int IdClient { get; set; }

        [Column(TypeName = "int")]
        public int IdProduit { get; set; }

        public DateTime? Date { get; set; }

        public bool IsPublished { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        public int Note { get; set; }

        public virtual Client Client { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
