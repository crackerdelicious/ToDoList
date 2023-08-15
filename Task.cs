public class Task
{
    private static int _id = 1;
    public Task(string title, string description)
    {
        TaskId = _id++;
        TaskTitle = title;
        TaskDescription = description;
        TaskCompleted = false;
    }
    public int TaskId { get; private set; }
    public string? TaskTitle { get; private set; }
    public string? TaskDescription { get; private set; }
    public bool TaskCompleted { get; set; }

    public override string ToString()
    {
        char marked = TaskCompleted ? 'x' : ' ';
        return $"{TaskId}. [{marked}] {TaskTitle} - {TaskDescription}";
    }
}