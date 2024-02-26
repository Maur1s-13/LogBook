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
        ObservableCollection<LogBook.Lib.Entry> _ent = [];

        #region Properties

        [ObservableProperty]
        DateTime _start = DateTime.Now;

        [ObservableProperty]
        DateTime _end = DateTime.Now;

        [ObservableProperty]
        string _description = string.Empty;

        [ObservableProperty]
        string _numberPlate = string.Empty;

        [ObservableProperty]
        int _startKM = 0;

        [ObservableProperty]
        int _endKM = 0;

        [ObservableProperty]
        string _from = string.Empty;

        [ObservableProperty]
        string _to = string.Empty;

        #endregion



        [RelayCommand]
        void LoadData()
        {
            var entries = _repository.GetAll();

            foreach (var entry in entries)
            {
                Ent.Add(entry);
            }
        }

        [RelayCommand]
        void Add()
        {
            Lib.Entry entrySaalfelden = new(

            DateTime.Now.AddDays(3),
            DateTime.Now.AddDays(3).AddMinutes(20),
            25500, 25514,
            "ZE-XY123",
            "Zell am See",
            "Saalfelden");

            var result = _repository.Add(entrySaalfelden);
            if (result)
            {
                this.Ent.Add(entrySaalfelden);
            }

        }


    }
}
