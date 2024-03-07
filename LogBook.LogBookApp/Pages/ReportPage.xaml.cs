using LogBook.LogBookCore.ViewModels;

namespace LogBook.LogBookApp.Pages;

public partial class ReportPage : ContentPage
{
	public ReportPage(ReportViewModel viewmodel)
	{
		InitializeComponent();
		this.BindingContext = viewmodel;	
	}
}