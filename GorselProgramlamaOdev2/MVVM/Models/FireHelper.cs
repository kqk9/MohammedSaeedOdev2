using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorselProgramlamaOdev2.MVVM.Models
{
   public class FireHelper
    {

        FirebaseClient client = new FirebaseClient("https://gorselodev-df921-default-rtdb.firebaseio.com/");
        public async Task<bool> AddTask (YapilacaklarModel model)
        {
            var res = await client.Child("Tasks").PostAsync(model);
            
            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> AddCategory(YapilacaklarCategories model)
        {
            var res = await client.Child("Categories").PostAsync(model);

            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<YapilacaklarModel>> GetAllTasks()
        {
            var res = (await client.Child("Tasks").OnceAsync<YapilacaklarModel>()).Select(x => new YapilacaklarModel
            {
                TaskName = x.Object.TaskName, CategoryId = x.Object.CategoryId , Completed = x.Object.Completed
                , ID = x.Object.ID, IsSelected = x.Object.IsSelected,TaskColor = x.Object.TaskColor
            }).ToList();

            return res;
        }

        public async Task<List<YapilacaklarCategories>> GetAllCategories()
        {
            var res = (await client.Child("Categories").OnceAsync<YapilacaklarCategories>()).Select(x => new YapilacaklarCategories
            {
              Id= x.Object.Id, IsSelected = x.Object.IsSelected,CategoryName = x.Object.CategoryName
              , Color = x.Object.Color, PendingTasks = x.Object.PendingTasks , Percentage = x.Object.Percentage
            }).ToList();

            return res;
        }
        public async void DeleteOne(string ID)
        {
            await client.Child("Tasks").Child(ID).DeleteAsync();
        }

       
    }
}
