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
        public Producto(string nombre,int cantidad, double costo)
        {
            _nombre = nombre;
            _cantidad = cantidad;
            _costo = costo;
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
        public double IVA(double subTotal)
        {
            return subTotal * 0.16;
        }
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
