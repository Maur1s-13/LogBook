using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.Lib
{
    public class SqliteRepository : IRepository
    {

        string _path = string.Empty;

        public SqliteRepository(string path)
        {
            _path = path;
        }



        public bool Add(Entry entry)
        {
            try
            {
                using(var context = new EntriesContext(_path)) 
                { 
                    context.Add(entry); 
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(Entry entry)
        {
            try
            {
                using (var context = new EntriesContext(_path))
                {
                    context.Database
                        .ExecuteSqlRaw("DELETE FROM Entries WHERE Id={0}",
                        entry.Id);
                }

                return true;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
                // bei einem Fehler wird eine leere Liste zurückgegeben
                // ev. wäre null besser ...
                return false;
            }
        }

        public Entry? Find(string id)
        {
            try
            {
                using (var context = new EntriesContext(_path))
                {
                    var find = (from entry in context.Entries
                                   where entry.Id == id
                                   select entry).FirstOrDefault(); //erstes Elemnt oder null
                    return find;
                }
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
                // bei einem Fehler wird eine leere Liste zurückgegeben
                // ev. wäre null besser ...
                return null;
            }
        }
/*
       public List<Entry> GetAll()
        {
            try
            {
                using (var context = new EntriesContext(_path))
                {
                    var entries = (from entry in context.Entries
                                   select entry).ToList();
                    return entries;
                }

                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                // bei einem Fehler wird eine leere Liste zurückgegeben
                // ev. wäre null besser ...
                return new List<Entry>();
            }
        }
*/

       public List<Entry> GetAll()
        {
            try
            {
                using (var context = new EntriesContext(_path))
                {
                    /*
                    var to = "Saalfelden";
*/
                    var entries = context.Entries.FromSql
                        ($"SELECT * FROM Entries").ToList();

                    return entries;
                }

                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<Entry>();
            }
        }


        public bool Save()
        {
            try
            {
                using (var context = new EntriesContext(_path))
                {
                    context.SaveChanges();
                    
                }
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
            try
            {
                using (var context = new EntriesContext(_path))
                {
                    context.Entry(entry).State = EntityState.Modified;

                    context.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
