namespace DesignPatterns.SOLID;

public class InterfaceSegregation
{
    public static void Execute()
    {
        var copier = new Copier();

        copier.Scan(new Document());
        copier.Print(new Document());
    }

    public class Document { }

    public interface IPrinter
    {
        void Print(Document doc);
    }

    public interface IScanner
    {
        void Scan(Document doc);
    }

    public class Copier : IPrinter, IScanner
    {
        public void Print(Document doc)
        {
            Console.WriteLine("Printing...");
        }

        public void Scan(Document doc)
        {
            Console.WriteLine("Scanning...");
        }
    }

}
