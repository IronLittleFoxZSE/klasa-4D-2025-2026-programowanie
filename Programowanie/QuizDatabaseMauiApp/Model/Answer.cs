

namespace QuizDatabaseMauiApp.Model;

public class Answer : BindableObject
{
    public int Id { get; set; }

    public string AnswerText { get; set; } = null!;

    public bool IsCorrect { get; set; }

    private string color;

    public string Color
    {
        get { return color; }
        set { color = value; OnPropertyChanged(); }
    }

}
