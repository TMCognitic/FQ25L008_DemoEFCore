using DemoEFCore.Dal;
using DemoEFCore.Dal.Entities;
using Microsoft.EntityFrameworkCore;

ProductManagerDbContext context = new ProductManagerDbContext();


////Eager Loading => Jointure
//IQueryable<Product> query = context.Products.Include(p => p.Category).Where(p => p.Price > 5);

//Lazy Loading
//IEnumerable<Product> query = context.Products.Where(p => p.Price > 3).ToList();

//foreach (Product product in query)
//{
//    Console.WriteLine(product.Name);
//    Console.WriteLine(product.Description);
//    Console.WriteLine(product.Price);
//    //Lazy Loading => Requetes Multiples
//    context.Entry(product).Reference(p => p.Category).Load();

//    Console.WriteLine(product.Category.Name);
//}

//IEnumerable<Category> categories = context.Categories.ToList();

//foreach (Category category in categories)
//{
//    Console.WriteLine($"Category Name : {category.Name}");
//    context.Entry(category).Collection(p => p.Products).Load();

//    foreach (Product product in category.Products)
//    {
//        Console.WriteLine(product.Name);
//        Console.WriteLine(product.Description);
//        Console.WriteLine(product.Price);
//        Console.WriteLine(product.Category.Name);
//    }
//}

//Console.WriteLine(context.ChangeTracker.Entries().Count());

Product? product1 = context.Products.Find(1);

if(product1 is not null)
{
    Console.WriteLine(product1.Name);
    product1.Name = "Salade Caesar";
    product1.Price = 4.99;
}
Console.WriteLine(context.SaveChanges());
//context.ChangeTracker.Clear(); //Que dans une application Bureau (console, wpf, windows forms, 'etc')
Console.WriteLine();
//Category boissons = new Category() { Name = "Boissons" };

//context.Categories.Add(boissons);
//context.Products.Add(new Product() { Name = "Ice Tea", Description = "Boisson fraiche", Category = boissons, Price = 5.69 });

//Console.WriteLine(context.SaveChanges());
