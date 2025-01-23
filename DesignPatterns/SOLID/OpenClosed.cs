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

        var specs = new AndSpecification<Product>(new ColorSpec(Color.Blue), new SizeSpec(Size.Huge));
        Console.WriteLine("Huge blue items");
        foreach (var product in betterFilter.Filter(products,
            specs))
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
                if (spec.IsSatisfied(item))
                    yield return item;
            }
        }
    }

    public class ColorSpec(Color color) : ISpecification<Product>
    {
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }

    public class SizeSpec(Size size) : ISpecification<Product>
    {
        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }

    public class AndSpecification<T>(ISpecification<T> first, 
        ISpecification<T> second) : ISpecification<T>
    {
        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
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
    public class Product(string name, OpenClosed.Color color, OpenClosed.Size size)
    {
        public string Name { get; set; } = name ?? throw new ArgumentNullException(nameof(name));
        public Color Color { get; set; } = color;
        public Size Size { get; set; } = size;
    }
}
