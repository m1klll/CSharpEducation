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
    List<string> PhoneBooksList;

    /// <summary>
    /// Конструктор
    /// </summary>
    private Phonebook()
    {
        PhoneBooksList = new List<string>();
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
        PhoneBooksList.Add(Name + ";" + Phone);
    }

    public string GetAbonentByPhone(string phone)
    {
        foreach (var item in PhoneBooksList)
        {
            var abonent = item.Split(';');
            if (abonent[1] == phone)
            {
                return abonent[0];
            }
            

        }
        return "";
    }
}
