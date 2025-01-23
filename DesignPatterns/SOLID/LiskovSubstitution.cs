namespace DesignPatterns.SOLID;

public class LiskovSubstitution
{
    static public int Area(Rectangle r) => r.Width * r.Height;
    
    public static void Execute()
    {
        Rectangle rectangle = new(5, 15);
        Rectangle square = new Square
        {
            Width = 8
        };

        Console.WriteLine($"{rectangle} has area {Area(rectangle)}");
        Console.WriteLine($"{square} has area {Area(square)}");
    }

    public class Rectangle
    {
        public Rectangle() { }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public override string ToString() 
            => $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";

    }

    public class Square : Rectangle
    {
        public override int Height { set => base.Height = base.Width = value; }
        public override int Width {set => base.Width = base.Height = value; }
    }
}

