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
                    Phonebook.SaveAbonent();
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
            if (number < 1 || number > 4)
            {
                Console.WriteLine("Ошибка. Число от 1 до 4.");
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
    

}