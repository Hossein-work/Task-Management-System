interface IRepository
{
    public void GetAll();
    public void GetById(Guid Id);
    public void RemoveById(Guid Id);
    public void Add(TaskItem entity);
    public void Edit(Guid Id, string title, string describtion,DateTime dueTime);
}
