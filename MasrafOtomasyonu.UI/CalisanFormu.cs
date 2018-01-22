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
    public partial class CalisanFormu : Form
    {
        PersonelRepository pr = new PersonelRepository();
        MasrafRepository mr = new MasrafRepository();

        string[] uyeler = {"sergensiyli","ozkanad","tunatan","calisandeneme"};

        public CalisanFormu()
        {
            InitializeComponent();
        }

        private void kaydetbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(basliktxt.Text) && !String.IsNullOrEmpty(aciklamatxt.Text))
                {


                    string kullaniciadi = label6.Text;
                    if (kullaniciadi == uyeler[0])
                    {
                        Masraflar m = new Masraflar();
                        m.PersonelID = 2;
                        m.Tarih = tarihdatetimepicker.Value;
                        m.Baslik = basliktxt.Text;
                        m.Tutar = tutarnumericup.Text;
                        m.Aciklama = aciklamatxt.Text;
                        mr.Ekle(m);
                        Temizle(this);
                        VerileriGetir();
                    }
                    if (kullaniciadi == uyeler[1])
                    {
                        Masraflar m = new Masraflar();
                        m.PersonelID = 3;
                        m.Tarih = tarihdatetimepicker.Value;
                        m.Baslik = basliktxt.Text;
                        m.Tutar = tutarnumericup.Text;
                        m.Aciklama = aciklamatxt.Text;
                        mr.Ekle(m);
                        Temizle(this);
                        VerileriGetir();
                    }
                    if (kullaniciadi == uyeler[2])
                    {
                        Masraflar m = new Masraflar();
                        m.PersonelID = 4;
                        m.Tarih = tarihdatetimepicker.Value;
                        m.Baslik = basliktxt.Text;
                        m.Tutar = tutarnumericup.Text;
                        m.Aciklama = aciklamatxt.Text;
                        mr.Ekle(m);
                        Temizle(this);
                        VerileriGetir();
                    }
                    if (kullaniciadi == uyeler[3])
                    {
                        Masraflar m = new Masraflar();
                        m.PersonelID = 5;
                        m.Tarih = tarihdatetimepicker.Value;
                        m.Baslik = basliktxt.Text;
                        m.Tutar = tutarnumericup.Text;
                        m.Aciklama = aciklamatxt.Text;
                        mr.Ekle(m);
                        Temizle(this);
                        VerileriGetir();
                    }

                }
                else
                {
                    MessageBox.Show("Bu alanları boş bırakmayınız.");
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void VerileriGetir()
        {

            string kullaniciadi = label6.Text;
            masrafdatagrid.DataSource = mr.Getir(kullaniciadi).ToList();
            masrafdatagrid.Columns[0].Visible = false;
            masrafdatagrid.Columns[5].Visible = false;
            masrafdatagrid.Columns[6].Visible = false;



        }

        private void Temizle(Control ctl)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tx = (TextBox)item;
                    tx.Clear();
                }
                if (item is DateTimePicker)
                {
                    DateTimePicker dt = (DateTimePicker)item;
                    dt.Value = DateTime.Now;
                }
                if (item is PictureBox)
                {
                    PictureBox px = (PictureBox)item;
                    px.Image = null;
                }
                if (item.Controls.Count > 0)
                {
                    Temizle(item);
                }
            }
        }

        private void CalisanFormu_Load(object sender, EventArgs e)
        {
            VerileriGetir();
        }
    }
}
