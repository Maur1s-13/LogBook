using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LogBook.Lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogBook.LogBookApp.ViewModels
{
    public partial class MainViewModel(IRepository repository) : ObservableObject
    {

        public string Header => "Fahrtenbuch";

        public object Entries { get; private set; }

        IRepository _repository = repository;


        [ObservableProperty]
        ObservableCollection<LogBook.Lib.Entry> ent = [];

        [RelayCommand]
        void LoadData()
        {
            var entries = _repository.GetAll();

            foreach (var entry in entries)
            {
                Ent.Add(entry);
            }
        }
    }
}
