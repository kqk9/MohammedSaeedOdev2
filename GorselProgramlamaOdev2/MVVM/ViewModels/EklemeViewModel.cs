using GorselProgramlamaOdev2.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorselProgramlamaOdev2.MVVM.ViewModels
{
    public class EklemeViewModel
    {
        public YapilacaklarViewModel viewModel { get; set; } = new YapilacaklarViewModel();
        public string Task { get; set; }
        public ObservableCollection<YapilacaklarModel> Tasks { get; set; }
        public ObservableCollection<YapilacaklarCategories> Categories { get; set; }
    }
}
