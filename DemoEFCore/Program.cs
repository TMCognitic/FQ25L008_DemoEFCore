using DemoEFCore.Dal;
using DemoEFCore.Dal.Entities;

ProductManagerDbContext context = new ProductManagerDbContext();

IQueryable<Product> query = context.Products.Where(p => p.Price > 3);

foreach (Product product in query)
{
    Console.WriteLine(product.Name);
}