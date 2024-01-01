using GorselProgramlamaOdev2.MVVM.ViewModels;

namespace GorselProgramlamaOdev2.MVVM.Views;

public partial class HaberlerView : ContentPage
{
    HaberlerViewModel vm = new HaberlerViewModel();

    public HaberlerView()
    {
        InitializeComponent();
        BindingContext = vm;

    }

    private async void OnAppearing(object sender, EventArgs e)
    {
        await vm.GetHaberler();
    }



    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var pro = e.CurrentSelection;
        Navigation.PushAsync(new HaberView
        {

            BindingContext = vm,
            SelectedHaber = vm.SelectedHaber,
        });
    }
}