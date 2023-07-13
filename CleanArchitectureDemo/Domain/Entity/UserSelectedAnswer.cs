using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class UserSelectedAnswer
    {
        public int Id { get; set; }
        public string SelectAnswer { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Register Register { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Quizquestions Quizquestions { get; set; }
    }
}
