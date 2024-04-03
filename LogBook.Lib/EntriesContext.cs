using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.Lib
{
    public class EntriesContext : DbContext
    {

        public DbSet<Entry> Entries { get; set; }

        private string _path = string.Empty;

        public EntriesContext(string path)
        {
            _path = path;

            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            Debug.WriteLine(_path);

            optionsBuilder.UseSqlite($"Filename={_path}");

            //base.OnConfiguring(optionsBuilder);
        }

    }
}
