using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasrafOtomasyonu.DAL;

namespace MasrafOtomasyonu.BLL
{
    public class PersonelRepository : IRepository<Personeller>
    {
        MasrafHesaplamaDbEntities db = new MasrafHesaplamaDbEntities();
        public List<Personeller> AramaYap(string arama)
        {
            return db.Personeller.Where(u => u.PersonelAdi == arama).ToList();
        }

        public void Ekle(Personeller item)
        {
            db.Personeller.Add(item);
            db.SaveChanges();

        }
      

        public void Guncelle(Personeller item)
        {
            Personeller guncelleme = db.Personeller.Find(item.PersonelID);
            db.Entry(guncelleme).CurrentValues.SetValues(item);
            db.SaveChanges();
        }

        public Personeller IdIleSec(int itemID)
        {
            return db.Personeller.Find(itemID);
        }


        public int kullanicigirisi(string username, string pass)
        {
            int degisken=0;
            int toplam = 0;
            if (db.Personeller.Any(u => u.PersonelKuAdi == username && u.PersonelSifresi == pass && u.YetkiID == 1))
            {
                toplam = degisken + 1;
            }
            if (db.Personeller.Any(u => u.PersonelKuAdi== username && u.PersonelSifresi == pass && u.YetkiID == 2))
            {
                toplam = degisken + 2;
            }
            if (db.Personeller.Any(u => u.PersonelKuAdi == username && u.PersonelSifresi == pass && u.YetkiID == 3))
            {
                toplam = degisken + 3;
            }
            return toplam;

        }

        public void Sil(int itemId)
        {
            db.Personeller.Remove(db.Personeller.Find(itemId));
            db.SaveChanges();
        }

        public List<Personeller> TumunuSec()
        {
            return db.Personeller.ToList();
        }
    }
}
