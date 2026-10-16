using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
using System.Reflection;
using System.Collections.Specialized;
using System.Reflection.Metadata;

static class ConsoleManager
{
    private enum TaskType
    {
        Normal,
        Urgent,
    }
    private static List<Type> types = new List<Type>()
    {
           typeof(TaskItem) ,
          typeof(UrgentTask) ,
    };

    #region Start&End
    internal static void Welcome(string welcome, char signType, byte countSign)
    {
        for (int i = 0; i < countSign; i++)
            Console.Write(signType);
        Console.WriteLine();

        Console.WriteLine(welcome);
        for (int i = 0; i < countSign; i++)
            Console.Write(signType);
        Console.WriteLine();
    }
    internal static bool CheckEndProgram(string endMessage)
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
    #endregion

    #region Showing
    public static void ShowToolsList(List<string> list)
    {
        Console.WriteLine("Please select an item:");
        byte counter = 0;
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
    #endregion

    #region Notifications
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
        Console.Write(bug);
        Console.ResetColor();
        Console.WriteLine();
    }
    public static void ShowSucces(string succes)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Write("---" + succes + "---");
        Console.ResetColor();
        Console.WriteLine();
    }
    #endregion

    #region GetingInput
    public static string GetTitle()
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
        instance = instance.Truncate();
        return instance;
    }
    public static string GetDescription()
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
    public static Guid GetId()
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
    #endregion

    #region CM

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
                if (ty.CheckInputIsINT(out byte ob, 0, types.Count))
                {
                    task = Activator.CreateInstance(types[ob - 1], t, d, DateTime.Now);
                    break;
                }
                else Console.WriteLine("Please enter a valid value !");
            else ShowBug("Type cannot be empty!");
        } while (true);
    }
    public static void EditCM(out Guid id, out string title, out string description)
    {
        id = GetId();

        Console.WriteLine("To edit a task:");
        title = GetTitle();
        description = GetDescription();
    }
    public static Guid RemoveCM() => GetId();
    #endregion

    #region Checking
    private static bool CheckInputIsNotEmpty(string input) => !string.IsNullOrEmpty(input);
    private static bool CheckInputIsINT(this string input, out byte ob, int start, int end)
    {
        if (byte.TryParse(input, out ob))
            if (ob <= end && ob > start)
                return true;
            else return false;
        else return false;
    }

    internal static void CheckInputForTools(int end,out byte output)
    {
        do
        {
            string? input = Console.ReadLine();
            if (input.CheckInputIsINT(out byte ob,-1, end))
            {
                output = ob;
                break;
            }
            else Console.WriteLine("Please enter a valid value !");

        } while (true);
    }//used in Program class
    #endregion
}
