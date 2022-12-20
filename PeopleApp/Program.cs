using Microsoft.VisualBasic.FileIO;
using Models;
using Newtonsoft.Json;
using PeopleApp.Properties;
using Services.InMemory;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

//Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-de");

//var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
//path = Path.Combine(path, "people.json");
//var service = new Services.InFile.EntityService<Person>(path);
var service = new EntityAsyncService<Person>();

await service.CreateAsync(new Person() { Name = "Adam Adamski", Age = 34 });
await service.CreateAsync(new Person() { Name = "Ewa Ewowska", Age = 34 });
await service.CreateAsync(new Person() { Name = "Wiesława Wiesławowska", Age = 34 });
await service.CreateAsync(new Person() { Name = "Ewa Adamska", Age = 34 });
await service.CreateAsync(new Person() { Name = "Adam Ewowski", Age = 34 });

bool exit = false;

do
{
    Console.Clear();
    await ShowItems();
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
            await Delete();
            break;
        case 'c':
        case '3':
            await Edit();
            break;
        case 'd':
        case '4':
            exit = true;
            break;
        case '5':
            await ToJson();
            break;
        case '6':
            await ToXml();
            break;
    }


} while (!exit);

async Task ToXml()
{
    int id = AskForId();
    var item = await  service.ReadAsync(id);
    /*var serializer = new XmlSerializer(item.GetType());
    string xml = xDocument.ToString();
    Console.ReadLine();

    item = null;

    var xDocument = XDocument.Parse(xml);

    serializer = new XmlSerializer(typeof(Person));
    using (var memoryStream = new MemoryStream())
    {
        xDocument.Save(memoryStream);
        memoryStream.Position = 0;
         item = (Person?)serializer.Deserialize(memoryStream);
    }*/

    var json = JsonConvert.SerializeObject(item);
    var xDocument = JsonConvert.DeserializeXNode(json, nameof(Person));
    Console.WriteLine(  xDocument.ToString() );
    Console.ReadLine();
}

async Task ToJson()
{
    int id = AskForId();
    var item = await service.ReadAsync(id);

    /*JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
    jsonSerializerOptions.IgnoreReadOnlyProperties = true;
    jsonSerializerOptions.WriteIndented = true;

    string json = JsonSerializer.Serialize(item, jsonSerializerOptions);*/

    var jsonSerializerSettings = new JsonSerializerSettings();
    jsonSerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

    string json = JsonConvert.SerializeObject(item, jsonSerializerSettings);

    Console.WriteLine(json);
    Console.ReadLine();
    item = null;

    /*item = JsonSerializer.Deserialize<Person>(json);*/

    item = JsonConvert.DeserializeObject<Person>(json, jsonSerializerSettings);

}

async Task Edit()
{
    int id = AskForId();
    var item = await service.ReadAsync(id);
    if (item == null)
        return;
    EditPerson(item);

    await service.UpdateAsync(id, item);
}

async Task Delete()
{
    int id = AskForId();
    await service.DeleteAsync(id);
}

async void Add()
{
    var person = new Person();
    EditPerson(person);

    await service.CreateAsync(person);
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

async Task ShowItems()
{
    foreach (var item in await service.ReadAsync())
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