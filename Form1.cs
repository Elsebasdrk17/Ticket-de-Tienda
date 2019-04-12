using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ticketTienda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Se hacen globales para que el valor se obtenga en todo el formulario
        /// </summary>
        double subtotal, total;

        Producto producto;

        private void btnPagar_Click(object sender, EventArgs e)
        {
            //Si la caja de texto esta en blanco marcar error
            if (txtSuPago.Text == "")
            {
                MessageBox.Show("Obligatorio poner la cantidad pagada", "ERROR");
            }
            else
            {
                double pago = Convert.ToDouble(txtSuPago.Text);
                if (pago > total)
                {
                    txtCambio.Text = (pago - total).ToString();
                }
                else
                {
                    txtCambio.Text = "0";
                }
                total -= pago;
                txtSubTotal.Text = subtotal.ToString();
                if (total < 0)
                {
                    total = 0;
                    txtTotal.Text = total.ToString();
                }
                else
                {
                    txtTotal.Text = total.ToString();
                }
            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string nombreArchivo;
            nombreArchivo = saveFileDialog1.FileName;
            FileStream fs = new FileStream(nombreArchivo, FileMode.Create);
            StreamWriter escritor = new StreamWriter(fs);
            escritor.WriteLine("EL OTZO");
            escritor.WriteLine(DateTime.Now.ToString());
            //se hace un ciclo para recorrer cada item de la lista
            for(int i = 0; i < listaProductos.Items.Count; i++)
            {
                escritor.WriteLine(listaProductos.Items[i]);
            }
            escritor.Write("Importe: $");
            escritor.WriteLine(txtImporte.Text);
            escritor.Write("IVA: $");
            escritor.WriteLine(txtIVA.Text);
            escritor.Write("Total: $");
            double totalTicket = subtotal + producto.IVA(subtotal);
            escritor.WriteLine(totalTicket);
            escritor.Write("Pagaste: $");
            escritor.WriteLine(txtSuPago.Text);
            escritor.Write("Te resta: $");
            escritor.WriteLine(total);
            escritor.Write("Tu cambio: $");
            escritor.WriteLine(txtCambio.Text);
            escritor.WriteLine("¡Gracias por tu compra!");
            escritor.Close();
            fs.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtProducto.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            // si la caja de texto esta en blanco marcar error
            if (txtCosto.Text == "")
            {
                MessageBox.Show("Obligatorio poner precio del producto", "ERROR");
            }
            else
            {
                //obtener tosdos los valores y mostrarlos en las cajas de textos
                double costo = Convert.ToDouble(txtCosto.Text);
                producto = new Producto(nombre, cantidad, costo);
                txtImporte.Text = producto.importe().ToString();
                subtotal += producto.importe();
                txtSubTotal.Text = subtotal.ToString();
                txtIVA.Text = producto.IVA(subtotal).ToString();
                total = subtotal + producto.IVA(subtotal);
                txtTotal.Text = total.ToString();
                listaProductos.Items.Add(producto.ToString());
            }
        }
    }
}
