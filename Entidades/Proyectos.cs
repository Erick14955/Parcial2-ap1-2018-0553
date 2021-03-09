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
        public int TipoId { get; set; }
        public DateTime Fecha { get; set; }
        public string DescripcionProyecto { get; set; }
        public int TiempoTotal { get; set; }
        [ForeignKey("TipoId")]
        public List<ProyectoDetalle> Detalle { get; set; }

    }
}
