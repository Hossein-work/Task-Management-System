interface IRepository
{
    public void GetAll();
    public void GetById(Guid Id);
    public void RemoveById(Guid Id);
    public void Add<T>(T entity) where T : TaskItem;
    public void Edit(Guid Id, string title, string describtion);
}
