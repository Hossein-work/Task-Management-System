class TaskItem
{
    public TaskItem(string title, string description, DateTime dueDate)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        DueDate = dueDate;
    }
    private readonly Guid Id;
    private string title;
    private string description;
    private DateTime duedate;

    public string Title
    {
        get => title;
        private set
        {
            title = CheckString(value);
        }
    }
    public string Description
    {
        get => description;
        private set
        {
            description = CheckString(value);
        }
    }
    public DateTime DueDate
    {
        get => duedate; private set => duedate = value;
    }
    public Guid GetId() => Id;
    private string CheckString(string enter) => string.IsNullOrEmpty(enter) ?
        throw new AggregateException("Cannot be null or without a value.") : enter;

    public virtual string GetDetails()
    {
        return description;
    }
    public void EditTask(TaskItem input)
    {
        title = input.title;
        description = input.description;
        duedate = input.duedate;
    }
}
