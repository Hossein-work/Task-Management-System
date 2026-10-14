class InMemoryTaskRepository : IRepository<TaskItem>
{
    List<TaskItem> Tasks = new()
    {
        new TaskItem ("title1","des4",DateTime.Now),
        new TaskItem ("title2","des3",DateTime.Now),
        new TaskItem ("title3","des2",DateTime.Now),
        new TaskItem ("title4","des1",DateTime.Now),
    };
    public void GetAll()
    {
        ConsoleManager.ShowGetAll(Tasks);
    }

    public void GetById(Guid Id)
    {
        TaskItem? instance = Tasks.Find(x => x.GetId() == Id);
        if (instance != null)   
            ConsoleManager.ShowBug("Task not founded !");
        else ConsoleManager.ShowInfo(instance);
    }

    public void RemoveById(Guid Id)
    {
        throw new NotImplementedException();
    }
}
