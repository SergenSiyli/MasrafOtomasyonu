using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MasrafOtomasyonu.BLL;
using MasrafOtomasyonu.DAL;

namespace MasrafOtomasyonu.UI
{
    public partial class YoneticiArayuzu : Form
    {
        MasrafHesaplamaDbEntities db = new MasrafHesaplamaDbEntities();
        PersonelRepository pr=new PersonelRepository();


        public YoneticiArayuzu()
        {
            InitializeComponent();
        }

        private void YoneticiArayuzu_Load(object sender, EventArgs e)
        {
            VerileriGetir();
        }

        private void VerileriGetir()
        {
            var q = (from ms in db.Masraflar
                     join p in db.Personeller on ms.PersonelID equals p.PersonelID

                     select new
                     {
                         PersonelAdı=p.PersonelAdi,
                         PersonelSoyadı=p.PersonelSoyadi,
                         Basligi=ms.Baslik,
                         MasrafTarihi=ms.Tarih,
                         MasrafTutarı=ms.Tutar,
                         MasrafAciklamasi=ms.Aciklama
                     }).ToList();
            calisanlargrid.DataSource = q;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string gelecek = textBox1.Text;

            var q = (from ms in db.Masraflar
                     join p in db.Personeller on ms.PersonelID equals p.PersonelID
                     where p.PersonelAdi == gelecek||p.PersonelSoyadi==gelecek
            select new
            {
                PersonelAdı = p.PersonelAdi,
                PersonelSoyadı = p.PersonelSoyadi,
                Basligi = ms.Baslik,
                MasrafTarihi = ms.Tarih,
                MasrafTutarı = ms.Tutar,
                MasrafAciklamasi = ms.Aciklama
            }).ToList();
            calisanlargrid.DataSource = q;
        }
    }
}
