using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LogBook.Lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.LogBookCore.ViewModels
{
    public partial class ReportViewModel : ObservableObject
    {
        IRepository _repository;
        public ReportViewModel(IRepository repository)
        {
            IRepository _repository = repository;
        }

        

        private bool _isLoaded = false;

        [ObservableProperty]
        ObservableCollection<LogBook.Lib.Entry> _ent = [];

        

        [RelayCommand]
        void LoadData()

        {
            if (!_isLoaded)
            {
                var entries = _repository.GetAll();

                foreach (var entry in entries)
                {
                    Ent.Add(entry);
                }
                _isLoaded = true;
            }

        }

    }
}
