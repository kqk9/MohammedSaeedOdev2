using GorselProgramlamaOdev2.MVVM.Models;
using GorselProgramlamaOdev2.MVVM.ViewModels;

namespace GorselProgramlamaOdev2.MVVM.Views;

public partial class Yapilacaklar : ContentPage
{
    private YapilacaklarViewModel mainViewModel = new YapilacaklarViewModel();
    public Yapilacaklar()
	{
		InitializeComponent();
        BindingContext = mainViewModel;
    }

    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        mainViewModel.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var taskView = new EklemeView
        {
            BindingContext = new EklemeViewModel
            {
                Tasks = mainViewModel.Tasks,
                Categories = mainViewModel.Categories,
            }
        };
        Navigation.PushAsync(taskView);
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (sender is ImageButton deleteButton && deleteButton.BindingContext is YapilacaklarModel taskToDelete)
        {
            bool userConfirmed = await DisplayAlert("Silinsin mi?", "Silmeyi onayla", "Evet", "Hayir");

            if (userConfirmed)
            {
                mainViewModel.Tasks.Remove(taskToDelete);
                mainViewModel.UpdateData();
            }
        }
    }

}