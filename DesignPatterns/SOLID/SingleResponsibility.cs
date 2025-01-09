using System.Diagnostics;

namespace DesignPatterns.SOLID;

public class SingleResponsibility
{
    public static void Execute()
    {
        var journal = new Journal();

        journal.AddEntry("I studied");
        journal.AddEntry("George died today");
        Console.WriteLine(journal);

        var filename = @"C:\Users\MicAc\Documents\Projetinhos\DesignPatterns\journal.txt";

        Files.Save(journal, filename, true);
        Process.Start(new ProcessStartInfo { FileName = filename, UseShellExecute = true });
    }

    public class Journal
    {
        private readonly List<string> entries = [];
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; //resembles memento pattern
        }

        public void RemoveEntry(int index) 
            => entries.RemoveAt(index);

        public override string ToString() 
            => string.Join(Environment.NewLine, entries);
    }

    public class Files
    {
        public static void Save(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }
}
