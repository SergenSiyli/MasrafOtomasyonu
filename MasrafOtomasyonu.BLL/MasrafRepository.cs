using MasrafOtomasyonu.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasrafOtomasyonu.BLL
{
    public class MasrafRepository : IRepository<Masraflar>
    {
        MasrafHesaplamaDbEntities db = new MasrafHesaplamaDbEntities();
        public List<Masraflar> AramaYap(string arama)
        {
            return db.Masraflar.Where(u => u.Baslik == arama).ToList();
        }
        public List<Masraflar> Getir(string kuladi)
        {
            return db.Masraflar.Where(u => u.Personeller.PersonelKuAdi == kuladi).ToList();
        }
        public void Ekle(Masraflar item)
        {
            db.Masraflar.Add(item);
            db.SaveChanges();
        }

        public void Guncelle(Masraflar item)
        {
            Masraflar guncelleme = db.Masraflar.Find(item.MasrafID);
            db.Entry(guncelleme).CurrentValues.SetValues(item);
            db.SaveChanges();
        }

        public Masraflar IdIleSec(int itemID)
        {
            return db.Masraflar.Find(itemID);
        }
        //Bu kullanılmıyor personeller için tasarlandı...
        public int kullanicigirisi(string username, string pass)
        {
            throw new NotImplementedException();
        }

        public void Sil(int itemId)
        {
            db.Masraflar.Remove(db.Masraflar.Find(itemId));
            db.SaveChanges();
        }

        public List<Masraflar> TumunuSec()
        {
            return db.Masraflar.ToList();

        }
    }
}
