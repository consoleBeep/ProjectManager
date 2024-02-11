namespace EFGetStarted;

public class Task
{
    public int TaskId { get; set; }
    public string Name { get; set; }
    public List<Todo> Todos { get; } = new();
}

public class Todo
{
    public int TodoId { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
    public int TaskId { get; set; }
    public Task Task { get; set; }
}
public class Team
{
    public int TeamID { get; set; }
    public string Name { get; set; }
    public List<TeamWorker> Workers { get; set; } = new List<TeamWorker>();
    public Task? CurrentTask { get; set; }
    public List<Task>? Tasks { get; set; }
}

public class Worker
{
    public int WorkerID { get; set; }
    public string Name { get; set; }
    public List<TeamWorker> Teams { get; set; } = new List<TeamWorker>();
    public Todo? CurrentTodo { get; set; }
    public List<Todo>? Todos { get; set; }
}

public class TeamWorker
{
    public int TeamID { get; set; }
    public Team? Team { get; set; }
    public int WorkerID { get; set; }
    public Worker Worker { get; set; }
}
