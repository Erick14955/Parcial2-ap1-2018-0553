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

namespace Parcial2_ap1_2018_0553.UI.Registros
{
    public partial class rProyectos : Form
    {
        public List<ProyectoDetalle> Detalle { get; set; }
        public rProyectos()
        {
            InitializeComponent();
            this.Detalle = new List<ProyectoDetalle>();
            TiempototaltextBox.Text = 0.ToString();
        }

        private void rProyectos_Load(object sender, EventArgs e)
        {
            TipoTareacomboBox.DataSource = TareasBLL.GetTareas();
            TipoTareacomboBox.ValueMember = "TareaId";
            TipoTareacomboBox.DisplayMember = "TipoTarea";
        }

        public void CargarGrid()
        {
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = this.Detalle;
        }

        private void Limpiar()
        {
            ErroreserrorProvider.Clear();
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now.Date;
            DescripciontextBox.Clear();
            TiempototaltextBox.Text = 0.ToString();
            this.Detalle = new List<ProyectoDetalle>();
            CargarGrid();
        }

        private void LlenarCampo(Proyectos proyectos)
        {
            IdnumericUpDown.Value = proyectos.TipoId;
            FechadateTimePicker.Value = proyectos.Fecha;
            DescripciontextBox.Text = proyectos.DescripcionProyecto;
            TiempototaltextBox.Text = proyectos.TiempoTotal.ToString();

            this.Detalle = proyectos.Detalle;
            CargarGrid();
        }

        private Proyectos LlenarClase()
        {
            Proyectos proyectos = new Proyectos();
            proyectos.TipoId = Convert.ToInt32(IdnumericUpDown.Value);
            proyectos.Fecha = FechadateTimePicker.Value.Date;
            proyectos.DescripcionProyecto = DescripciontextBox.Text;
            proyectos.TiempoTotal = Convert.ToInt32(TiempototaltextBox.Text);
            proyectos.Detalle = this.Detalle;
            CargarGrid();

            return proyectos;
        }

        public bool ExisteEnLaBaseDeDatos()
        {
            Proyectos proyectos = ProyectosBLL.Buscar(Convert.ToInt32(IdnumericUpDown));
            return (proyectos != null);
        }

        public bool Validar()
        {
            bool paso = true;

            if (DescripciontextBox.Text == string.Empty)
            {
                ErroreserrorProvider.SetError(DescripciontextBox, "Este campo no puede quedar vacio");
                DescripciontextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Proyectos proyectos = new Proyectos();
            int id;
            int.TryParse(IdnumericUpDown.Text, out id);

            Limpiar();

            proyectos = ProyectosBLL.Buscar(id);

            if (proyectos != null)
            {
                LlenarCampo(proyectos);
            }
            else
            {
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            if(DetalledataGridView.DataSource != null)
            {
                this.Detalle = (List<ProyectoDetalle>)DetalledataGridView.DataSource;
            }

            if (RequerimentotextBox.Text == string.Empty)
            {
                ErroreserrorProvider.SetError(RequerimentotextBox, "Este campo no puede quedar vacio");
                RequerimentotextBox.Focus();
                return;
            }

            if (TiempotextBox.Text == string.Empty)
            {
                ErroreserrorProvider.SetError(TiempotextBox, "Este campo no puede quedar vacio");
                TiempotextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TipoTareacomboBox.Text))
            {
                ErroreserrorProvider.SetError(TipoTareacomboBox, "Debe agregar un tipo de tarea especifico");
                TipoTareacomboBox.Focus();
                return;
            }

            Tareas tareas = TareasBLL.Buscar(Convert.ToInt32(TipoTareacomboBox.SelectedValue));
            this.Detalle.Add(
                new ProyectoDetalle
                (
                    TipoId: tareas.TareaId,
                    TipoTarea: tareas.TipoTarea,
                    Requerimentos: RequerimentotextBox.Text,
                    Tiempo: Convert.ToInt32(TiempotextBox.Text)
                )
            );

            CargarGrid();

            int totalTiempo = Convert.ToInt32(TiempototaltextBox.Text);
            int tiempo = Convert.ToInt32(TiempotextBox.Text);
            totalTiempo += tiempo;

            TiempototaltextBox.Text = totalTiempo.ToString();
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            string tiempo;
            int totalTiempo = Convert.ToInt32(TiempototaltextBox.Text);
            if(DetalledataGridView.Rows.Count > 0 && DetalledataGridView.CurrentRow != null)
            {
                tiempo = DetalledataGridView.CurrentRow.Cells[3].Value.ToString();
                totalTiempo -= Convert.ToInt32(tiempo);

                TiempototaltextBox.Text = totalTiempo.ToString();

                Detalle.RemoveAt(DetalledataGridView.CurrentRow.Index);
                CargarGrid();
            }
            else
            {
                ErroreserrorProvider.SetError(DetalledataGridView, "No existen datos en esta tabla");
                DetalledataGridView.Focus();
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Proyectos proyectos;
            if (!Validar())
                return;

            proyectos = LlenarClase();

            var paso = ProyectosBLL.Guardar(proyectos);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(IdnumericUpDown.Text, out id);

            if(IdnumericUpDown.Value == 0)
            {
                MessageBox.Show("Es necesario agregar un id valido para poder eliminarlo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ProyectosBLL.Eliminar(id))
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ErroreserrorProvider.SetError(IdnumericUpDown, "Id no existente en la base de datos");
            }
        }
    }
}
