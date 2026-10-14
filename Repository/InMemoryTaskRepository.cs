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
            ConsoleManager.ShowSucces("The operation was successful!");
            ConsoleManager.SendNotification(NotificationService.NotifType.Sms, "A new task was added.");
        }
        catch
        {
            ConsoleManager.ShowBug("The add operation was unsuccessful! \nPlease Try Again.");
        }

    }

    public void Edit(Guid Id,string title, string describtion)
    {
        try
        {
            TaskItem? item;
            if (GetTask(Id, out item))
            {
                TaskItem instance = new(title, describtion,item.DueDate);
                item.EditTask(instance);
            }
            else
                ConsoleManager.ShowBug("Task not founded !");
        }
        catch
        {
            ConsoleManager.ShowBug("The Edit operation was unsuccessful! \nPlease Try Again.");
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
            ConsoleManager.ShowBug("The Get All operation was unsuccessful! \nPlease Try Again.");
        }
    }

    public void GetById(Guid Id)
    {
        try
        {
            TaskItem? item;
            if (GetTask(Id, out item))
                ConsoleManager.ShowInfo(item);
            else
                ConsoleManager.ShowBug("Task not founded !");
        }
        catch
        {
            ConsoleManager.ShowBug("The Get By Id operation was unsuccessful! \nPlease Try Again.");
        }
    }

    private bool GetTask(Guid Id, out TaskItem? input)
    {
        TaskItem? instance = Tasks.Find(x => x.GetId() == Id);
        input = instance != null ? instance : null;
        return instance != null;
    }

    public void RemoveById(Guid Id)
    {
        try
        {
            TaskItem? instance = Tasks.Find(x => x.GetId() == Id);
            if (instance != null)
                Tasks.Remove(instance);
            else
            {
                ConsoleManager.ShowBug("Task not founded !");
                return;
            }

            ConsoleManager.ShowSucces("The operation was successful!");
            ConsoleManager.SendNotification(NotificationService.NotifType.Sms, $"A task titled {instance.Title} was deleted.");

        }
        catch
        {
            ConsoleManager.ShowBug("The remove operation was unsuccessful! \nPlease Try Again.");
        }
    }
}
