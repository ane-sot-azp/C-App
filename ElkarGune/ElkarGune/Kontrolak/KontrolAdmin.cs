using ElkarGune.Klaseak;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElkarGune.Kontrolak
{
    class KontrolAdmin
    {
        public DataTable FakturakIkusi(int idBazkidea)
        {
            Fakturak fakturak = new Fakturak();
            return fakturak.FakturakIkusi(idBazkidea);
        }
        public void SartuFaktura(int idBazkidea)
        {
            Fakturak fakturak = new Fakturak();
            fakturak.SartuFaktura(idBazkidea);
        }
        public MySqlDataReader FakturaBilatu(int idBazkidea, DateTime data){
            Fakturak f = new Fakturak();
            return f.FakturaBilatu(idBazkidea, data);
        }
        public MySqlDataReader FakturaDetailea(int idFaktura){
            Fakturak f = new Fakturak();
            return f.FakturaDetailea(idFaktura);
        }
        public void EguneratuFaktura(int fraZenbakia, float total)
        {
            Fakturak fakturak = new Fakturak();
            fakturak.EguneratuFaktura(fraZenbakia, total);
        }
    }
}
