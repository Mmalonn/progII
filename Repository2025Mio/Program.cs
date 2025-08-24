// See https://aka.ms/new-console-template for more information
using Repository2025.Data;
using Repository2025.Domain;
using Repository2025.Services;

ProductService coso = new ProductService();


Product pObtenido = coso.GetProduct(2);
Console.WriteLine(pObtenido.ToString());

Console.WriteLine(coso.DeleteProductById(3));

Product aGuardar = new Product(4, "cosito2", 32);
Console.WriteLine(coso.SaveProduct(aGuardar));

List<Product> products = coso.GetProducts();
if (products != null)
{
    foreach (Product item in products)
    {
        Console.WriteLine(item.ToString());
    }
}
else
{
    Console.WriteLine("no hay");
}


