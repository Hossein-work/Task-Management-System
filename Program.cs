using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

class TaskManager
{
    private const string endMessage = "Are you continuing? (Yes or No)";
    private const string welcome = "Welcome to my project!";
    private static readonly List<string> tools = new() 
    {
        "Exit","Get all task", "Remove task", "Edit task", "Add task" 
    };
    private static InMemoryTaskRepository repository = new InMemoryTaskRepository();
    public static void Main(string[] args)
    {
        ConsoleManager.Welcome(welcome, '-', 20);
        do
        {
            ConsoleManager.ShowToolsList(tools);
            ToolsManager();
        } while (ConsoleManager.CheckEndProgram(endMessage));

    }
    private static void ToolsManager()
    {
        ConsoleManager.CheckInputForTools(tools.Count -1,out byte output);
        switch (output)
        {
            case 0:
                break;
            case 1:
                repository.GetAll();
                break;
            case 2:
                RemoveManager(repository);
                break;
            case 3:
                EditManager(repository);
                break;
            case 4:
                AddManager(repository);
                break;
        }

    }
    private static void RemoveManager(InMemoryTaskRepository instanceRepository)
    {
        Guid id = ConsoleManager.RemoveCM();
        instanceRepository.RemoveById(id);
    }
    private static void AddManager(InMemoryTaskRepository instanceRepository)
    {
        ConsoleManager.AddCM(out object? task);

        TaskItem? instance = task as TaskItem;
        instanceRepository.Add(instance);
    }
    private static void EditManager(InMemoryTaskRepository instanceRepository)
    {
        ConsoleManager.EditCM(out Guid id, out string title, out string description);
        instanceRepository.Edit(id, title, description);
    }

}
