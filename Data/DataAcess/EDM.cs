namespace Tirelires
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EDM : DbContext
    {
        public EDM()
            : base("name=EDM")
        {
            
        }

        public virtual DbSet<Avi> Avis { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<DetailsCommande> DetailsCommandes { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avi>()
                .Property(e => e.Id);
            //.HasPrecision(18, 0);

            modelBuilder.Entity<Avi>()
                .Property(e => e.IdClient);
            //.HasPrecision(18, 0);

            modelBuilder.Entity<Avi>()
                .Property(e => e.IdProduit);
            //.HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .Property(e => e.Id);
                //.HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Ville)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Pays)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Theme)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Avis)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.Id);
            //.HasPrecision(18, 0);

            modelBuilder.Entity<Commande>()
                .Property(e => e.IdClient);
                //.HasPrecision(18, 0);

            modelBuilder.Entity<Commande>()
                .HasMany(e => e.DetailsCommandes)
                .WithRequired(e => e.Commande)
                .HasForeignKey(e => e.IdCommande)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DetailsCommande>()
                .Property(e => e.Id);
            //.HasPrecision(18, 0);

            modelBuilder.Entity<DetailsCommande>()
                .Property(e => e.IdCommande);
            //.HasPrecision(18, 0);

            modelBuilder.Entity<DetailsCommande>()
                .Property(e => e.IdProduit);
            //.HasPrecision(18, 0);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.Id);
                //.HasPrecision(18, 0);

            modelBuilder.Entity<Fournisseur>()
                .HasMany(e => e.Produits)
                .WithRequired(e => e.Fournisseur)
                .HasForeignKey(e => e.IdFournisseur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produit>()
                .Property(e => e.Id);
            //.HasPrecision(18, 0);

            modelBuilder.Entity<Produit>()
                .Property(e => e.IdFournisseur);
                //.HasPrecision(18, 0);

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.Avis)
                .WithRequired(e => e.Produit)
                .HasForeignKey(e => e.IdProduit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produit>()
                .HasMany(e => e.DetailsCommandes)
                .WithRequired(e => e.Produit)
                .HasForeignKey(e => e.IdProduit)
                .WillCascadeOnDelete(false);
        }
    }
}
