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
    public partial class FrmEgitimBilgisiEkle : Form
    {

        private EgitimBilgileri EgitimBilgisi_;
        public FrmEgitimBilgisiEkle(EgitimBilgileri egitimBilgileri)
        {
            InitializeComponent();

            EgitimBilgisi_ = egitimBilgileri;
            if (egitimBilgileri != null)
                EgitimBilgileriYukle();
        }

        public int Kisi_id_;

        string Okul_Turu_, Okul_Adi_, Okul_il_, Okul_ilce_, Kayit_Yil_, Mezuniyet_Yil_ = "";


        private void EgitimBilgileriYukle()
        {
            cmb_Okul_Turu.SelectedItem = EgitimBilgisi_.Okul_Turu;
            txt_Okul_Adi.Text = EgitimBilgisi_.Okul_Adi;
            txt_Okul_Il.Text = EgitimBilgisi_.Okul_il;
            txt_Okul_Ilce.Text = EgitimBilgisi_.Okul_ilce;
            mskTxt_Kayit_Yil.Text = EgitimBilgisi_.Kayit_Yil;
            mskTxt_Mezuniyet_Yil.Text = EgitimBilgisi_.Mezuniyet_Yil;

            lblEgitim_id.Text = EgitimBilgisi_.id.ToString();
            lblKisiNo.Text = EgitimBilgisi_.Kisi_id.ToString();
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            int _id = Convert.ToInt32(lblEgitim_id.Text);

            if (_id > 0)
            {
                using (SerUnitOfWork unitOfWork = new SerUnitOfWork())
                {
                    var entityToDelete = unitOfWork.EgitimBilgisiRepository.GetById(_id); // Silinecek kayıt
                    if (entityToDelete != null)
                    {
                        unitOfWork.EgitimBilgisiRepository.Delete(entityToDelete);
                        unitOfWork.Save();

                        MessageBox.Show(_id + " ID'li Kayıt Silinmiştir.");
                    }
                }
            }

            this.Close();
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            Okul_Turu_ = cmb_Okul_Turu.SelectedItem.ToString();
            Okul_Adi_ = txt_Okul_Adi.Text.Trim();
            Okul_il_ = txt_Okul_Il.Text.Trim();
            Okul_ilce_ = txt_Okul_Ilce.Text.Trim();
            Kayit_Yil_ = mskTxt_Kayit_Yil.Text.Trim();
            Mezuniyet_Yil_ = mskTxt_Mezuniyet_Yil.Text.Trim();

            int _id = Convert.ToInt32(lblEgitim_id.Text);

            using (SerUnitOfWork unitOfWork = new SerUnitOfWork())
            {
                var egtmBilgisi_ = unitOfWork.EgitimBilgisiRepository.GetById(_id);

                if (egtmBilgisi_ != null)
                {
                    // Bilgileri güncelleyin
                    egtmBilgisi_.Okul_Turu = Okul_Turu_;
                    egtmBilgisi_.Okul_Adi = Okul_Adi_;
                    egtmBilgisi_.Okul_il = Okul_il_;
                    egtmBilgisi_.Okul_ilce = Okul_ilce_;
                    egtmBilgisi_.Kayit_Yil = Kayit_Yil_;
                    egtmBilgisi_.Mezuniyet_Yil = Mezuniyet_Yil_;

                    unitOfWork.EgitimBilgisiRepository.Update(egtmBilgisi_);
                    unitOfWork.Save();

                }

            }

            this.Close();
        }

        SerProjeDB context = new SerProjeDB();

        private void FrmEgitimBilgisiEkle_Load(object sender, EventArgs e)
        {
            /*cbState.DataSource = Enum.GetNames(typeof(caseState));
            cmb_Okul_Turu.DataSource = Enum.GetNames(typeof(OkulTurleri));*/
            cmb_Okul_Turu.DataSource = Enum.GetValues(typeof(Enums.OkulTurleri));

            lblKisiNo.Text = Kisi_id_.ToString();
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            Okul_Turu_ = cmb_Okul_Turu.SelectedItem.ToString();
            Okul_Adi_ = txt_Okul_Adi.Text.Trim();
            Okul_il_ = txt_Okul_Il.Text.Trim();
            Okul_ilce_ = txt_Okul_Ilce.Text.Trim();
            Kayit_Yil_ = mskTxt_Kayit_Yil.Text.Trim();
            Mezuniyet_Yil_ = mskTxt_Mezuniyet_Yil.Text.Trim();

            if(Kisi_id_ == 0)
            {
                MessageBox.Show("Kişi Seçilmeden Eğitim Bilgisi Ekleyemezsiniz!");
                return;
            }

            

            using (SerUnitOfWork unitOfWork = new SerUnitOfWork())
            {
                EgitimBilgileri egitimBilgisi = new EgitimBilgileri
                {
                    Kisi_id = Kisi_id_,
                    Okul_Turu = Okul_Turu_,
                    Okul_Adi = Okul_Adi_,
                    Okul_il = Okul_il_,
                    Okul_ilce = Okul_ilce_,
                    Kayit_Yil = Kayit_Yil_,
                    Mezuniyet_Yil = Mezuniyet_Yil_
                };


                //Tüm kişiler baz alınacak ise kişi id şartını kaldır.
                if (context.EgitimBilgileri.Where(x => x.Kisi_id == egitimBilgisi.Kisi_id).Any(a => a.Okul_il == egitimBilgisi.Okul_il))
                {
                    MessageBox.Show("Aynı Şehirden Eğitim Bilgisi Ekleyemezsiniz!");
                    return;
                }

                unitOfWork.EgitimBilgisiRepository.Insert(egitimBilgisi);

                //int _mezuniyet_yil = Convert.ToInt32(context.EgitimBilgileri.Max(a => a.Mezuniyet_Yil));
                int _mezuniyet_yil = Convert.ToInt32(context.EgitimBilgileri.Where(a => a.Kisi_id == Kisi_id_).Max(p => p.Mezuniyet_Yil));

                if (Convert.ToInt32(Mezuniyet_Yil_) > _mezuniyet_yil)
                {
                    int egitim_id = egitimBilgisi.id;
                    SonEgitimBilgisi sonEgitim = new SonEgitimBilgisi
                    {
                        Kisi_id = Kisi_id_,
                        Okul_id = egitim_id
                    };
                    unitOfWork.SonOkulRepository.Insert(sonEgitim);


                    if(_mezuniyet_yil > 0)
                    {
                        //Son eğitim tablosundan eski olan mezuniyet silinecek.
                        int son_egitim_bilgisi = Convert.ToInt32(unitOfWork.SonOkulRepository.Select(a => a.Kisi_id == Kisi_id_).Max(p => p.id));

                        var entityToDelete = unitOfWork.SonOkulRepository.GetById(son_egitim_bilgisi); // Silinecek kayıt
                        if (entityToDelete != null)
                        {
                            unitOfWork.SonOkulRepository.Delete(entityToDelete);
                        }
                    }
                    

                }

                unitOfWork.Save();
            }


            AlanlariTemizle();
        }

        private void AlanlariTemizle()
        {
            cmb_Okul_Turu.SelectedIndex = 0;
            txt_Okul_Adi.Text = "";
            txt_Okul_Il.Text = "";
            txt_Okul_Ilce.Text = "";
            mskTxt_Kayit_Yil.Text = "";
            mskTxt_Mezuniyet_Yil.Text = "";

            cmb_Okul_Turu.Focus();
        }
    }
}
