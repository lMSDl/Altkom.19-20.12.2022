using Microsoft.VisualBasic.FileIO;
using Models;
using PeopleApp.Properties;
using Services.InMemory;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

//Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-de");


var service = new PeopleService();

service.Create(new Person() { Name = "Adam Adamski", Age = 34 });
service.Create(new Person() { Name = "Ewa Ewowska", Age = 34 });
service.Create(new Person() { Name = "Wiesława Wiesławowska", Age = 34 });
service.Create(new Person() { Name = "Ewa Adamska", Age = 34 });
service.Create(new Person() { Name = "Adam Ewowski", Age = 34 });

bool exit = false;

do
{
    Console.Clear();
    ShowItems();
    ShowMenu();

    var input = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch(input)
    {
        case 'a':
        case '1':
            Add();
            break;
        case 'b':
        case '2':
            Delete();
            break;
        case 'c':
        case '3':
            Edit();
            break;
        case 'd':
        case '4':
            exit = true;
            break;
        case '5':
            ToJson();
            break;
        case '6':
            ToXml();
            break;
    }


} while (!exit);

void ToXml()
{
    int id = AskForId();
    var item = service.Read(id);
    var serializer = new XmlSerializer(item.GetType());
    using var memoryStream = new MemoryStream();
    serializer.Serialize(memoryStream, item);
    var xml = Encoding.Default.GetString(memoryStream.ToArray());
    Console.WriteLine(xml);
    Console.ReadLine();
}

void ToJson()
{
    int id = AskForId();
    var item = service.Read(id);

    JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
    jsonSerializerOptions.IgnoreReadOnlyProperties = true;
    jsonSerializerOptions.WriteIndented = true;

    string json = JsonSerializer.Serialize(item, jsonSerializerOptions);

    Console.WriteLine(json);
    Console.ReadLine();
}

void Edit()
{
    int id = AskForId();
    var item = service.Read(id);
    if (item == null)
        return;
    EditPerson(item);

    service.Update(id, item);
}

void Delete()
{
    int id = AskForId();
    service.Delete(id);
}

void Add()
{
    var person = new Person();
    EditPerson(person);

    service.Create(person);
}

int AskForId()
{
    Console.WriteLine("Podaj id:");
    var input = Console.ReadLine();

    int id;
    //metody try zazwyczaj zwracają informację o powodzeniu akcji i przyjmują parametr wyjściowy (out) do zwrócenia rzeczywistego rezultatu
    if(!int.TryParse(input, out id))
    {
        return AskForId();
    }
    return id;

    /*try
    {
        var id = int.Parse(input);
        return id;
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message);
        return AskForId();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return 0;
    }*/
}

void ShowItems()
{
    foreach (var item in service.Read())
    {
        Console.WriteLine(item);
    }
    Console.WriteLine();
}

static void ShowMenu()
{
    Console.WriteLine(Resources.menu_add);
    Console.WriteLine(Resources.menu_delete);
    Console.WriteLine(Resources.menu_edit);
    Console.WriteLine(Resources.menu_close);
    Console.WriteLine("5. JSON");
    Console.WriteLine("6. XML");
}

static void EditPerson(Person item)
{
    Console.WriteLine(Resources.provideName);
    item.Name = Console.ReadLine();


    int age;
    do
    {
        Console.WriteLine(Resources.provideAge);
    } while (!int.TryParse(Console.ReadLine(), out age));

    item.Age = age;
}