using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerProje.NewClasses;
using SerProje.UnitOfWork;

namespace SerProje
{
    public partial class FrmKisiListesi : Form
    {
        public FrmKisiListesi()
        {
            InitializeComponent();
        }

        int kisi_id_;

        private void yeniKişiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKisiEkle kisiEkle = new FrmKisiEkle(null);
            if(kisiEkle.ShowDialog() == DialogResult.Cancel)
            {
                KisiBilgileriDoldur();
            }
        }

        private void eğitimBilgisiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEgitimBilgisiEkle egitimBilgisiEkle = new FrmEgitimBilgisiEkle(null);
            egitimBilgisiEkle.Kisi_id_ = kisi_id_;

            if(egitimBilgisiEkle.ShowDialog() == DialogResult.Cancel)
            {
                KisiBilgileriDoldur();
            }
        }

        private void FrmKisiListesi_Load(object sender, EventArgs e)
        {
            menuStrip1.Items[1].Enabled = false;
            KisiBilgileriDoldur();            
        }

        private void KisiBilgileriDoldur()
        {
            using(SerProjeDB context = new SerProjeDB())
            {
                context.Configuration.LazyLoadingEnabled = false; //verileri çektikten sonra tablolar ile ilgili hatadan dolayı lazy load özelliği devre dışı bırakıldı.
                var data = context.KisiBilgileri.ToList();

                dataGridKisiListesi.DataSource = data;

                dataGridKisiListesi.Columns["IsParent"].Visible = false;
                dataGridKisiListesi.Columns["EgitimBilgileri"].Visible = false;
                dataGridKisiListesi.Columns["SonEgitimBilgisi"].Visible = false;

                dataGridKisiListesi.Columns["id"].HeaderText = "Kişi ID";
                dataGridKisiListesi.Columns["Tc_Kimlik_No"].HeaderText = "T.C. Kimlik No";
                dataGridKisiListesi.Columns["Adi"].HeaderText = "Adı";
                dataGridKisiListesi.Columns["Soyadi"].HeaderText = "Soyadı";
                dataGridKisiListesi.Columns["Telefon_No"].HeaderText = "Telefon No";
                dataGridKisiListesi.Columns["Bagli_Oldugu_Kisi_id"].HeaderText = "Bağlı Olduğu Kişi ID";

            }
        }

        private void dataGridKisiListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var selectedEntity = (KisiBilgileri)dataGridKisiListesi.Rows[e.RowIndex].DataBoundItem;

                // form açılıp kişi bilgileri gönderilir
                var kisiForm = new FrmKisiEkle(selectedEntity);
                kisiForm.ShowDialog();

            }
            
        }

        private void dataGridKisiListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            menuStrip1.Items[1].Enabled = true;

            int selectedrowindex = dataGridKisiListesi.SelectedCells[0].RowIndex;
            DataGridViewRow gridViewRow = dataGridKisiListesi.Rows[selectedrowindex];
            kisi_id_ = Convert.ToInt32(gridViewRow.Cells["id"].Value);

            EgitimBilgileriniDoldur(kisi_id_);
        }

        private void EgitimBilgileriniDoldur(int kisi_id_)
        {
            using (SerProjeDB context = new SerProjeDB())
            {
                context.Configuration.LazyLoadingEnabled = false; //verileri çektikten sonra tablolar ile ilgili hatadan dolayı lazy load özelliği devre dışı bırakıldı.
                var data = context.EgitimBilgileri.Where(a => a.Kisi_id == kisi_id_).ToList();

                dataGridEgitimBilgileri.DataSource = data;

                dataGridEgitimBilgileri.Columns["id"].Visible = false;
                dataGridEgitimBilgileri.Columns["SonEgitimBilgisi"].Visible = false;
                dataGridEgitimBilgileri.Columns["KisiBilgileri"].Visible = false;


                dataGridEgitimBilgileri.Columns["Kisi_id"].HeaderText = "Kişi ID";
                dataGridEgitimBilgileri.Columns["Okul_Turu"].HeaderText = "Okul Türü";
                dataGridEgitimBilgileri.Columns["Okul_Adi"].HeaderText = "Okul Adı";
                dataGridEgitimBilgileri.Columns["Okul_il"].HeaderText = "Okul İl";
                dataGridEgitimBilgileri.Columns["Okul_ilce"].HeaderText = "Okul_ilce";
                dataGridEgitimBilgileri.Columns["Kayit_Yil"].HeaderText = "Kayıt Yıl";
                dataGridEgitimBilgileri.Columns["Mezuniyet_Yil"].HeaderText = "Mezuniyet Yıl";

            }
        }

        private void dataGridEgitimBilgileri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedEntity = (EgitimBilgileri)dataGridEgitimBilgileri.Rows[e.RowIndex].DataBoundItem;

                // form açılıp kişi bilgileri gönderilir
                var kisiForm = new FrmEgitimBilgisiEkle(selectedEntity);
                kisiForm.ShowDialog();

            }
        }
    }
}
