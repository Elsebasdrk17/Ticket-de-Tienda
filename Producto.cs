using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketTienda
{
    class Producto
    {
        private string _nombre;
        private int _cantidad;
        private double _costo;
        private double _total;
        /// <summary>
        /// Constructor de la clase producto
        /// </summary>
        /// <param name="nombre">Recibe el nombre que tendra el producto</param>
        /// <param name="cantidad">La cantidad de ese producto</param>
        /// <param name="costo">El costo unitario del producto</param>
        public Producto(string nombre,int cantidad, double costo)
        {
            _nombre = nombre;
            _cantidad = cantidad;
            _costo = costo;
            //seria el importe del producto
            _total = _costo * _cantidad;
        }
        public string nombre
        {
            get { return _nombre; }
        }
        public int cantidad
        {
            get { return _cantidad; }
        }
        public double costo
        {
            get { return _costo; }
        }
        public double total
        {
            get { return _total; }
        }
        /// <summary>
        /// Funcion que calcula el iva del producto
        /// </summary>
        /// <param name="subTotal">Recibe el subtotal del producto</param>
        /// <returns>El IVA del producto</returns>
        public double IVA(double subTotal)
        {
            return subTotal * 0.16;
        }
        /// <summary>
        /// Funcion que calcula el importe del producto
        /// </summary>
        /// <returns></returns>
        public double importe()
        {
            return _costo * _cantidad;
        }
        public override string ToString()
        {
            return "Producto: " + _nombre
                + " Cantidad: " + _cantidad
                + " Precio Unitario: $" + _costo
                + " Total: " + _total;
        }
    }
}
