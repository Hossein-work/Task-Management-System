using System.ComponentModel;

class InMemoryTaskRepository : IRepository<TaskItem>
{
    private readonly List<TaskItem> Tasks = new()
    {
        new TaskItem ("title1","des4",DateTime.Now),
        new TaskItem ("title2","des3",DateTime.Now),
        new TaskItem ("title3","des2",DateTime.Now),
        new TaskItem ("title4","des1",DateTime.Now),
    };

    public void Add(TaskItem entity)
    {
        try
        {
            Tasks.Add(entity);
        }
        catch
        {
            ConsoleManager.ShowBug("The add operation was unsuccessful! \nPlease Try Again.");
        }
    }

    public void GetAll()
    {
        try
        {
            ConsoleManager.ShowGetAll(Tasks);
        }
        catch
        {
            ConsoleManager.ShowBug("The add operation was unsuccessful! \nPlease Try Again.");
        }
    }

    public void GetById(Guid Id)
    {
        try
        {
            TaskItem? instance = Tasks.Find(x => x.GetId() == Id);
            if (instance == null)
                ConsoleManager.ShowBug("Task not founded !");
            else ConsoleManager.ShowInfo(instance);
        }
        catch
        {
            ConsoleManager.ShowBug("The add operation was unsuccessful! \nPlease Try Again.");
        }
    }

    public void RemoveById(Guid Id)
    {
        try
        {
            TaskItem? instance = Tasks.Find(x => x.GetId() == Id);
            if (instance == null)
                ConsoleManager.ShowBug("Task not founded !");
            else Tasks.Remove(instance);
        }
        catch
        {
            ConsoleManager.ShowBug("The add operation was unsuccessful! \nPlease Try Again.");
        }
    }
}
