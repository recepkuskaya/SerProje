namespace SerProje.NewClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EgitimBilgileri")]
    public partial class EgitimBilgileri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EgitimBilgileri()
        {
            SonEgitimBilgisi = new HashSet<SonEgitimBilgisi>();
        }

        public int id { get; set; }

        public int? Kisi_id { get; set; }

        [StringLength(30)]
        public string Okul_Turu { get; set; }

        [StringLength(100)]
        public string Okul_Adi { get; set; }

        [StringLength(50)]
        public string Okul_il { get; set; }

        [StringLength(50)]
        public string Okul_ilce { get; set; }

        [StringLength(4)]
        public string Kayit_Yil { get; set; }

        [StringLength(4)]
        public string Mezuniyet_Yil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SonEgitimBilgisi> SonEgitimBilgisi { get; set; }

        public virtual KisiBilgileri KisiBilgileri { get; set; }
    }
}
