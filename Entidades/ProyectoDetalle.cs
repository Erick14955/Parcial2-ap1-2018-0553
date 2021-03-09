using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_ap1_2018_0553.Entidades
{
    public class ProyectoDetalle
    {
        [Key]
        public int TipoId { get; set; }
        public string TipoTarea { get; set; }
        public string Requerimentos { get; set; }
        public int Tiempo { get; set; }

        public ProyectoDetalle()
        {
            TipoId = 0;
            TipoTarea = "";
            Requerimentos = "";
            Tiempo = 0;
        }

        public ProyectoDetalle(int TipoId, string TipoTarea, string Requerimentos, int Tiempo)
        {
            this.TipoId = TipoId;
            this.TipoTarea = TipoTarea;
            this.Requerimentos = Requerimentos;
            this.Tiempo = Tiempo;
        }
    }
}
