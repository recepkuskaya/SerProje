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
        public FrmKisiEkle()
        {
            InitializeComponent();
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

                BagliKisiler bagliKisi = new BagliKisiler
                {
                    Ust_kisi_id = Bagli_Oldugu_Kisi_id_,
                    Ast_kisi_id = kisiBilgisi.id
                };
                unitOfWork.ParentKisiRepository.Insert(bagliKisi);

                unitOfWork.Save();

                MessageBox.Show(kisiBilgisi.id.ToString()); //son eklenen kaydın id si gelmesi gerek.
                lbl_KayitNo.Text = kisiBilgisi.id.ToString();
                lbl_KayitNo.Visible = true;

                AlanlariTemizle();
            }
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
    }
}
