namespace Tirelires
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produit")]
    public partial class Produit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produit()
        {
            Avis = new HashSet<Avi>();
            DetailsCommandes = new HashSet<DetailsCommande>();
        }

        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Column(TypeName = "int")]
        public int IdFournisseur { get; set; }

        public bool IsActived { get; set; }

        public double Prix { get; set; }

        public int UnitsInStock { get; set; }

        public double? Poids { get; set; }

        [StringLength(50)]
        public string URLImage { get; set; }

        public double? Hauteur { get; set; }

        public double? Largeur { get; set; }

        public double? Longueur { get; set; }

        public short? Capacite { get; set; }

        public short? Couleur { get; set; }

        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avi> Avis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailsCommande> DetailsCommandes { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }
    }
}
