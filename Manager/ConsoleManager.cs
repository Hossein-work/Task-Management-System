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
                ShowError("Please Enter Yes Or No !");

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

    public static void ShowError(string bug)
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
                ShowError("Title cannot be empty.");
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
                ShowError("Description cannot be empty!");
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
            else ShowError("Id cannot be empty!");

        } while (true);
    }
    public static DateTime GetDueTime()
    {
        string? t;
        do
        {
            Console.WriteLine("Please enter the Due Time (MM/dd/yyyy H:mm) :");
            t = Console.ReadLine();
            if (CheckInputIsNotEmpty(t))
                if (DateTime.TryParse(t, out DateTime result))
                {
                    return result;
                }
                else Console.WriteLine("Please enter a valid value !");
            else ShowError("Due Time cannot be empty!");

        } while (true);
    }
    public static byte GetTaskType()
    {
        string? type;
        do
        {
            Console.WriteLine("Please enter task type :");
            ShowType();
            type = Console.ReadLine();
            if (CheckInputIsNotEmpty(type))
                if (type.CheckInputIsINT(out byte ob, 1, types.Count))    
                    return ob;  
                else Console.WriteLine("Please enter a valid value !");
            else ShowError("Type cannot be empty!");
        } while (true);
    }
    #endregion

    #region CM

    public static void AddCM(out object? task)
    {
        string? title = GetTitle();
        string? descrip = GetDescription();
        DateTime? duetime = GetDueTime();
        byte? type = GetTaskType();
        task = Activator.CreateInstance(types[(int)(type - 1)], title, descrip, duetime);

    }
    public static void EditCM(out Guid id, out string title, out string description,out DateTime dueTime)
    {
        id = GetId();

        Console.WriteLine("To edit a task:");
        title = GetTitle();
        description = GetDescription();
        dueTime = GetDueTime();
    }
    public static Guid RemoveCM() => GetId();
    #endregion

    #region Checking
    private static bool CheckInputIsNotEmpty(string input) => !string.IsNullOrEmpty(input);
    private static bool CheckInputIsINT(this string input, out byte ob, int start, int end)
    {
        if (byte.TryParse(input, out ob))
            if (ob <= end && ob >= start)
                return true;
            else return false;
        else return false;
    }

    internal static void CheckInputForTools(int end,out byte output)
    {
        do
        {
            string? input = Console.ReadLine();
            if (input.CheckInputIsINT(out byte ob,0, end))
            {
                output = ob;
                break;
            }
            else Console.WriteLine("Please enter a valid value !");

        } while (true);
    }//used in Program class
    #endregion
}
