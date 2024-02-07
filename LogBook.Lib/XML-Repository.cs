using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogBook.Lib;

public class XML_Repository : IRepository
{
    XElement _rootelement;
    private string _path;

    public XML_Repository(string path)
    {
        _path = path;
        if (File.Exists(path))
        {
            _rootelement = XElement.Load(path);
        }
        else
        {
            _rootelement = new XElement("entries");
        }
    }
    public bool Add(Entry entry)
    {
        XElement node = new XElement("entry");
        var idAttrib = new XAttribute("id", entry.Id.ToString());
        node.Add(idAttrib);

        var startAttrib = new XAttribute("start", entry.Start.ToString());
        node.Add(startAttrib);

        var endAttrib = new XAttribute("end", entry.End.ToString());
        node.Add(endAttrib);

        var startkmAttrib = new XAttribute("startkm", entry.StartKM.ToString());
        node.Add(startkmAttrib);

        var endkmAttrib = new XAttribute("endkm", entry.EndKM.ToString());
        node.Add(endkmAttrib);

        var nplateAttrib = new XAttribute("numberplate", entry.NumberPlate.ToString());
        node.Add(nplateAttrib);

        var fromAttrib = new XAttribute("from", entry.From.ToString());
        node.Add(fromAttrib);

        var toAttrib = new XAttribute("to", entry.To.ToString());
        node.Add(toAttrib);

        node.Add(entry.Description.ToString());
        _rootelement.Add(node);

        return this.Save();
    }

    public bool Delete(Entry entry)
    {
        var itemsDel = from e in _rootelement.Descendants("entry")
                       where ((string)e.Attribute("id") ?? "") == entry.Id
                       select e;

        itemsDel.Remove();
        return this.Save();
    }

    public List<Entry> GetAll()
    {
        var entries = from entry in this._rootelement.Descendants("entry")
                      select entry;
        throw new NotImplementedException();

        // Objekt erstellen
        // Liste zurückgeben
    }

    public bool Save()
    {
        try
        {
            _rootelement.Save(_path);
            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Update(Entry entry)
    {
        throw new NotImplementedException();
    }

}
