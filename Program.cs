using System;
using System.Linq;
using EFGetStarted;
using Microsoft.EntityFrameworkCore;
using Task = EFGetStarted.Task;

using var db = new BloggingContext();
SeedTasks(db);
PrintIncompleteTasksAndTodos();
seedWorkers(db);
PrintTeamsWithoutTasks();

void SeedTasks(BloggingContext context)
{
    var task1 = new Task
    {
        Name = "Produce software",
    };

    task1.Todos.Add(new Todo { Description = "Write code", IsDone = false });
    task1.Todos.Add(new Todo { Description = "Compile source", IsDone = false });
    task1.Todos.Add(new Todo { Description = "Test program", IsDone = false });

    var task2 = new Task
    {
        Name = "Brew coffee",
    };

    task2.Todos.Add(new Todo { Description = "Pour water", IsDone = false });
    task2.Todos.Add(new Todo { Description = "Pour coffee", IsDone = false });
    task2.Todos.Add(new Todo { Description = "Turn on", IsDone = false });

    context.Tasks.AddRange(task1, task2);
    context.SaveChanges();
}

 static void PrintIncompleteTasksAndTodos()
{
    using (var context = new BloggingContext())
    {
        var tasks = context.Tasks
            .Include(task => task.Todos)
            .Where(task => task.Todos.Any(todo => !todo.IsDone));

        foreach (var task in tasks)
        {
            Console.WriteLine($"Task: {task.Name}");
            foreach (var todo in task.Todos)
            {
                if (!todo.IsDone)
                {
                    Console.WriteLine($"-{todo.Description}");
                }
            }
        }
    }
}
 static void seedWorkers(BloggingContext context)
 {

     var tasks = context.Tasks.Include(t => t.Todos).ToList();
     var todos = tasks.SelectMany(t => t.Todos).ToList();

     var frontendTeam = new Team { Name = "Frontend", CurrentTask = tasks[0]};
     var backendTeam = new Team { Name = "Backend", CurrentTask = tasks[1] };
     var testersTeam = new Team { Name = "Testere", CurrentTask = tasks[2]};

     var workers = new List<Worker>
     {
         new Worker { Name = "Steen Secher", CurrentTodo = todos[0] },
         new Worker { Name = "Ejvind Møller", CurrentTodo = todos[1] },
         new Worker { Name = "Konrad Sommer", CurrentTodo = todos[2]},
         new Worker { Name = "Sofus Lotus" },
         new Worker { Name = "Remo Lademann" },
         new Worker { Name = "Ella Fanth" },
         new Worker { Name = "Anne Dam" }
     };

     var teamWorkers = new List<TeamWorker>
     {
         new TeamWorker { Team = frontendTeam, Worker = workers[0] },
         new TeamWorker { Team = frontendTeam, Worker = workers[1] },
         new TeamWorker { Team = frontendTeam, Worker = workers[2] },
         new TeamWorker { Team = backendTeam, Worker = workers[2] },
         new TeamWorker { Team = backendTeam, Worker = workers[3] },
         new TeamWorker { Team = backendTeam, Worker = workers[4] },
         new TeamWorker { Team = testersTeam, Worker = workers[5] },
         new TeamWorker { Team = testersTeam, Worker = workers[6] },
         new TeamWorker { Team = testersTeam, Worker = workers[0] }
     };


     context.TeamWorkers.AddRange(teamWorkers);

     context.SaveChanges();
 }
 static void PrintTeamsWithoutTasks()
 {
     using (var context = new BloggingContext())
     {
         // Get all teams that have no current task
         var teamsWithoutTasks = context.Teams
             .Where(t => t.CurrentTask == null)
             .ToList();

         // Print the names of the teams without tasks
         foreach (var team in teamsWithoutTasks)
         {
             Console.WriteLine(team.Name);
         }
     }
 }