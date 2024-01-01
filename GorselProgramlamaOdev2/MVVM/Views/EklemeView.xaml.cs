using GorselProgramlamaOdev2.MVVM.Models;
using GorselProgramlamaOdev2.MVVM.ViewModels;

namespace GorselProgramlamaOdev2.MVVM.Views;

public partial class EklemeView : ContentPage
{
	public EklemeView()
	{
		InitializeComponent();
	}

    private async void AddTaskClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as EklemeViewModel;
        var selectedCategory = vm.Categories.Where(x => x.IsSelected == true).FirstOrDefault();

        if (selectedCategory != null)
        {
            var task = new YapilacaklarModel
            {
                TaskName = vm.Task,
                CategoryId = selectedCategory.Id,

            };
            vm.Tasks.Add(task);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Invalid Selection", "You must select a catedory", "Ok");
        }

    }

    private async void AddCategoryClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as EklemeViewModel;

        var category = await DisplayPromptAsync("New Category", "Write the new Category name",
            maxLength: 15, keyboard: Keyboard.Text);

        var r = new Random();
        if (!string.IsNullOrEmpty(category))
        {
            vm.Categories.Add(new YapilacaklarCategories
            {
                Id = vm.Categories.Max(x => x.Id) + 1,
                Color = Color.FromRgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)).ToHex(),
                CategoryName = category
            });
        }

    }
}