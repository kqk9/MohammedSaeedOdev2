using GorselProgramlamaOdev2.MVVM.Models;
using GorselProgramlamaOdev2.MVVM.ViewModels;
using PropertyChanged;

namespace GorselProgramlamaOdev2.MVVM.Views;
[AddINotifyPropertyChangedInterface]
public partial class EklemeView : ContentPage
{

   public FireHelper fireHelper = new FireHelper();
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
            var res = await fireHelper.AddTask(task);
            vm.viewModel.FillDateAsync();
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
           await fireHelper.AddCategory(new YapilacaklarCategories
            {
                Id = vm.Categories.Max(x => x.Id) + 1,
                Color = Color.FromRgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)).ToHex(),
                CategoryName = category
            });
            vm.viewModel.FillDateAsync();
        }

    }


}