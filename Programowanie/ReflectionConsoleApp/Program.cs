


//using ReflectionConsoleApp.Data;

//Person person = new Person();

// 1) Pobranie obiektu Type na ró¿ne sposoby
using ReflectionConsoleApp.Data;
using System.Reflection;

Type personType1 = typeof(Person);                      // kompilacja
Type? personType2 = Type.GetType("ReflectionConsoleApp.Data.Person"); // z pe³nej nazwy (wymaga poprawnego assembly-qualified name, jeœli spoza bie¿¹cego assembly)

Console.WriteLine($"Type: {personType1.FullName}");
Console.WriteLine();

// 2) Enumeracja cz³onów (w³aœciwoœci, metody, pola, interfejsy)
Console.WriteLine("=== W³aœciwoœci ===");
foreach (var prop in personType1.GetProperties(BindingFlags.Public | BindingFlags.Instance))
{
    Console.WriteLine($"- {prop.Name} : {prop.PropertyType.Name}");
}

Console.WriteLine("\n=== Metody (publiczne instancji) ===");
foreach (var method in personType1.GetMethods(BindingFlags.Public | BindingFlags.Instance))
{
    var parameters = method.GetParameters();
    string signature = $"{method.Name}({string.Join(", ", parameters.Select(p => p.ParameterType.Name + " " + p.Name))}) : {method.ReturnType.Name}";
    Console.WriteLine($"- {signature}");
}

Console.WriteLine("\n=== Pola (w tym prywatne) ===");
foreach (var field in personType1.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
{
    Console.WriteLine($"- {field.Name} ({field.Attributes}) : {field.FieldType.Name}");
}

Console.WriteLine("\n=== Implementowane interfejsy ===");
foreach (var iface in personType1.GetInterfaces())
{
    Console.WriteLine($"- {iface.Name}");
}

// 3) Odczyt atrybutów (custom attribute)
Console.WriteLine("\n=== Atrybuty klasy ===");
foreach (var attr in personType1.GetCustomAttributes(inherit: true))
{
    Console.WriteLine($"- {attr.GetType().Name}");
    if (attr is AuditableAttribute aud)
        Console.WriteLine($"  Category = {aud.Category}");
}

// 4) Tworzenie instancji dynamicznie (Activator)
Console.WriteLine("\n=== Tworzenie instancji ===");
object instanceDefault = Activator.CreateInstance(personType1)!; // konstruktor domyœlny
object instanceParam = Activator.CreateInstance(personType1, "Jan", "Kowalski", 30)!;

// Wpisywanie wartoœci do w³aœciwoœci poprzez refleksjê
var firstNameProp = personType1.GetProperty("FirstName");
var lastNameProp = personType1.GetProperty("LastName");
firstNameProp!.SetValue(instanceDefault, "£ukasz");
lastNameProp!.SetValue(instanceDefault, "Felisek");

// 5) Wywo³anie metody publicznej
Console.WriteLine("\n=== Wywo³anie publicznej metody GetDisplayName ===");
var getDisplayName = personType1.GetMethod("GetDisplayName", new Type[] { });
string displayName = (string)getDisplayName!.Invoke(instanceDefault, null)!;
Console.WriteLine($"DisplayName: {displayName}");

// 6) Wywo³anie przeci¹¿onej metody z parametrem
Console.WriteLine("\n=== Wywo³anie przeci¹¿onej metody GetDisplayName(string) ===");
var getDisplayNameFmt = personType1.GetMethod("GetDisplayName", new[] { typeof(string) });
string displayNameUpper = (string)getDisplayNameFmt!.Invoke(instanceDefault, new object[] { "UPPER" })!;
Console.WriteLine($"DisplayName UPPER: {displayNameUpper}");

// 7) Wywo³anie metody prywatnej
Console.WriteLine("\n=== Wywo³anie metody prywatnej GetInternalCode ===");
var internalCodeMethod = personType1.GetMethod("GetInternalCode", BindingFlags.Instance | BindingFlags.NonPublic);
string internalCode = (string)internalCodeMethod!.Invoke(instanceDefault, null)!;
Console.WriteLine($"InternalCode: {internalCode}");

// 8) Odczyt i zapis prywatnego pola
Console.WriteLine("\n=== Dostêp do prywatnego pola _secretNote ===");
var secretField = personType1.GetField("_secretNote", BindingFlags.Instance | BindingFlags.NonPublic);
Console.WriteLine($"Secret before: {secretField!.GetValue(instanceDefault)}");
secretField.SetValue(instanceDefault, "changed-by-reflection");
Console.WriteLine($"Secret after: {secretField.GetValue(instanceDefault)}");

// 9) Wywo³anie metody z prywatnym setterem wieku
Console.WriteLine("\n=== Wywo³anie prywatnego SetAgeInternal ===");
var setAgeInternal = personType1.GetMethod("SetAgeInternal", BindingFlags.Instance | BindingFlags.NonPublic);
setAgeInternal!.Invoke(instanceDefault, new object[] { 43 });
var ageProp = personType1.GetProperty("Age", BindingFlags.Instance | BindingFlags.Public);
Console.WriteLine($"Age after private setter: {ageProp!.GetValue(instanceDefault)}");

// 10) Metoda generyczna – zamkniêcie typu i wywo³anie
Console.WriteLine("\n=== Wywo³anie metody generycznej Echo<T> ===");
var echoOpenGeneric = personType1.GetMethod("Echo", BindingFlags.Instance | BindingFlags.Public);
var echoClosedGeneric = echoOpenGeneric!.MakeGenericMethod(typeof(int)); // T=int
int echoResult = (int)echoClosedGeneric.Invoke(instanceDefault, new object[] { 123 })!;
Console.WriteLine($"Echo<int>(123) = {echoResult}");

Console.WriteLine("\n=== KONIEC DEMA ===");