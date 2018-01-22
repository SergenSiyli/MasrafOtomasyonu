using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasrafOtomasyonu.BLL
{
    public interface IRepository<P>

    {
        void Ekle(P item);
        void Guncelle(P item);

        void Sil(int itemId);

        List<P> TumunuSec();
        P IdIleSec(int itemID);
        List<P> AramaYap(string arama);
        int kullanicigirisi(string username, string pass);

    }
}