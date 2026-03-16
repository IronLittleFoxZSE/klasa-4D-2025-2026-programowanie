

using People4DRepositiryClassLibrary;
using People4DRepositiryClassLibrary.DTOs;
using PeopleDatabaseMauiApp.ViewModelModels;
using System.Collections.ObjectModel;

namespace PeopleDatabaseMauiApp;

internal class MainVievModel : BindableObject
{
    public ObservableCollection<Person> People { get; set; }

    private Command? refreshPeopleCommand = null;
    public Command RefreshPeopleCommand
    {
        get 
        {
            if (refreshPeopleCommand == null)
                refreshPeopleCommand = new Command(
                    ()=>
                    {
                        People.Clear();
                        foreach (PersonDto person in repository.GetAllPeopleDto())
                        {
                            People.Add(new Person() { Id = person.Id, Name = person.Name, Surname = person.Surname, Age = person.Age, City = person.City});
                        }
                    }
                    );
            return refreshPeopleCommand; 
        }
    }

    private Command? updatePersonCommand = null;
    public Command UpdatePersonCommand
    {
        get
        {
            if (updatePersonCommand == null)
                updatePersonCommand = new Command(
                    () =>
                    {
                        if (personToUpdate == null)
                            return;
                        repository.UpdatePerson(PersonToUpdate.Id, PersonToUpdate.Name, PersonToUpdate.Surname, PersonToUpdate.Age);
                        
                        SelectedPerson.Name = PersonToUpdate.Name;
                        SelectedPerson.Surname = PersonToUpdate.Surname;
                        SelectedPerson.Age = PersonToUpdate.Age;
                    }
                    );
            return updatePersonCommand;
        }
    }

    private Command? selectedPersonChangeCommand = null;
    public Command SelectedPersonChangeCommand
    {
        get
        {
            if (selectedPersonChangeCommand == null)
                selectedPersonChangeCommand = new Command(
                    () =>
                    {
                        PersonToUpdate = GetPersonCopy(SelectedPerson);
                    }
                    );
            return selectedPersonChangeCommand;
        }
    }

    private Person selectedPerson;

    public Person SelectedPerson
    {
        get { return selectedPerson; }
        set 
        { 
            selectedPerson = value; 
            OnPropertyChanged();
        }
    }

    private Person personToUpdate;

    public Person PersonToUpdate
    {
        get { return personToUpdate; }
        set { personToUpdate = value; OnPropertyChanged(); }
    }

    PeopleRepository repository;

    public MainVievModel()
    {
        People = new ObservableCollection<Person>();
        repository = new PeopleRepository();
    }

    private Person GetPersonCopy(Person person)
    {
        if (person == null)
            return null;
        return new Person() { Id = person.Id, Name = person.Name, Surname=person.Surname, Age = person.Age };
    }

}

