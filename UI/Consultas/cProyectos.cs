using Parcial2_ap1_2018_0553.BLL;
using Parcial2_ap1_2018_0553.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2_ap1_2018_0553.UI.Consultas
{
    public partial class cProyectos : Form
    {
        public List<ProyectoDetalle> Detalle { get; set; }
        public cProyectos()
        {
            InitializeComponent();
            this.Detalle = new List<ProyectoDetalle>();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Proyectos>();

            if (string.IsNullOrEmpty(CriteriotextBox.Text))
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProyectosBLL.GetList(e => e.TipoId == Convert.ToInt32(CriteriotextBox.Text));
                        break;
                    case 1:
                        listado = ProyectosBLL.GetList(e => e.DescripcionProyecto.Contains(CriteriotextBox.Text));
                        break;
                }
            }
            else
            {
                listado = ProyectosBLL.GetList(c => true);
            }

            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = listado;
        }
    }
}
