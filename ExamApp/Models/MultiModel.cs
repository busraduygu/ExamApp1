using ExamApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models
{
    public class MultiModel
    {
        public MultiModel()
        {
        }

        public MultiModel(List<Data> datas,ExamViewModel examViewModel)
        {
            this.Datas = datas;
            this.ExamViewModel = examViewModel;
        }
        public List<Data> Datas { get; set; }
        public ExamViewModel ExamViewModel { get; set; }
    }
}
