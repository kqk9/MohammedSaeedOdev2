namespace GorselProgramlamaOdev2.MVVM.Views;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}



    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            Application.Current.Resources["BackgroundColor"] = Application.Current.Resources["BackgroundDark"];
            Application.Current.Resources["TextColor"] = Application.Current.Resources["TextDark"];
            Application.Current.Resources["CardColor"] = Application.Current.Resources["CardDark"];

        }
        else
        {
            Application.Current.Resources["BackgroundColor"] = Application.Current.Resources["BackgroundLight"];
            Application.Current.Resources["TextColor"] = Application.Current.Resources["TextLight"];
            Application.Current.Resources["CardColor"] = Application.Current.Resources["CardLight"];
        }
    }
}