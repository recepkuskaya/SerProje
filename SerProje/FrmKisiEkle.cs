using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerProje.UnitOfWork;
using SerProje.NewClasses;
using SerProje.ContextSer;

namespace SerProje
{
    public partial class FrmKisiEkle : Form
    {
        private KisiBilgileri kisiBilgileri_;
        public FrmKisiEkle(KisiBilgileri kisiBilgileri)
        {
            InitializeComponent();

            kisiBilgileri_ = kisiBilgileri;
            if(kisiBilgileri != null)
                KisiVerileriYukle();
        }

        string Tc_Kimlik_No_, Adi_, Soyadi_, Telefon_No_ = "";
        int Bagli_Oldugu_Kisi_id_ = 0;

        private void KisiVerileriYukle()
        {
            mskTxtTcKimlikNo.Text = kisiBilgileri_.Tc_Kimlik_No;
            txtAdi.Text = kisiBilgileri_.Adi;
            txtSoyadi.Text = kisiBilgileri_.Soyadi;
            mskTxtTelefonNo.Text = kisiBilgileri_.Telefon_No;
            if (Convert.ToInt32(kisiBilgileri_.Bagli_Oldugu_Kisi_id) != 0)
                cmb_Parent.SelectedValue = Convert.ToInt32(kisiBilgileri_.Bagli_Oldugu_Kisi_id);
            

            lbl_KayitNo.Text = kisiBilgileri_.id.ToString();
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            string Tc_Kimlik_No_, Adi_, Soyadi_, Telefon_No_ = "";
            int Bagli_Oldugu_Kisi_id_ = 0;
            
            Tc_Kimlik_No_ = mskTxtTcKimlikNo.Text.Trim();
            Adi_ = txtAdi.Text.Trim();
            Soyadi_ = txtSoyadi.Text.Trim();
            Telefon_No_ = mskTxtTelefonNo.Text.Trim();

            if (cmb_Parent.SelectedItem != null)
                Bagli_Oldugu_Kisi_id_ = (int)cmb_Parent.SelectedValue;

            using(SerUnitOfWork unitOfWork = new SerUnitOfWork())
            {
                KisiBilgileri kisiBilgisi = new KisiBilgileri
                {
                    //id = 1,
                    Tc_Kimlik_No = Tc_Kimlik_No_,
                    Adi = Adi_,
                    Soyadi = Soyadi_,
                    Telefon_No = Telefon_No_,
                    Bagli_Oldugu_Kisi_id = Bagli_Oldugu_Kisi_id_
                };
                unitOfWork.KisiBilgisiRepository.Insert(kisiBilgisi);
                unitOfWork.Save();

                MessageBox.Show(kisiBilgisi.id.ToString()); //son eklenen kaydın id si gelmesi gerek.
                lbl_KayitNo.Text = kisiBilgisi.id.ToString();
                lbl_KayitNo.Visible = true;

                AlanlariTemizle();
            }
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            int _id = Convert.ToInt32(lbl_KayitNo.Text);

            if(_id > 0)
            {
                using (SerUnitOfWork unitOfWork = new SerUnitOfWork())
                {
                    //int kisi_ = Convert.ToInt32(unitOfWork.KisiBilgisiRepository.Select(a => a.id == _id).Max(p => p.id));

                    var entityToDelete = unitOfWork.KisiBilgisiRepository.GetById(_id); // Silinecek kayıt
                    if (entityToDelete != null)
                    {
                        unitOfWork.KisiBilgisiRepository.Delete(entityToDelete);
                        unitOfWork.Save();

                        MessageBox.Show(_id + " ID'li Kayıt Silinmiştir.");
                    }
                }
            }

            this.Close();
            
        }

        private void FrmKisiEkle_Load(object sender, EventArgs e)
        {
            SerProjeDB context = new SerProjeDB();
            cmb_Parent.DataSource = context.KisiBilgileri.ToList();
            cmb_Parent.DisplayMember = "Adi";
            cmb_Parent.ValueMember = "id";
        }


        private void AlanlariTemizle()
        {
            mskTxtTcKimlikNo.Text = "";
            txtAdi.Text = "";
            txtSoyadi.Text = "";
            mskTxtTelefonNo.Text = "";

            mskTxtTcKimlikNo.Focus();
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            Tc_Kimlik_No_ = mskTxtTcKimlikNo.Text.Trim();
            Adi_ = txtAdi.Text.Trim();
            Soyadi_ = txtSoyadi.Text.Trim();
            Telefon_No_ = mskTxtTelefonNo.Text.Trim();

            if (cmb_Parent.SelectedItem != null)
                Bagli_Oldugu_Kisi_id_ = (int)cmb_Parent.SelectedValue;


            int kisi_id_ = Convert.ToInt32(lbl_KayitNo.Text);

            using (SerUnitOfWork unitOfWork = new SerUnitOfWork())
            {
                var kisi_ = unitOfWork.KisiBilgisiRepository.GetById(kisi_id_);

                if (kisi_ != null)
                {
                    // Ürünü güncelleyin
                    kisi_.Tc_Kimlik_No = Tc_Kimlik_No_;
                    kisi_.Adi = Adi_;
                    kisi_.Soyadi = Soyadi_;
                    kisi_.Telefon_No = Telefon_No_;
                    kisi_.Bagli_Oldugu_Kisi_id = Convert.ToInt32(cmb_Parent.SelectedValue);

                    unitOfWork.KisiBilgisiRepository.Update(kisi_);
                    unitOfWork.Save();
                    
                }

            }

            this.Close();
        }
    }
}
