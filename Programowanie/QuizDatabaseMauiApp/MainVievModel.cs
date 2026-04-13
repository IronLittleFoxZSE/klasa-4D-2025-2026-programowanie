using QuizDatabaseMauiApp.Model;
using QuizRepositoryClassLibrary;
using QuizRepositoryClassLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDatabaseMauiApp
{
    public class MainVievModel : BindableObject
    {
        private Question question;

        public Question Question
        {
            get { return question; }
            set { question = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Answer> answers;

        public ObservableCollection<Answer> Answers
        {
            get { return answers; }
            set { answers = value; OnPropertyChanged(); }
        }

        private Answer selectedAnswer;

        public Answer SelectedAnswer
        {
            get { return selectedAnswer; }
            set { selectedAnswer = value; OnPropertyChanged(); }
        }

        private int countOfCorrect;

        public int CountOfCorrect
        {
            get { return countOfCorrect; }
            set { countOfCorrect = value; OnPropertyChanged(); }
        }

        private bool canAnswer;

        public bool CanAnswer
        {
            get { return canAnswer; }
            set { canAnswer = value; OnPropertyChanged(); }
        }

        private bool isQuizInProgress;

        public bool IsQuizInProgress
        {
            get { return isQuizInProgress; }
            set { isQuizInProgress = value; OnPropertyChanged(); }
        }



        private Command checkQuestionCommand;
        public Command CheckQuestionCommand
        {
            get
            {
                if (checkQuestionCommand == null)
                    checkQuestionCommand = new Command(
                        () =>
                        {

                            if (SelectedAnswer != null)
                            {
                                SelectedAnswer.Color = SelectedAnswer.IsCorrect ? "Green" : "Red";

                                if (SelectedAnswer.IsCorrect)
                                    CountOfCorrect++;
                                else
                                    Answers.First(a => a.IsCorrect).Color = "Green";
                            }


                            CanAnswer = false;
                        }
                        );
                return checkQuestionCommand;
            }
        }

        private Command nextQuestionCommand;
        public Command NextQuestionCommand
        {
            get
            {
                if (nextQuestionCommand == null)
                    nextQuestionCommand = new Command(
                        () =>
                        {
                            SetNextQuestion(Question.Id);
                        }
                        );
                return nextQuestionCommand;
            }
        }


        private QuizRepository quizRepository;

        public MainVievModel()
        {
            quizRepository = new QuizRepository();
            Answers = new ObservableCollection<Answer>();

            SetNextQuestion(null);
        }

        private void SetNextQuestion(int? id)
        {
            QuestionDto? questionDto = quizRepository.GetNextQuestion(id);
            Answers.Clear();

            if (questionDto != null)
            {
                Question = new Question() { Id = questionDto.Id, QuestionText = questionDto.QuestionText };


                foreach (AnswerDto answerDto in quizRepository.GetAnswers(Question.Id))
                {
                    Answers.Add(new Answer() { Id = answerDto.Id, AnswerText = answerDto.AnswerText, IsCorrect = answerDto.IsCorrect, Color = "Black" });
                }

                CanAnswer = true;
                IsQuizInProgress = true;
            }
            else
            {
                Question = new Question() { QuestionText = "KONIEC QUIZU" };
                IsQuizInProgress = false;
            }
        }
    }
}
