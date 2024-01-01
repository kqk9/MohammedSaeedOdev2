using GorselProgramlamaOdev2.MVVM.ViewModels;

namespace GorselProgramlamaOdev2.MVVM.Views;

public partial class HavaDurumuView : ContentPage
{
	public HavaDurumuView()
	{
		InitializeComponent();
        BindingContext = new HavaDurumuViewModel();
    }
}