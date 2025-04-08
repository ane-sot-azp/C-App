using ElkarGune.Klaseak;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElkarGune
{
    class KontrolErreserbak
    {
        public DataTable ErreEleIkusi(int idBazkidea, int mota, DateTime erreserbaData)
        {
            ErreserbaElementua erreserbaElementua = new ErreserbaElementua();
            return erreserbaElementua.ErreEleIkusi(idBazkidea, mota, erreserbaData);
        }
        public void ErreEleSartu(int idEspazioa, int idBazkidea, int mota, DateTime erreserbaData)
        {
            ErreserbaElementua erreserbaElementua = new ErreserbaElementua();
            erreserbaElementua.ErreEleSartu(idEspazioa, idBazkidea, mota, erreserbaData);
        }
        public void ErreEleEzabatu(int idEspazioa, int idBazkidea, int mota, DateTime erreserbaData)
        {
            ErreserbaElementua erreserbaElementua = new ErreserbaElementua();
            erreserbaElementua.ErreEleEzabatu(idEspazioa, idBazkidea, mota, erreserbaData);
        }
        public int ErreserbaSartu(int idBazkidea, int mota, DateTime erreserbaData)
        {
            Erreserba erreserba = new Erreserba();
            return erreserba.ErreserbaSartu(idBazkidea, mota, erreserbaData);
        }
        public void ErreserbaEguneratu(int idErreserba)
        {
            Erreserba erreserba = new Erreserba();
            erreserba.ErreserbaEguneratu(idErreserba);
        }
        public void ErreserbaEzabatu(int idErreserba)
        {
            Erreserba erreserba = new Erreserba();
            erreserba.ErreserbaEzabatu(idErreserba);
        }
        public DataTable ErreserbaIkusi(DateTime data)
        {
            Erreserba erreserba = new Erreserba();
            return erreserba.ErreserbaIkusi(data);
        }
        public DataTable HistorikoaIkusi(int idBazkidea, DateTime data)
        {
            Erreserba erreserba = new Erreserba();
            return erreserba.HistorikoaIkusi(idBazkidea, data);
        }
        public void Erreserbatu(int idBazkidea, int mota, DateTime erreserbaData){
            Erreserba erreserba = new Erreserba();
            erreserba.Erreserbatu(idBazkidea, mota, erreserbaData);
        }
        public bool Ezabatu(int idBazkidea, int mota, DateTime erreserbaData)
        {
            Erreserba erreserba = new Erreserba();
            return erreserba.Ezabatu(idBazkidea, mota, erreserbaData);
        }
        public bool EspazioaErreserbatutaDago(int idEspazioa, int mota, DateTime erreserbaData){
            Espazioa espazioa = new Espazioa();
            return espazioa.EspazioaErreserbatutaDago(idEspazioa, mota, erreserbaData);
        }
        public void ErreserbaKudeatu(int idEspazioa, int idBazkidea, int mota, DateTime erreserbaData)
        {
            Erreserba erreserba = new Erreserba();
            erreserba.ErreserbaKudeatu(idEspazioa, idBazkidea, mota, erreserbaData);
        }
        public List<(int index, int egoera)> LortuEspazioEgoerak(){
        Espazioa espazioa = new Espazioa();
        return espazioa.LortuEspazioEgoerak();
        }
        public List<(int espazioaId, int idBazkidea)> LortuErreserbak(int mota, DateTime data)
        {
        Espazioa espazioa = new Espazioa();
        return espazioa.LortuErreserbak(mota, data);
        }
        public int ErreserbaIdLortu(int idBazkidea, int mota, DateTime erreserbaData)
        {
            Erreserba erreserba = new Erreserba();
            return erreserba.ErreserbaIdLortu(idBazkidea, mota, erreserbaData);
        }
    }
}

