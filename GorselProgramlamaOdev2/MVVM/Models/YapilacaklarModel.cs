using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorselProgramlamaOdev2.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]

    public class YapilacaklarModel
    {

        public String TaskName { get; set; }
        public bool Completed { get; set; }
        public int CategoryId { get; set; }
        public string TaskColor { get; set; }
        public bool IsSelected { get; internal set; }
        public string ID { get; set; }
    }
}
