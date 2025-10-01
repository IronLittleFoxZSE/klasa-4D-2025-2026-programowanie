using ControlsMauiApp.Data;
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

        private TimeSpan selectTime;
        public TimeSpan SelectTime
        {
            get { return selectTime; }
            set { selectTime = value; OnPropertyChanged(); }
        }

        private int stepperValue;
        public int StepperValue
        {
            get { return stepperValue; }
            set { stepperValue = value; OnPropertyChanged(); }
        }

        private bool isOn;
        public bool IsOn
        {
            get { return isOn; }
            set { isOn = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> AnimalCollection { get; set; }

        private string selectedAnimal;
        public string SelectedAnimal
        {
            get { return selectedAnimal; }
            set { selectedAnimal = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Car> CarsCollection { get; set; }
        private Car selectedCar;
        public Car SelectedCar
        {
            get { return selectedCar; }
            set { selectedCar = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Monkey> Monkeys { get; private set; }

        #region TableView

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsNewsletterEnabled { get; set; }

        public ObservableCollection<string> Themes { get; }

        private string selectedTheme;
        public string SelectedTheme
        {
            get => selectedTheme;
            set
            {
                if (selectedTheme != value)
                {
                    selectedTheme = value;
                    OnPropertyChanged();
                }
            }
        }

        private Command aboutCommand;
        public Command AboutCommand
        {
            get
            {
                if (aboutCommand == null)
                    aboutCommand = new Command(
                        () =>
                        {

                        }
                        );
                return aboutCommand;
            }
        }

        #endregion

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

            AnimalCollection = new ObservableCollection<string>()
            {
                "Pies",
                "Kot",
                "Krowa"
            };
            SelectedAnimal = AnimalCollection.First();

            CarsCollection = new ObservableCollection<Car>()
            {
                new Car(){ Name="Fiat", Description = "Kultowy mały fiat"},
                new Car(){ Name="Audi", Description = "A tutaj jego opis"},
            };
            SelectedCar = CarsCollection.First();

            CreateMonkeyCollection();

            Themes = new ObservableCollection<string>
            {
                "Jasny",
                "Ciemny",
                "Systemowy"
            };
            SelectedTheme = Themes.First();

            InitializeComponent();
        }

        void CreateMonkeyCollection()
        {
            Monkeys =
            [
                new Monkey
                {
                    Name = "Baboon",
                    Location = "Africa & Asia",
                    Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
                    ImageName = "baboon.jpg"
                },
                new Monkey
                {
                    Name = "Capuchin Monkey",
                    Location = "Central & South America",
                    Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
                    ImageName = "capuchin_monkey.jpg"
                },
                new Monkey
                {
                    Name = "Blue Monkey",
                    Location = "Central and East Africa",
                    Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
                    ImageName = "blue_monkey.jpg"
                },
            ];
        }
    }
}
