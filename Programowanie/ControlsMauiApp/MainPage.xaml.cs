using System.Collections.ObjectModel;

namespace ControlsMauiApp
{
    public partial class MainPage : ContentPage
    {
        private DateTime minimumDate;
        public DateTime MinimumDate
        {
            get { return minimumDate; }
            set { minimumDate = value; OnPropertyChanged(); }
        }

        private DateTime maximumDate;
        public DateTime MaximumDate
        {
            get { return maximumDate; }
            set { maximumDate = value; OnPropertyChanged(); }
        }

        private DateTime selectDate;
        public DateTime SelectDate
        {
            get { return selectDate; }
            set { selectDate = value; OnPropertyChanged(); }
        }

        private bool isLegalAge;
        public bool IsLegalAge
        {
            get { return isLegalAge; }
            set { isLegalAge = value; OnPropertyChanged(); }
        }

        private string selectedImage;
        public string SelectedImage
        {
            get { return selectedImage; }
            set { selectedImage = value; OnPropertyChanged(); }
        }

        private Command changeImage;
        public Command ChangeImage
        {
            get
            {
                if (changeImage == null)
                    changeImage = new Command(
                        () =>
                        {
                            currentImageNumber = (currentImageNumber + 1) % images.Count;
                            SelectedImage = images[currentImageNumber];
                        }
                        );
                return changeImage;
            }
        }

        private double progresDataLevel;
        public double ProgresDataLevel
        {
            get { return progresDataLevel; }
            set { progresDataLevel = value; OnPropertyChanged(); }
        }

        private Command changeProgresDataLevel;
        public Command ChangeProgresDataLevel
        {
            get
            {
                if (changeProgresDataLevel == null)
                    changeProgresDataLevel = new Command(
                        () =>
                        {
                            if (ProgresDataLevel <= 0
                                || ProgresDataLevel >= 1)
                                changePrograsDataLevel *= -1;
                            ProgresDataLevel += changePrograsDataLevel;
                        }
                        );
                return changeProgresDataLevel;
            }
        }

        private string favoriteAnimal;
        public string FavoriteAnimal
        {
            get { return favoriteAnimal; }
            set { favoriteAnimal = value; OnPropertyChanged(); }
        }

        private int currentImageNumber;
        private List<string> images;

        private double changePrograsDataLevel;
        public MainPage()
        {
            MinimumDate = new DateTime(2025, 1, 1);
            MaximumDate = new DateTime(2025, 12, 31);
            SelectDate = DateTime.Now;

            currentImageNumber = 0;
            images = new(){ "dotnet_bot.png", "dotnet_bot_two.png" };
            SelectedImage = images[currentImageNumber];

            changePrograsDataLevel = 0.1;
            ProgresDataLevel = 0.1;

            FavoriteAnimal = "Pies";

            InitializeComponent();
        }

        private TimeSpan selectTime;
        public TimeSpan SelectTime
        {
            get { return selectTime; }
            set { selectTime = value; OnPropertyChanged(); }
        }
    }
}
