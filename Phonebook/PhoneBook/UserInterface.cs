namespace PhoneBook;

public class UserInterface
{
    public static void Start()
    {
        Phonebook Phonebook = Phonebook.getInstance();
        int UserInput;
        while ((UserInput = GetUserChoise()) != 0)
        {
            switch (UserInput)
            {
                case 1:
                    Phonebook.Name = GetName();
                    Phonebook.Phone = GetPhone();
                    
                    Phonebook.SaveAbonent(Phonebook.Name, Phonebook.Phone);
                    break;
                case 2:
                    string phone = GetPhone();
                    string name = Phonebook.GetAbonentByPhone(phone);
                    
                    Console.WriteLine($"Имя {name}, телефон: {phone}");
                    break;
            }
        }
    }
    
    /// <summary>
    /// Получение пользовательского ответа.
    /// </summary>
    /// <returns>int [1-4]</returns>
    public static int GetUserChoise()
    {
        Console.WriteLine(@"Phonebook
1. Добавить абонента.
2. Получить абонента по номеру телефона.
3. Получить номер телефона по имени.
4. Удалить абонента.
0. Завершить программу.");

        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number < 0 || number > 4)
            {
                Console.WriteLine("Ошибка. Число от 0 до 4.");
                return GetUserChoise();
            }
            else
            {
                return number;
            }
        }
        else
        {
            Console.WriteLine("Ошибка. Введите целое число.");
            return GetUserChoise();
        }
    }

    private static string GetName()
    {
        Console.WriteLine("Введите имя абонента: ");
        return Console.ReadLine();
    }
    private static string GetPhone()
    {
        Console.WriteLine("Введите номер телефона: ");
        return Console.ReadLine();
    }
    

}