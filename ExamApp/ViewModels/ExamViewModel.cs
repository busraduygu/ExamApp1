using System.Collections.Generic;

namespace ExamApp.ViewModels
{
    public class ExamViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<QuestionViewModel> Questions  { get; set; }
    }

    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
        public int rlt_Correct_Answer_Id { get; set; }
    }
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }


}
