using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
using System.Reflection;
using System.Collections.Specialized;

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
    #region Add
    public static void AddCM(out string title, out string description, out string type)
    {
        string? t;
        string? d;
        string? ty;
        do
        {
            Console.WriteLine("Please enter task title :");
            t = Console.ReadLine();
            if (CheckInputIsNotEmpty(t))
                break;
            else
                ShowBug("Title cannot be empty.");
        } while (true);
        title = t;
        do
        {
            Console.WriteLine("Please enter task descripton :");
            d = Console.ReadLine();
            if (CheckInputIsNotEmpty(d))
                break;
            else
                ShowBug("Description cannot be empty!");
        } while (true);
        description = d;
        do
        {
            Console.WriteLine("Please enter task type :");
            ShowType();
            ty = Console.ReadLine();
            if (CheckInputIsNotEmpty(ty))
                if (ty.CheckInputIsINT(out byte ob))
                {
                    type = ob == 1 ? type = TaskType.Urgent.ToString() : type = TaskType.Normal.ToString();
                    break;
                }
                else Console.WriteLine("Please enter a valid value !");
            else ShowBug("Type cannot be empty!");
        } while (true);
    }
    private enum TaskType
    {
        Urgent,
        Normal
    }
    private static void ShowType()
    {
        byte count = 1;
        foreach (TaskType value in Enum.GetValues(typeof(TaskType)))
        {
            Console.Write(count+".");
            count++;
            Console.WriteLine(value);
        }
    }
    private static bool CheckInputIsNotEmpty(string input) => !string.IsNullOrEmpty(input);
    private static bool CheckInputIsINT(this string input, out byte ob)
    {
        if (byte.TryParse(input, out ob))
            if (ob == 1 || ob == 2)
                return true;
            else return false;
        else return false;

    }
    #endregion
}
