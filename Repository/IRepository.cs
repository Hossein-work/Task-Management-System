interface IRepository
{
    protected void GetAll();
    protected void GetById(Guid Id);
    protected void RemoveById(Guid Id);
    protected void Add<T>(T entity) where T : TaskItem;
    protected void Edit(Guid Id, string title, string describtion);
}
