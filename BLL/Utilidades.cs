using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_ap1_2018_0553.BLL
{
    class Utilidades
    {
        public static int ToInt(string valor)
        {
            int retorno;
            int.TryParse(valor, out retorno);

            return retorno;
        }
    }
}
