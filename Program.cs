using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

class TaskManager
{
    private static readonly string Welcome = "Welcome to my project!";
    private static readonly List<string> Tools = new() { "Get all task", "Remove task", "Edit task", "Add task", "Exit" };
    public static void Main(string[] args)
    {
        ConsoleManager.Welcome(Welcome, '-', 20);
        Console.WriteLine("Please select an item:");
        ConsoleManager.ShowToolsList(Tools);
        sbyte input = Convert.ToSByte(Console.ReadLine());
        ToolsManager(input);


    }
    private static void ToolsManager(sbyte n)
    {
        InMemoryTaskRepository repository = new InMemoryTaskRepository();

        switch (n)
        {
            case 0:
                break;
            case 1:
                repository.GetAll();
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                AddManager(repository);
                break;
        }
    }
    private static void AddManager(InMemoryTaskRepository instance)
    {
        ConsoleManager.AddCM(out string title, out string description, out string type);   
        TaskItem task = type == "Urgent" ? new UrgentTask(title, description,DateTime.Now) :
            new TaskItem(title, description, DateTime.Now);
        instance.Add(task);
    }

}
