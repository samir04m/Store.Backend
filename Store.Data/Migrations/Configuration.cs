namespace Store.Data.Migrations
{
    using Store.Data.Entities;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Electrónica" },
                    new Category { Name = "Ropa" },
                    new Category { Name = "Libros" },
                    new Category { Name = "Hogar" }
                };

                categories.ForEach(c => context.Categories.Add(c));

                context.SaveChanges();
            }
        }
    }
}
