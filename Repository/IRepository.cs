interface IRepository<T>
{
    public void GetAll();
    public void GetById(Guid Id);
    public void RemoveById(Guid Id);
    public void Add(T entity);

}
