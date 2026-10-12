class InMemoryTaskRepository : IRepository<TaskItem>
{
    List<TaskItem> Tasks = new();
    public void GetAll()
    {
        throw new NotImplementedException();
    }

    public void GetById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public void RemoveById(Guid Id)
    {
        throw new NotImplementedException();
    }
}
