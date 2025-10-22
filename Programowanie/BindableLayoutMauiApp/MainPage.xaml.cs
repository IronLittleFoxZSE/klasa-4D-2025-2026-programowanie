using BindableLayoutMauiApp.Models;
using System.Collections.ObjectModel;

namespace BindableLayoutMauiApp
{
    public partial class MainPage : ContentPage
    {
        /*private List<TodoTask> todoTasks;
        public List<TodoTask> TodoTasks
        {
            get { return todoTasks; }
            set { todoTasks = value; OnPropertyChanged(); }
        }*/

        public ObservableCollection<TodoTask> TodoTasks { get; set; }

        public string NewTitle { get; set; }
        public MainPage()
        {
            TodoTasks = new ObservableCollection<TodoTask>()
            {
                new TodoTask(){Title = "Zadanie pierwsze", IsCompleted = false, Column=1, Row=1},
                new TodoTask(){Title = "Zadanie drugie", IsCompleted = false},
                new TodoTask(){Title = "Zadanie trzecie", IsCompleted = true},
                new TodoTask(){Title = "Zadanie czwarte", IsCompleted = false},
            };
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //TodoTasks = new List<TodoTask>();
            TodoTasks.Add(new TodoTask() { Title = NewTitle, IsCompleted = false });
        }
    }
}
