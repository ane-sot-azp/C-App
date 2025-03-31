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
    }
}
