using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VmModel
{
     public class QuestionVM
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string QuestionNumber { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
    }
}
