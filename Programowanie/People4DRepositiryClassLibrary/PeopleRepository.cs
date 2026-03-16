using Microsoft.EntityFrameworkCore;
using People4DRepositiryClassLibrary.DTOs;
using People4DRepositiryClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People4DRepositiryClassLibrary
{
    /*
    * Pobierz osoby o wieku wiêkszym ni¿ 30 lat.
    * Pobierz osoby, których nazwisko zaczyna siê na „K”.
    * ZnajdŸ osoby z najmniejszym wiekiem.
    * Policz, ile osób jest w tabeli.
    * Zwróæ wszystkie unikalne imiona.
    * Zmieñ nazwisko wszystkich osób o nazwisku „Kowalski” na „Kowal”.
    * Dodaj wszystkim osobom 1 rok (symulacja urodzin).
    * Usuñ wszystkich, którzy maj¹ wiêcej ni¿ 80 lat.
    *  ZnajdŸ najstarsz¹ osobê i zmieñ jej nazwisko na „Najstarszy”.
    * Usuñ osoby m³odsze ni¿ œrednia wieku.
    * Zmieñ imiona na wersjê „WIELKIMI LITERAMI”.
    

    */

    public class PeopleRepository
    {
        private PeopleDBContext context;

        public PeopleRepository()
        {
            context = new PeopleDBContext();
        }

        //C - create

        public void AddNewPerson(string name, string surname, int age)
        {
            Person newPerson = new Person() { Name = name, Surname = surname, Age = age };

            context.People.Add(newPerson);

            context.SaveChanges();
        }

        //R - Read

        /*
        select *
        from people4d2026.people p
        left join addresses a on a.Id = p.AddressId
        order by Name, Surname

         */

        public List<Person> GetAllPeople()
        {
            return context.People
                .AsNoTracking()
                .Include(p => p.Address)
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Surname)
                .ToList();
        }

        public List<PersonDto> GetAllPeopleDto()
        {
            return context.People
                .AsNoTracking()
                .Include(p => p.Address)
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Surname)
                .Select(p => new PersonDto() { Id = p.Id, Name = p.Name, Surname = p.Surname, Age = p.Age, City = (p.Address != null ? p.Address.City : "") })
                .ToList();
        }

        //U - update

        public void UpdateName(int id, string newName)
        {
            Person? person = context.People.FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                person.Name = newName;

                context.SaveChanges();
            }
        }

        public void UpdatePerson(int id, string name, string surname, int age)
        {
            Person? person = context.People.FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                person.Name = name;
                person.Surname = surname;
                person.Age = age;

                context.SaveChanges();
            }
        }

        //D - delete

        public void DeletePerson(int id)
        {
            Person? person = context.People.FirstOrDefault(p => p.Id == id);

            if (person != null)
            {
                context.People.Remove(person);
                context.SaveChanges();
            }

        }

    }
}
