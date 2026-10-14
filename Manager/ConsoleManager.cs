using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
using System.Reflection;

static class ConsoleManager
{
    public static void Welcome(string welcome, char signType, byte countSign)
    {
        for (int i = 0; i < countSign; i++)
            Console.Write(signType);
        Console.WriteLine();

        Console.WriteLine(welcome);
        for (int i = 0; i < countSign; i++)
            Console.Write(signType);
        Console.WriteLine();
    }
    public static void ShowToolsList(List<string> list)
    {
        byte counter = 1;
        foreach (var item in list)
        {
            Console.WriteLine($"{counter}. {item}");
            counter++;
        }
    }
    public static void ShowGetAll(List<TaskItem> list)
    {
        byte counter = 1;
        foreach (var item in list)
        {
            Console.WriteLine(counter + ".");
            ShowInfo(item);
            counter++;
            Console.WriteLine("-----------------");
        }
    }
    public static void ShowInfo(TaskItem list)
    {

        var properties = typeof(TaskItem).GetProperties();

        foreach (var prop in properties)
        {
            var value = prop.GetValue(list);
            Console.WriteLine($"{prop.Name} : {value}");
        }
    }

    public static void SendNotification(NotificationService.NotifType type, string message)
    {
        Console.WriteLine(type.ToString() + ':' + message);
        for (int i = 0; i < (message.Length + type.ToString().Length + 1); i++)
            Console.Write('-');
        Console.WriteLine();
    }

    public static void ShowBug(string bug)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(bug);
        Console.ResetColor();
    }
    public static void ShowSucces(string succes)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("---" + succes + "---");
        Console.ResetColor();
    }
}
