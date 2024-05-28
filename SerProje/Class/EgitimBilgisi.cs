using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerProje.Class
{
    public class EgitimBilgisi
    {
        private int KisiId_;
        private string OkulTuru_;
        private string OkulAdi_;
        private string OkulIl_;
        private string OkulIlce_;
        private int KayitYil_;
        private int MezuniyetYil_;

        public int Kisi_Id
        {
            get { return KisiId_; }
            set { KisiId_ = value; }
        }

        public string Okul_Turu
        {
            get { return OkulTuru_; }
            set { OkulTuru_ = value; }
        }

        public string Okul_Adi
        {
            get { return OkulAdi_; }
            set { OkulAdi_ = value; }
        }

        public string Okul_Il
        {
            get { return OkulIl_; }
            set { OkulIl_ = value; }
        }

        public string Okul_Ilce
        {
            get { return OkulIlce_; }
            set { OkulIlce_ = value; }
        }

        public int Kayit_Yil
        { 
            get { return KayitYil_; }
            set { KayitYil_ = value; }
        }

        public int Mezuniyet_Yil
        {
            get { return MezuniyetYil_; }
            set { MezuniyetYil_ = value; }
        }
    }
}
