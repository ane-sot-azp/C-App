using ElkarGune.Interfazeak;
using ElkarGune.Klaseak;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElkarGune.Kontrolak
{
    class KontrolMezuak
    {
        public DataTable AbisuakIkusi()
        {
            Abisuak ab = new Abisuak();
            return ab.AbisuakIkusi();
        }
        public DataTable MezuakIkusi(int idBazkidea)
        {
            Mezuak me = new Mezuak();
            return me.MezuakIkusi(idBazkidea);
        }
    }
}
