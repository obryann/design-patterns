namespace DesignPatterns.SOLID;

public class OpenClosed
{
    public static void Execute()
    {
        var table = new Product("Table", Color.Black, Size.Medium);
        var car = new Product("Car", Color.Black, Size.Large);
        var house = new Product("House", Color.Blue, Size.Huge);

        Product[] products = {table,  car, house};

        var filter = new ProductFilter();
        Console.WriteLine("(DEPRECATED)Black products:");
        foreach (var product in filter.FilterByColor(products, Color.Black))
        {
            Console.WriteLine($"{product.Name} | {product.Color} | {product.Size}");
        }

        var betterFilter = new BetterFilter();
        Console.WriteLine("(NEW)Black products:");
        foreach(var product in betterFilter.Filter(products, new ColorSpec(Color.Black)))
        {
            Console.WriteLine($"{product.Name} | {product.Color} | {product.Size}");
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
            {
                if(spec.IsSatisfied(item))
                    yield return item;
            }
        }
    }

    public class ColorSpec : ISpecification<Product>
    {
        private Color color;
        public ColorSpec(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    #region Deprecated Filter
    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(
            IEnumerable<Product> products, Size size)
        {
            foreach (Product product in products)
            {
                if(product.Size == size)
                    yield return product;
            }
        }

        public IEnumerable<Product> FilterByColor(
            IEnumerable<Product> products, Color color)
        {
            foreach (Product product in products)
            {
                if (product.Color == color)
                    yield return product;
            }
        }
    }

    #endregion



    public enum Color
    {
        Red,
        Green,
        Blue,
        Black
    }
    public enum Size
    {
        Small,
        Medium,
        Large,
        Huge
    }
    public class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }

        public Product(string name, Color color, Size size)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Color = color;
            Size = size;
        }
    }
}
