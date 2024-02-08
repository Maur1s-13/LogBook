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

    public Entry? Find(string id)
    {
        var item = (from entry in _rootelement.Descendants("entry")
                    where (string)entry.Attribute("id") == id
                    select new Entry(

                           Convert.ToDateTime(entry.Attribute("start").Value),
                           Convert.ToDateTime(entry.Attribute("end").Value),
                           (int)entry.Attribute("startkm"),
                           (int)entry.Attribute("endkm"),
                           entry.Attribute("numberplate").Value,
                           entry.Attribute("from").Value,
                           entry.Attribute("to").Value,
                           entry.Attribute("id").Value
                        )
                    {

                    }
                    ).FirstOrDefault();

        return item;
    }

    public List<Entry> GetAll()
    {
        var entries = from entry in this._rootelement.Descendants("entry")
                      select new Entry(

                           Convert.ToDateTime(entry.Attribute("start").Value),
                           Convert.ToDateTime(entry.Attribute("end").Value),
                           (int)entry.Attribute("startkm"),
                           (int)entry.Attribute("endkm"),
                           entry.Attribute("numberplate").Value,
                           entry.Attribute("from").Value,
                           entry.Attribute("to").Value,
                           entry.Attribute("id").Value


                        )
                      {
                          Description = entry.Value,
                        };


        return entries.ToList<Entry>();

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
        var item = (from e in _rootelement.Descendants("entry")
                   where (string)e.Attribute("id") == entry.Id
                   select e).FirstOrDefault();

        if (item != null)
        {

            item.SetAttributeValue("start", entry.Start.ToString());
            item.SetAttributeValue("end", entry.End.ToString());
            item.SetAttributeValue("startkm", entry.StartKM.ToString());
            item.SetAttributeValue("endkm", entry.EndKM.ToString());
            item.SetAttributeValue("numberplate", entry.NumberPlate.ToString());
            item.SetAttributeValue("to", entry.To.ToString());
            item.SetAttributeValue("from", entry.From.ToString());

            //id nicht, da sonst das Element nicht mehr gefunden wird

            return this.Save();

        }
        else
        {
            return false;
        }

    }

}
