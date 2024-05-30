namespace SerProje.NewClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BagliKisiler")]
    public partial class BagliKisiler
    {
        public int id { get; set; }

        public int? Ust_kisi_id { get; set; }

        public int? Ast_kisi_id { get; set; }

        public virtual KisiBilgileri KisiBilgileri { get; set; }

        public virtual KisiBilgileri KisiBilgileri1 { get; set; }

    }
}
