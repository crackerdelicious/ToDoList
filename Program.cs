using System;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>
            {
                new Task("Walking Dogs", "Fisby, Fodo, Lego"),
                new Task("Buy Groceries", "Fish, Milk, Pork, Chicken"),
                new Task("Playing with Kids", "Anya, Lorel"),
                new Task("Learn Programming", "C#, Python, JavaScripts"),
                new Task("Go for a walk", "From home to park"),
                new Task("Writing Diary", "List what have done, and plan tomorrow.")
            };

            int choice;
            do
            {
                Console.WriteLine("\nTo-Do List Application\n");
                Console.WriteLine("1. Add a new task");
                Console.WriteLine("2. View tasks");
                Console.WriteLine("3. Mark a task as completed");
                Console.WriteLine("4. Quit");
                Console.Write("\nEnter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddTask(tasks);
                            break;
                        case 2:
                            ViewTasks(tasks);
                            break;
                        case 3:
                            MarkAsCompleted(tasks);
                            break;
                        case 4:
                            Console.WriteLine("Goodbye!");
                            break;
                        default:
                            Console.WriteLine("You did not select any choices we have.\nPlease select a choice 1 - 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.\n");
                }
            } while (choice != 4);
        }

        static void AddTask(List<Task> tasks)
        {
            bool result = false;
            do
            {
                Console.Write("Enter task title: ");
                string? taskTitle = Console.ReadLine();

                if (string.IsNullOrEmpty(taskTitle) || string.IsNullOrWhiteSpace(taskTitle))
                {
                    Console.WriteLine("Task title can't be null. Please provide a task title.\n");
                }
                else
                {
                    Console.Write("Enter task description: ");
                    string? taskDescription = Console.ReadLine();
                    if (string.IsNullOrEmpty(taskDescription) || string.IsNullOrWhiteSpace(taskDescription))
                        taskDescription = "No description for this task.";

                    tasks.Add(new Task(taskTitle, taskDescription));
                    Console.WriteLine($"\nTask \"{taskTitle}\" added.\n");
                    result = true;
                }
            } while (!result);
        }

        static void ViewTasks(List<Task> tasks)
        {
            if (tasks.Count != 0)
            {
                Console.WriteLine("\nTasks:");
                foreach (Task task in tasks)
                {
                    Console.WriteLine(task);
                }
            }
            else
            {
                Console.WriteLine("\nThere's no task assigned yet.\n");
            }
        }

        static void MarkAsCompleted(List<Task> tasks)
        {
            if (tasks.Count != 0)
            {
                foreach (Task task in tasks)
                {
                    Console.WriteLine(task);
                }
                bool marked = false;
                do
                {
                    Console.Write("\nEnter the index of the task to mark as completed: ");
                    if (int.TryParse(Console.ReadLine(), out int taskId))
                    {
                        Task? targetTask = tasks.Find(task => task.TaskId == taskId);
                        if (targetTask != null) targetTask.TaskCompleted = true;
                        marked = true;
                    }
                    else
                    {
                        Console.WriteLine("\nNo tasks were found.\n");
                    }
                } while (!marked);
            }
            else
            {
                Console.WriteLine("\nThere's no task assigned yet.\n");
            }
        }
    }
}