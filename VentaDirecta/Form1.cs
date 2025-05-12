using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentaDirecta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvVentas.ColumnCount = 5;
            dgvVentas.Columns[0].Name = "Código";
            dgvVentas.Columns[1].Name = "Nombre";
            dgvVentas.Columns[2].Name = "Precio Unitario";
            dgvVentas.Columns[3].Name = "Cantidad";
            dgvVentas.Columns[4].Name = "Total";
        }
        //bajedepepa

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string precio = txtPrecio.Text;
            string cantidad = txtCantidad.Text;
            string total = txtTotal.Text;

            if (codigo == "" || nombre == "" || precio == "" || cantidad == "" || total == "")
            {
                MessageBox.Show("Completa todos los campos antes de registrar la venta.");
                return;
            }

            string[] row = new string[] { codigo, nombre, precio, cantidad, total };
            dgvVentas.Rows.Add(row);

          
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtTotal.Clear();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                int cantidad = int.Parse(txtCantidad.Text);
                decimal precio = decimal.Parse(txtPrecio.Text);
                decimal total = precio * cantidad;

                
                if (codigo == "" || nombre == "")
                {
                    MessageBox.Show("Completa todos los campos antes de registrar la venta.");
                    return;
                }

                
                dgvVentas.Rows.Add(codigo, nombre, precio.ToString("0.00"), cantidad.ToString(), total.ToString("0.00"));

                
                txtCodigo.Clear();
                txtNombre.Clear();
                txtPrecio.Clear();
                txtCantidad.Clear();
                txtTotal.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }

        private void btnCalcular_Click_1(object sender, EventArgs e)
        {
            decimal totalGeneral = 0;

            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
               
                if (!row.IsNewRow && row.Cells["Total"].Value != null)
                {
                    try
                    {
                        decimal totalFila = Convert.ToDecimal(row.Cells["Total"].Value);
                        totalGeneral += totalFila;
                    }
                    catch
                    {
                        MessageBox.Show("Error al calcular el total. Verifique los valores en la tabla.");
                        return;
                    }
                }
            }

            txtTotal.Text = totalGeneral.ToString("0.00");
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
