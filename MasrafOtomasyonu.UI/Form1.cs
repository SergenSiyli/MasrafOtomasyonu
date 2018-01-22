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
    public partial class Form1 : Form
    {
        PersonelRepository pr = new PersonelRepository();
     
        public Form1()
        {
            InitializeComponent();
        }

        private void girisbutonu_Click(object sender, EventArgs e)
        {
            Personeller p = new Personeller();
            string kullaniciadi = kaditxt.Text;
            string sifre = ksifretxt.Text;
            int kullaniciıd = pr.kullanicigirisi(kullaniciadi, sifre);
            if (kullaniciıd == 1 || kullaniciıd == 2 || kullaniciıd== 3 || kullaniciıd == 4)
            {
                if (kullaniciıd == 1)
                {
                    YoneticiArayuzu ya = new YoneticiArayuzu();
                    ya.label5.Text = kullaniciadi.ToString();
                    ya.Show();
                    this.Hide();
                }
               
                if (kullaniciıd == 2)
                {
                    CalisanFormu cf = new CalisanFormu();
                    cf.label6.Text = kullaniciadi.ToString();
                    cf.Show();
                    
                    this.Hide();
                }
                if (kullaniciıd == 3)
                {
                    MuhasebeciArayuzu ma = new MuhasebeciArayuzu();
                    ma.label3.Text = kullaniciadi.ToString();
                    ma.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre Girişi");
                temizle();
            }

        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void temizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tx = (TextBox)item;
                    tx.Clear();
                }
            }
        }
    }
}
