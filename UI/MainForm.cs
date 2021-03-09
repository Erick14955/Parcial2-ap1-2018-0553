using Parcial2_ap1_2018_0553.UI.Consultas;
using Parcial2_ap1_2018_0553.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2_ap1_2018_0553
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.RegistrosToolStripMenuItem.Click += new EventHandler(this.RegistrosToolStripMenuItem_ItemClicked);
            this.ConsultasToolStripMenuItem.Click += new EventHandler(this.ConsultasToolStripMenuItem_ItemClicked);
        }

        private void RegistrosToolStripMenuItem_ItemClicked(object sender, EventArgs e)
        {
            rProyectos proyectos = new rProyectos();
            proyectos.MdiParent = this;
            proyectos.Show();
        }

        private void ConsultasToolStripMenuItem_ItemClicked(object sender, EventArgs e)
        {
            cProyectos consultas = new cProyectos();
            consultas.MdiParent = this;
            consultas.Show();
        }

    }
}
