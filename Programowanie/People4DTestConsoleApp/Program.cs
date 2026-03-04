

//People4DTestConsoleApp


using People4DRepositiryClassLibrary;
using People4DRepositiryClassLibrary.Models;

PeopleRepository peopleRepository = new PeopleRepository();

List<Person> people = peopleRepository.GetAllPeople();

Console.WriteLine("Lista wszystkich osób posortowanych po imieniu i nazwisku");
foreach (Person person in people)
{
    Console.WriteLine($"{person.Id} {person.Name} {person.Surname} lat {person.Age}");
}

people.Last().Name = "XXXXXXXX";

/*
peopleRepository.AddNewPerson("Marek", "Kowalski", 99);

people = peopleRepository.GetAllPeople();

Console.WriteLine("Lista wszystkich osób posortowanych po imieniu i nazwisku");
foreach (Person person in people)
{
    Console.WriteLine($"{person.Id} {person.Name} {person.Surname} lat {person.Age}");
}
*/

peopleRepository.UpdateName(8, "Ewelina");