namespace QuizApp.Models
{
    public class Quiz
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Questions = new List<Question>();
        }

        public int GetTotalPoints()
        {
            return Questions.Sum(q => q.Points);
        }
    }
}
