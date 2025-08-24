using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository2025.Domain
{
    public class Product
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }

        public Product() { }
        public Product(int codigo, string nombre, int stock)
        {
            Codigo = codigo;
            Nombre = nombre;
            Stock = stock;
        }

        public override string ToString()
        {
            return Codigo + " " + Nombre + " " + Stock;
        }
    }
}
