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
            using(SerUnitOfWork unitOfWork = new SerUnitOfWork())
            {
                KisiBilgileri kisiBilgisi = new KisiBilgileri
                {
                    //id = 1,
                    Adi = "Recep2",
                    Soyadi = "Kuşkaya2",
                    Tc_Kimlik_No = "51994471246",
                    Telefon_No = "5063532346"
                };
                unitOfWork.KisiBilgisiRepository.Insert(kisiBilgisi);
                unitOfWork.Save();

                MessageBox.Show(kisiBilgisi.id.ToString()); //son eklenen kaydın id si gelmesi gerek.
            }
        }
    }
}
