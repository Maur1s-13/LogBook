using LogBook.LogBookCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.LogBookApp.Services
{
    public class AlertService : IAlertService
    {
        public async void ShowAlert(string title, string message)
        {
            Application.Current.MainPage.Dispatcher.Dispatch(async () => {
                await ShowALertAsync(title, message);
            });

            
        }

        public Task ShowALertAsync(string title, string message)
        {
            return Application.Current.
                    MainPage.DisplayAlert(title, message, "OK");
        }
    }
}
