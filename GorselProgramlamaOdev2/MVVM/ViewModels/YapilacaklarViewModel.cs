using GorselProgramlamaOdev2.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorselProgramlamaOdev2.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class YapilacaklarViewModel
    {
        public ObservableCollection<YapilacaklarCategories> Categories { get; set; }
        public ObservableCollection<YapilacaklarModel> Tasks { get; set; }

        public YapilacaklarViewModel()
        {
            FillDate();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }


        private void FillDate()
        {
            Categories = new ObservableCollection<YapilacaklarCategories>()
           {
               new YapilacaklarCategories
               {
                   Id = 1 ,
                   CategoryName = "Test" ,
                   Color = "#CF14DF"
               }
           };
            Tasks = new ObservableCollection<YapilacaklarModel>
               {
                    new YapilacaklarModel
                    {
                         TaskName = "testtt",
                         Completed = false,
                         CategoryId = 1
                    }
               };
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
