namespace PhoneBook;

public class Phonebook
{
    public string Name { get; set; }
    public string Phone { get; set; }
    
    /// <summary>
    /// Статичное поле для singletone.
    /// </summary>
    private static Phonebook _instance;
    /// <summary>
    /// Список абонентов.
    /// Хранится в формате имя;телефон
    /// </summary>
    List<Abonent> PhoneBooksList;

    /// <summary>
    /// Конструктор
    /// </summary>
    private Phonebook()
    {
        PhoneBooksList = new List<Abonent>();
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
        PhoneBooksList.Add(ab);
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
}
