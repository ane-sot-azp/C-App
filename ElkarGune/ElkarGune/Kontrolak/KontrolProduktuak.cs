using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types;
using ElkarGune.Klaseak;
using ElkarGune.Interfazeak;


namespace ElkarGune
{
    class KontrolProduktuak
    {
        public void SartuKontsumizioa(int idProd, int kop, int fraZkia, float prezioa)
        {
            Kontsumizioak kontsumizioak = new Kontsumizioak();
            kontsumizioak.SartuKontsumizioa(idProd, kop, fraZkia, prezioa);
        }
        public void SartuFaktura(int idBazkidea)
        {
            Fakturak fakturak = new Fakturak();
            fakturak.SartuFaktura(idBazkidea);
        }
        public void EguneratuFaktura(int fraZenbakia, float total)
        {
            Fakturak fakturak = new Fakturak();
            fakturak.EguneratuFaktura(fraZenbakia, total);
        }
        public void EguneratuProduktua(int idProduktua, int kopurua)
        {
            Produktua produktua = new Produktua();
            produktua.EguneratuProduktua(idProduktua, kopurua);
        }
        public void EzabatuKontsumizioa(int idProd, int fraZkia)
        {
            Kontsumizioak kontsumizioak = new Kontsumizioak();
            kontsumizioak.EzabatuKontsumizioa(idProd, fraZkia);
        }
        public MySqlDataReader ProduktuakIkusi(int idProduktuMota){
            Produktua p = new Produktua();
            return p.ProduktuakIkusi(idProduktuMota);
        }
        public MySqlDataReader ProduktuaKop (int idProduktua){
            Produktua p = new Produktua();
            return p.ProduktuaKop(idProduktua);
        }
        public MySqlDataReader KontsFakturaBilatu(int idBazkidea, DateTime data){
            Produktua p = new Produktua();
            return p.KontsFakturaBilatu(idBazkidea, data);
        }
        public MySqlDataAdapter KontsumizioZerrenda(int fraZenbakia)
        {
            Kontsumizioak k = new Kontsumizioak();
            return k.KontsumizioZerrenda(fraZenbakia);
        }
        public MySqlDataAdapter KargatuDatuak(int fraZenbakia){
            Kontsumizioak k = new Kontsumizioak();
            return k.KargatuDatuak(fraZenbakia);
        }
        public MySqlDataReader FakturaBilatu(int idBazkidea, DateTime data){
            Kontsumizioak k = new Kontsumizioak();
            return k.FakturaBilatu(idBazkidea, data);
        }
        public MySqlDataReader FakturaDetailea(int idFaktura){
            Fakturak f = new Fakturak();
            return f.FakturaDetailea(idFaktura);
        }
    }
}
