using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using SerProje.NewClasses;

namespace SerProje
{
    public partial class SerProjeDB : DbContext
    {
        public SerProjeDB()
            : base("name=SerProjeDBNew")
        {
        }

        public virtual DbSet<BagliKisiler> BagliKisiler { get; set; }
        public virtual DbSet<EgitimBilgileri> EgitimBilgileri { get; set; }
        public virtual DbSet<KisiBilgileri> KisiBilgileri { get; set; }
        public virtual DbSet<SonEgitimBilgisi> SonEgitimBilgisi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EgitimBilgileri>()
                .HasMany(e => e.SonEgitimBilgisi)
                .WithOptional(e => e.EgitimBilgileri)
                .HasForeignKey(e => e.Okul_id);

            /*modelBuilder.Entity<KisiBilgileri>()
                .HasMany(e => e.BagliKisiler)
                .WithOptional(e => e.KisiBilgileri)
                .HasForeignKey(e => e.Ast_kisi_id);

            modelBuilder.Entity<KisiBilgileri>()
                .HasMany(e => e.BagliKisiler1)
                .WithOptional(e => e.KisiBilgileri1)
                .HasForeignKey(e => e.Ust_kisi_id);*/

            modelBuilder.Entity<KisiBilgileri>()
                .HasMany(e => e.EgitimBilgileri)
                .WithOptional(e => e.KisiBilgileri)
                .HasForeignKey(e => e.Kisi_id);

            modelBuilder.Entity<KisiBilgileri>()
                .HasMany(e => e.SonEgitimBilgisi)
                .WithOptional(e => e.KisiBilgileri)
                .HasForeignKey(e => e.Kisi_id);
        }
    }
}
