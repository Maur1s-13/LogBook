using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogBook.Lib;

public class XML_Repository : IRepository
{
    XElement _rootElement;

    public XML_Repository(string path)
    {
        if (File.Exists(path))
        {
            _rootElement = XElement.Load(path);
        }
        else
        {
            _rootElement = new XElement("entries");
        }
    }

    public bool Add(Entry entry)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Entry entry)
    {
        throw new NotImplementedException();
    }

    public List<Entry> GetAll()
    {
        var entries = from entry in this._rootElement.Descendants("entry")
                      select entry;

        //TODO:
        // - Objekt Entry erstellen
        // - Liste zurückgeben

        throw new NotImplementedException();

        //return entries

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
