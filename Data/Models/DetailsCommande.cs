namespace Tirelires
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetailsCommande")]
    public partial class DetailsCommande
    {
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int IdCommande { get; set; }

        [Column(TypeName = "int")]
        public int IdProduit { get; set; }

        public double Prix { get; set; }

        public short Quantite { get; set; }

        public virtual Commande Commande { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
