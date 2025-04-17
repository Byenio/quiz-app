namespace QuizApp.Model
{
    public class Question
    {
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public int Points { get; set; }

        public Question(string text, List<Answer> answers, int points)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));

            if (answers == null || answers.Count != 4)
                throw new ArgumentException("Question must have exactly 4 answers.", nameof(answers));

            if (!answers.Any(a => a.IsCorrect))
                throw new ArgumentException("At least one answer must be correct.", nameof(answers));

            if (points <= 0)
                throw new ArgumentOutOfRangeException(nameof(points), "Points must be positive.");

            Answers = answers;
            Text = text;
            Points = points;
        }
    }
}
