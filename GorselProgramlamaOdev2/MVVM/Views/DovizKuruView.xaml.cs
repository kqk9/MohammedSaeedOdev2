using GorselProgramlamaOdev2.MVVM.ViewModels;

namespace GorselProgramlamaOdev2.MVVM.Views;

public partial class DovizKuruView : ContentPage
{
    DovizKuruViewModel DovizViewModel = new DovizKuruViewModel();
    public DovizKuruView()
    {
        InitializeComponent();
        BindingContext = DovizViewModel;
    }

    private void OnAppearing(object sender, EventArgs e)
    {
        DovizViewModel.GetDoviz();
    }
}