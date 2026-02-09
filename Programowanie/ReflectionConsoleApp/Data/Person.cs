using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionConsoleApp.Data
{
    [Auditable("DomainModel")]
    public class Person : IIdentifiable
    {
        // Prywatne pole – przydatne do pokazania, ¿e refleksja mo¿e wejœæ „g³êbiej”
        private string _secretNote = "only-for-internal-use";

        // W³aœciwoœci
        public Guid Id { get; } = Guid.NewGuid();

        [Auditable("PII")]
        public string FirstName { get; set; }

        [Auditable("PII")]
        public string LastName { get; set; }

        public int Age { get; private set; }

        // Konstruktor domyœlny
        public Person() { }

        // Konstruktor z parametrami
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        // Metoda publiczna
        [Auditable("BusinessLogic")]
        public string GetDisplayName() => $"{FirstName} {LastName}";

        // Metoda przeci¹¿ona
        public string GetDisplayName(string format)
        {
            return format switch
            {
                "UPPER" => $"{FirstName} {LastName}".ToUpperInvariant(),
                "LOWER" => $"{FirstName} {LastName}".ToLowerInvariant(),
                _ => GetDisplayName()
            };
        }

        // Metoda prywatna (poka¿emy, ¿e da siê j¹ wywo³aæ)
        private string GetInternalCode() => $"{LastName}-{Age}-{_secretNote}";

        // Metoda generyczna (poka¿emy, jak pobraæ definicjê i zwi¹zaæ typ)
        public T Echo<T>(T value) => value;

        // Setter prywatny – poka¿emy, ¿e refleksj¹ mo¿na go ruszyæ
        private void SetAgeInternal(int age) => Age = age;
    }
}
