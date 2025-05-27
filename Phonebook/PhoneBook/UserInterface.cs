namespace PhoneBook;

public class UserInterface
{
    public static void Start()
    {
        Phonebook Phonebook = Phonebook.getInstance();
        Abonent ab = new Abonent();
        int UserInput;
        while ((UserInput = GetUserChoise()) != 0)
        {
            switch (UserInput)
            {
                case 1:
                    Phonebook.Name = GetNameByUserInput();
                    Phonebook.Phone = GetPhoneByUserInput();
                    
                    Phonebook.SaveAbonent(Phonebook.Name, Phonebook.Phone);
                    break;
                case 2:
                    string phone = GetPhoneByUserInput();
                    ab = Phonebook.GetAbonentByPhone(phone);
                    break;
                case 3:
                    string name = GetNameByUserInput();
                    ab = Phonebook.GetAbonentByName(name);
                    break;
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

    private static string GetNameByUserInput()
    {
        Console.WriteLine("Введите имя абонента: ");
        return Console.ReadLine();
    }
    private static string GetPhoneByUserInput()
    {
        Console.WriteLine("Введите номер телефона: ");
        return Console.ReadLine();
    }
    

}