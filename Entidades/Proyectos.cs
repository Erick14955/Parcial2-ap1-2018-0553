using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Parcial2_ap1_2018_0553.Entidades
{
    public class Proyectos
    {
        [Key]
        public int ProyectoId { get; set; }
        public int TipoId { get; set; }
        public DateTime Fecha { get; set; }
        public string DescripcionProyecto { get; set; }
        public int TiempoTotal { get; set; }
        [ForeignKey("ProyectoId")]
        public List<ProyectoDetalle> Detalle { get; set; }

        public Proyectos()
        {
            TipoId = 0;
            Fecha = DateTime.Now;
            DescripcionProyecto = "";
            TiempoTotal = 0;

            Detalle = new List<ProyectoDetalle>();
        }

    }
}
