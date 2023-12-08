using System.Drawing;

namespace demo.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
{
    new Shirt(){ Id = 1, Brand = "Nike", Color ="red", Gender = "men", Size = 8, Price = 49.99},
    new Shirt(){ Id = 2, Brand = "Adidas", Color ="blue", Gender = "women", Size = 7, Price = 39.99},
    new Shirt(){ Id = 3, Brand = "Puma", Color ="green", Gender = "men", Size = 12, Price = 29.99},
    new Shirt(){ Id = 4, Brand = "Reebok", Color ="black", Gender = "women", Size = 6, Price = 59.99},
    new Shirt(){ Id = 5, Brand = "Under Armour", Color ="gray", Gender = "men", Size = 9, Price = 79.99},
    new Shirt(){ Id = 6, Brand = "Fila", Color ="white", Gender = "women", Size = 7, Price = 34.99},
    new Shirt(){ Id = 7, Brand = "New Balance", Color ="purple", Gender = "men", Size = 10, Price = 54.99},
    new Shirt(){ Id = 8, Brand = "Asics", Color ="yellow", Gender = "women", Size = 11, Price = 44.99},
};

        public static List<Shirt> getShirts()
        {
            return shirts;
        }

        public static bool ShirtExist(int id)
        {
            return shirts.Any(x => x.Id == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.Id == id);
        }

        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(x => x.Id);
            shirt.Id = maxId + 1;
            shirts.Add(shirt);
        }

        public static Shirt? GetShirtByProps(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(x => 
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
             !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue && 
            x.Size.HasValue && 
            size.Value == x.Size.Value
            );
        }

    }
}
