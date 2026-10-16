using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
using System.Reflection;
using System.Collections.Specialized;
using System.Reflection.Metadata;

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
    public static bool CheckEndProgram(string endMessage)
    {
        Console.WriteLine(endMessage);
        string input = CheckYesOrNo();
        return input.Equals("yes");
    }
    private static string CheckYesOrNo()
    {
        do
        {
            string? input = Console.ReadLine();
            if (input.ToLower() == "yes" || input.ToLower() == "no")
                return input;

            else
                ShowBug("Please Enter Yes Or No !");

        } while (true);
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
            if (prop.Name != "Description")
            {
                var value = prop.GetValue(list);
                Console.WriteLine($"{prop.Name} : {value}");
            }
        }
        Console.WriteLine($"Description : {list.GetDetails()}");
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
    private static string GetTitle()
    {
        string? instance;
        do
        {
            Console.WriteLine("Please enter task title :");
            instance = Console.ReadLine();
            if (CheckInputIsNotEmpty(instance))
                break;
            else
                ShowBug("Title cannot be empty.");
        } while (true);
        return instance;
    }
    private static string GetDescription()
    {
        string? instance;
        do
        {
            Console.WriteLine("Please enter task descripton :");
            instance = Console.ReadLine();
            if (CheckInputIsNotEmpty(instance))
                break;
            else
                ShowBug("Description cannot be empty!");
        } while (true);
        return instance;
    }
    #region Add

    public static void AddCM(out object? task)
    {
        string? t = GetTitle();
        string? d = GetDescription();
        string? ty;

        do
        {
            Console.WriteLine("Please enter task type :");
            ShowType();
            ty = Console.ReadLine();
            if (CheckInputIsNotEmpty(ty))
                if (ty.CheckInputIsINT(out byte ob))
                {
                    task = Activator.CreateInstance(types[ob], t, d, DateTime.Now);
                    break;
                }
                else Console.WriteLine("Please enter a valid value !");
            else ShowBug("Type cannot be empty!");
        } while (true);
    }
    public static void EditMC(out Guid id, out string title, out string description)
    {
        id = GetId();

        Console.WriteLine("To edit a task:");
        title = GetTitle();
        description = GetDescription();
    }
    public static Guid RemoveMC() => GetId();
    private static Guid GetId()
    {
        string? i;
        do
        {
            Console.WriteLine("Please enter the ID (00000000-0000-0000-0000-000000000000) :");
            i = Console.ReadLine();
            if (CheckInputIsNotEmpty(i))
                if (Guid.TryParse(i, out Guid result))
                {
                    return result;
                }
                else Console.WriteLine("Please enter a valid value !");
            else ShowBug("Id cannot be empty!");

        } while (true);
    }
    private enum TaskType
    {
        Urgent,
        Normal
    }
    private static List<Type> types = new List<Type>()
    {
           typeof(TaskItem) ,
          typeof(UrgentTask) ,
    };

    private static void ShowType()
    {
        byte count = 1;
        foreach (TaskType value in Enum.GetValues(typeof(TaskType)))
        {
            Console.Write(count + ".");
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
