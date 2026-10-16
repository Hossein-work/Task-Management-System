class InMemoryTaskRepository : IRepository
{
    public InMemoryTaskRepository()
    {
        tasks.Add(new TaskItem("title", "description", DateTime.Now));
    }
    private List<TaskItem> tasks { get; set; } = new List<TaskItem>();

    public void Add(TaskItem entity) 
    {
        tasks.Add(entity);
        ConsoleManager.ShowSucces("The operation was successful!");
    }

    public void Edit(Guid Id, string title, string describtion, DateTime dueTime)
    {
        try
        {
            TaskItem? item;
            if (GetTask(Id, out item))
            {
                TaskItem instance = new(title, describtion, dueTime);
                item.EditTask(instance);
            }
            else
                ConsoleManager.ShowError("Task not founded !");
        }
        catch
        {
            ConsoleManager.ShowError("The Edit operation was unsuccessful! \nPlease Try Again.");
        }
    }

    public void GetAll()
    {
        try
        {
            ConsoleManager.ShowGetAll(tasks);
        }
        catch
        {
            ConsoleManager.ShowError("The Get All operation was unsuccessful! \nPlease Try Again.");
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
                ConsoleManager.ShowError("Task not founded !");
        }
        catch
        {
            ConsoleManager.ShowError("The Get By Id operation was unsuccessful! \nPlease Try Again.");
        }
    }

    public void RemoveById(Guid Id)
    {
        if (GetTask(Id, out TaskItem? instance))
        {
            tasks.Remove(instance);

            ConsoleManager.ShowSucces("The operation was successful!");
        }
        else
        {
            ConsoleManager.ShowError("Task not founded !");
        }
    }


    private bool GetTask(Guid Id, out TaskItem? input)
    {
        TaskItem? instance = tasks.Find(x => x.GetId() == Id);
        input = instance != null ? instance : null;
        return instance != null;
    }
}
