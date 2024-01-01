using GorselProgramlamaOdev2.MVVM.Models;

namespace GorselProgramlamaOdev2.MVVM.Views;

public partial class HaberView : ContentPage
{
    public Item SelectedHaber { get; set; } = null;
    public HaberView()
	{
		InitializeComponent();
	}


    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await ShareUri(SelectedHaber.link, Share.Default);
    }

    public async Task ShareUri(string uri, IShare share)
    {
        await share.RequestAsync(new ShareTextRequest
        {
            Uri = uri,
            Title = SelectedHaber.title
        });
    }

  
}