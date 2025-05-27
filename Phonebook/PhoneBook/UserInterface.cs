using System.Xml;

namespace PhoneBook;

public class UserInterface
{
    public static void Start()
    {
        Phonebook Phonebook = Phonebook.getInstance();
        Abonent ab = new Abonent();
        int UserInput;
        while ((UserInput = GetUserChoiseFromMainMenu()) != 0)
        {
            switch (UserInput)
            {
                case 1:
                    Phonebook.Name = GetNameByUserInput();
                    Phonebook.Phone = GetPhoneByUserInput();
                    
                    Phonebook.SaveAbonent(Phonebook.Name, Phonebook.Phone);
                    break;
                case 2:
                    Phonebook.Phone = GetPhoneByUserInput();
                    ab = Phonebook.GetAbonentByPhone(Phonebook.Phone);
                    break;
                case 3:
                    Phonebook.Name = GetNameByUserInput();
                    ab = Phonebook.GetAbonentByName(Phonebook.Name);
                    break;
                case 4:
                    var (value, choise) = GetUserChoiseFromDeleteMenu();
                    if (choise == "0")
                    {
                        break;
                    }
                    else
                    {
                        switch (choise)
                        {
                            case "1":
                                ab = Phonebook.GetAbonentByPhone(value);
                                if (ab != null)
                                {
                                    Phonebook.DeleteAbonent(ab);
                                }
                                else
                                {
                                    Console.WriteLine("Абонент не найден.");
                                }
                                
                                break;
                            case "2":
                                ab = Phonebook.GetAbonentByName(value);
                                if (ab != null)
                                {
                                    Phonebook.DeleteAbonent(ab);
                                }
                                else
                                {
                                    Console.WriteLine("Абонент не найден.");
                                }
                                break;
                        }
                        break;
                    }


            }

            if ((UserInput == 2 || UserInput == 3))
            {
                if (ab != null)
                {
                    Console.WriteLine($"Имя: {ab.Name}. Телефон: {ab.Phone}");
                }
                else
                {
                    Console.WriteLine("Абонент не найден.");
                }
            }
        }
    }
    
    /// <summary>
    /// Получение пользовательского ответа.
    /// </summary>
    /// <returns>int [1-4]</returns>
    private static int GetUserChoiseFromMainMenu()
    {
        Console.WriteLine(@"Меню.
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
                return GetUserChoiseFromMainMenu();
            }
            else
            {
                return number;
            }
        }
        else
        {
            Console.WriteLine("Ошибка. Введите целое число.");
            return GetUserChoiseFromMainMenu();
        }
    }

    /// <summary>
    /// Получение имени от пользователя
    /// </summary>
    /// <returns></returns>
    private static string GetNameByUserInput()
    {
        Console.WriteLine("Введите имя абонента: ");
        return Console.ReadLine();
    }
    
    /// <summary>
    /// Получение телефона от пользователя
    /// </summary>
    /// <returns></returns>
    private static string GetPhoneByUserInput()
    {
        Console.WriteLine("Введите номер телефона: ");
        return Console.ReadLine();
    }

    private static (string, string) GetUserChoiseFromDeleteMenu()
    {
        Console.WriteLine("Как удалить абонента?\n1. По номеру телефона.\n2. По имени.\n0. Возврат в меню.");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                return (GetPhoneByUserInput(), input);
            case "2":
                return (GetNameByUserInput(), input);
            case "0":
                return ("", input);
            default:
                Console.WriteLine("Вы ввели неверное значение.");
                return GetUserChoiseFromDeleteMenu();
        }
    }
    
}