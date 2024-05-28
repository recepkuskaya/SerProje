using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SerProje.Class;
using SerProje.Model;

namespace SerProje.Data.Context
{
    public class EFSerProjeContext : DbContext
    {
        /*public EFBlogContext() : base("SerProjeContext")
        {
        }*/

        public DbSet<KisiBilgisi> KisiBilgileri { get; set; }
        public DbSet<EgitimBilgisi> EgitimBilgileri { get; set; }
        public DbSet<ParentKisi> BagliKisiBilgileri { get; set; }
        public DbSet<SonOkul> MezunSonOkulBilgisi { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // İlişkileri kuruyoruz one-to-many olarak.
            /*modelBuilder.Entity<KisiBilgisi>()
                .HasRequired<EgitimBilgisi>(x => x.Id)
                .WithMany(x => x.Kisi_Id)
                .HasForeignKey(x => x.Id);*/

            /*modelBuilder.Entity<Article>()
                .HasRequired<User>(x => x.User)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.UserId);*/

            base.OnModelCreating(modelBuilder);
        }
    }
}
