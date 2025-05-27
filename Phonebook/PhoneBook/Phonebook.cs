namespace PhoneBook;

public class Phonebook
{
    public string Name { get; set; }
    public string Phone { get; set; }
    
    private const string file = "abonents.txt";
    
    /// <summary>
    /// Статичное поле для singletone.
    /// </summary>
    private static Phonebook _instance;
    /// <summary>
    /// Список абонентов.
    /// </summary>
    List<Abonent> PhoneBooksList;

    /// <summary>
    /// Конструктор
    /// </summary>
    private Phonebook()
    {
        PhoneBooksList = GetListAbonentFromTxt();
    }
    public static Phonebook getInstance()
    {
        if (_instance == null)
        {
            _instance = new Phonebook();
        }
        return _instance;
    }

    /// <summary>
    /// Добавить абонента.
    /// </summary>
    /// <param name="name">Имя</param>
    /// <param name="Phone">Телефон</param>
    public void SaveAbonent(string Name, string Phone)
    {
        Abonent ab = new Abonent(Name, Phone);
        if (!CheckExistsAbonentInList(ab))
        {
            PhoneBooksList.Add(ab);
        }
        else
        {
            Console.WriteLine("Абонент уже существует.");
        }
    }
/// <summary>
/// Получение абонента по номеру телефона
/// </summary>
/// <param name="phone">Телефон</param>
/// <returns>Abonent or null</returns>
    public Abonent GetAbonentByPhone(string phone)
    {
        foreach (var ab in PhoneBooksList)
        {
            if (ab.Phone == phone)
            {
                return ab;
            }
        }
        return null;
    }

    public Abonent GetAbonentByName(string name)
    {
        foreach (var ab in PhoneBooksList)
        {
            if (ab.Name == name)
            {
                return ab;
            }
        }
        return null;
    }

    public void DeleteAbonent(Abonent ab)
    {
        if (PhoneBooksList.Contains(ab))
        {
            PhoneBooksList.Remove(ab);
            Console.WriteLine($"Абонент {ab.Name} с номером {ab.Phone} удален.");
        }
        else
        {
            Console.WriteLine($"Абонента {ab.Name} с номером {ab.Phone} не существует.");
        }
        
    }

    private bool CheckExistsAbonentInList(Abonent abonent)
    {
        foreach (var ab in PhoneBooksList)
        {
            if (ab.Name == abonent.Name && ab.Phone == abonent.Phone)
            {
                return true;
            }
        }
        return false;
    }
    
    private List<Abonent> GetListAbonentFromTxt()
    {
        List<Abonent> list = new List<Abonent>();

        if (!File.Exists(file))
        {
            Console.WriteLine("Файла с абонентами не существует. Будет создан новый список.");
            return list;
        }

        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(';');
                var ab = new Abonent(parts[0], parts[1]);
                list.Add(ab);
            }
        }
        return list;

    }

    public void SaveListToTxt()
    {
        
        using (StreamWriter writer = new StreamWriter((file), true))
        {
            foreach (var ab in PhoneBooksList)
            {
                writer.WriteLine(ab.Name + ";" + ab.Phone);
            }
        }
    }
}
