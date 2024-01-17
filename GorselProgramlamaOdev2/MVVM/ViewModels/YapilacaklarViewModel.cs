using GorselProgramlamaOdev2.MVVM.Models;
using PropertyChanged;
using Firebase.Database;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace GorselProgramlamaOdev2.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class YapilacaklarViewModel
    {
        public ObservableCollection<YapilacaklarCategories> Categories { get; set; } = new ObservableCollection<YapilacaklarCategories>();
        public ObservableCollection<YapilacaklarModel> Tasks { get; set; } = new ObservableCollection<YapilacaklarModel>();

        public YapilacaklarViewModel()
        {
            FillDateAsync();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }


        public async void FillDateAsync()
        {
            Tasks.Clear();
            Categories.Clear();
            FireHelper fireHelper = new FireHelper();
            var res = await fireHelper.GetAllTasks();
           Tasks = new ObservableCollection<YapilacaklarModel>(res);
            var res2 = await fireHelper.GetAllCategories();
            Categories = new ObservableCollection<YapilacaklarCategories>(res2);

            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;



                c.PendingTasks = notCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }
            foreach (var t in Tasks)
            {
                var catColor =
                     (from c in Categories
                      where c.Id == t.CategoryId
                      select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }
    }
}
