using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerProje.Class;

namespace SerProje
{
    public partial class FrmEgitimBilgisiEkle : Form
    {
        public FrmEgitimBilgisiEkle()
        {
            InitializeComponent();
        }

        private void FrmEgitimBilgisiEkle_Load(object sender, EventArgs e)
        {
            /*cbState.DataSource = Enum.GetNames(typeof(caseState));
            cmb_Okul_Turu.DataSource = Enum.GetNames(typeof(OkulTurleri));*/
            cmb_Okul_Turu.DataSource = Enum.GetValues(typeof(Enums.OkulTurleri));
        }
    }
}
