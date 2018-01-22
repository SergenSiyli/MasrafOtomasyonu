using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MasrafOtomasyonu.DAL;
using MasrafOtomasyonu.BLL;

namespace MasrafOtomasyonu.UI
{
   
    public partial class MuhasebeciArayuzu : Form
    { MasrafRepository mr = new MasrafRepository();
        MasrafHesaplamaDbEntities db = new MasrafHesaplamaDbEntities();
        public MuhasebeciArayuzu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int silinecek = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                mr.Sil(silinecek);
                MessageBox.Show("Seçilen Masraf Başarıyla Silindi.");

                VerileriGetir();
            }
            catch (Exception)
            {
                MessageBox.Show("Seçim yapmadınız.");

            }
        }

        private void VerileriGetir()
        {
            dataGridView1.DataSource = mr.TumunuSec().ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;

        }

        private void MuhasebeciArayuzu_Load(object sender, EventArgs e)
        {
            VerileriGetir();
        }
    }
    }

