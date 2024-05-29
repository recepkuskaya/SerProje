namespace SerProje.NewClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SonEgitimBilgisi")]
    public partial class SonEgitimBilgisi
    {
        public int id { get; set; }

        public int? Kisi_id { get; set; }

        public int? Okul_id { get; set; }

        public virtual EgitimBilgileri EgitimBilgileri { get; set; }

        public virtual KisiBilgileri KisiBilgileri { get; set; }
    }
}
