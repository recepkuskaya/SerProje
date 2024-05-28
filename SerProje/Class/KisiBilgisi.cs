using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerProje.Class
{
    public class KisiBilgisi
    {
        private string TcKimlikNo_;
        private string Adi_;
        private string Soyadi_;
        private string TelefonNo_;
        private int BagliKisiNo_;
        private byte IsParent_;


        public string TcKimlikNo
        {
            get { return TcKimlikNo_; }
            set { TcKimlikNo_= value; }
        }

        public string Adi
        {
            get { return Adi_; }
            set { Adi_ = value; }
        }

        public string Soyadi
        {
            get { return Soyadi_; }
            set { Soyadi_ = value; }
        }

        public string TelefonNo
        {
            get { return TelefonNo_; }
            set { TelefonNo_ = value; }
        }

        public int BagliOlduguKisiNo
        {
            get { return BagliKisiNo_; }
            set { BagliKisiNo_ = value; }
        }

        public byte IsParent
        {
            get { return IsParent_; }
            set { IsParent_ = value; }
        }
        
    }
}
