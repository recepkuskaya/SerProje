namespace SerProje.NewClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KisiBilgileri")]
    public partial class KisiBilgileri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KisiBilgileri()
        {
            //BagliKisiler = new HashSet<BagliKisiler>();
            //BagliKisiler1 = new HashSet<BagliKisiler>();
            EgitimBilgileri = new HashSet<EgitimBilgileri>();
            SonEgitimBilgisi = new HashSet<SonEgitimBilgisi>();
        }

        public int id { get; set; }

        [StringLength(11)]
        public string Tc_Kimlik_No { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }

        [StringLength(20)]
        public string Telefon_No { get; set; }

        public int? Bagli_Oldugu_Kisi_id { get; set; }

        public bool? IsParent { get; set; }

        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BagliKisiler> BagliKisiler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BagliKisiler> BagliKisiler1 { get; set; }*/

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EgitimBilgileri> EgitimBilgileri { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SonEgitimBilgisi> SonEgitimBilgisi { get; set; }
    }
}
