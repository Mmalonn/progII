using Microsoft.Data.SqlClient;
using Repository2025.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository2025.Data
{
    public class ProductRepository : iProductRepository
    {
        public bool Delete(int id)
        {
            // Ejecutás el SP que da de baja
            DataHelper.GetInstance().ExecuteSPQuery2("SP_REGISTRAR_BAJA_PRODUCTO", id);

            // Consultás el producto para verificar si quedó inactivo
            var dt = DataHelper.GetInstance().ExecuteSPQuery2("SP_RECUPERAR_PRODUCTO_POR_CODIGO", id);

            if (dt.Rows.Count > 0)
            {
                // Si esta_activo es 0, la baja fue exitosa
                bool estaActivo = Convert.ToBoolean(dt.Rows[0]["esta_activo"]);
                return !estaActivo;
            }
            return false;
        }


        public List<Product> GetAll()
        {
            List<Product> lst = new List<Product>();
            //conectar db y traer los registros
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_Recuperar_Productos");
            foreach (DataRow row in dt.Rows)
            {
                Product product = new Product();
                product.Codigo = (int)row["codigo"];
                product.Nombre = (string)row["n_producto"];
                //product.Precio = (double)row["precio"];
                product.Stock = (int)row["stock"];
                product.Activo = (bool)row["esta_activo"];
                lst.Add(product);
            }
            return lst;
        }

        public Product GetById(int id)
        {
            Product product = new Product();
            var prod = DataHelper.GetInstance().ExecuteSPQuery2("SP_RECUPERAR_PRODUCTO_POR_CODIGO", id);
            foreach (DataRow row in prod.Rows)
            {
                product.Codigo = (int)row["codigo"];
                product.Nombre = (string)row["n_producto"];
                product.Stock = (int)row["stock"];
                product.Activo = (bool)row["esta_activo"];
            }
            return product;
        }

        public bool Save(Product product)
        {
            var parametros = new Dictionary<string, object>
            {
                { "@codigo", product.Codigo },
                { "@nombre", product.Nombre },
                { "@stock", product.Stock }
            };
            return DataHelper.GetInstance().ExecuteSPQuery3("SP_GUARDAR_PRODUCTO", parametros);
        }
    }
}
