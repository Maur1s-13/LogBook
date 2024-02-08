using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.Lib;

public interface IRepository
{

    bool Add(Entry entry);
    bool Delete(Entry entry);
    bool Update(Entry entry);

    /// <summary>
    /// Search for an entry
    /// </summary>
    /// <param name="id">the id to search for</param>
    /// <returns>Entry or nullq</returns>
    Entry? Find(string id);

    bool Save();
    List<Entry> GetAll();




}
