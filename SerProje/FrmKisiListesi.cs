using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerProje
{
    public partial class FrmKisiListesi : Form
    {
        public FrmKisiListesi()
        {
            InitializeComponent();
        }

        private void yeniKişiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKisiEkle kisiEkle = new FrmKisiEkle();
            kisiEkle.ShowDialog();
        }

        private void eğitimBilgisiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEgitimBilgisiEkle egitimBilgisiEkle = new FrmEgitimBilgisiEkle();
            egitimBilgisiEkle.ShowDialog();
        }
    }
}
