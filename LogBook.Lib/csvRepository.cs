using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.Lib;

public class csvRepository : IRepository
{
    // title, money
    // Test, 23.22
    // Probe, 14.11

    public csvRepository()
    {
            
    }

    public bool Add(Entry entry)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Entry entry)
    {
        throw new NotImplementedException();
    }

    public Entry? Find(string id)
    {
        throw new NotImplementedException();
    }

    public List<Entry> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }

    public bool Update(Entry entry)
    {
        throw new NotImplementedException();
    }
}
