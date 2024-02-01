using LogBook.Lib;


Console.WriteLine("Willkomen beim Fahrtenbuch");

IRepository repository = new MemoryRepository();





List<Entry> entries = repository.GetAll();

foreach (Entry entry in entries)
{
    Console.WriteLine(entry.From);
}
