using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerProje.Class;

namespace SerProje.ContextSer
{
    public class SerDbContext
    {
        public DbSet<KisiBilgisi> KisiBilgileri { get; set; }
        public DbSet<EgitimBilgisi> EgitimBilgileri { get; set; }
        public DbSet<SonOkul> SonOkulBilgileri { get; set; }
        public DbSet<ParentKisi> ParentKisiler { get; set; }
    }
}
