using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.Lib;

public class MemoryRepository : IRepository
{

    List<Entry> list = new List<Entry>();


    public bool Add(Entry entry)
    {
        list.Add(entry);
        return true;
    }

    public bool Delete(Entry entry)
    {
        list.Remove(entry);
        return true;
    }

    public List<Entry> GetAll()
    {
        

        return list;
    }

    public bool Save()
    {
        return true;
    }

    public bool Update(Entry entry)
    {
        var item = (from search in list
                   where entry.Id == search.Id
                   select search).FirstOrDefault();

        if (item != null)
        {
            item = entry;
            return true;
        }

        return false;
        
    }
}
