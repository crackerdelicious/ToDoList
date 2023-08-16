public class Task
{
    private static int _id = 1;
    public int TaskId { get; private set; }
    public string? TaskTitle { get; set; }
    public string? TaskDescription { get; set; }
    public bool TaskCompleted { get; set; }
    public Task(string title, string description)
    {
        TaskId = _id++;
        TaskTitle = title;
        TaskDescription = description;
        TaskCompleted = false;
    }
    public override string ToString()
    {
        char marked = TaskCompleted ? 'x' : ' ';
        return $"{TaskId}. [{marked}] {TaskTitle} - {TaskDescription}";
    }
}
