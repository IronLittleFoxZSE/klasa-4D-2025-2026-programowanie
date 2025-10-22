using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindableLayoutMauiApp.Models
{
    public class TodoTask : BindableObject
    {
        public string Title { get; set; }

        private bool isCompleted;
        public bool IsCompleted
        {
            get { return isCompleted; }
            set { isCompleted = value; OnPropertyChanged(); }
        }

        public int Column { get; set; }
        public int Row { get; set; }
    }
}
