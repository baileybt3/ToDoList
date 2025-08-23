/* ToDoList App
** This program is a ToDoList organizer.
** Made By: Brandon Bailey
** 8/23/2025
*/
using System;
using System.Collections.Generic;

public class ToDoList
{

    static List<string> tasks = new List<string>();
    public static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("\nPlease select and option: ");
            Console.WriteLine("1. View To-Do List");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Quit");

            string input = Console.ReadLine()!;

            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewList();
                        break;

                    case 2:
                        AddTask();
                        break;

                    case 3:
                        CompleteTask();
                        break;

                    case 4:
                        DeleteTask();
                        break;

                    case 5:
                        Console.WriteLine(" See ya! ");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please select a valid option");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number.");
            }
        }

    }

    public static void ViewList()
    {
        int index = 1;
        Console.WriteLine(" --- To-Do List ---\n");

        if (tasks.Count == 0)
        {
            Console.WriteLine("Your To-Do list is empty");
            return;
        }

        foreach (string task in tasks)
        {

            Console.WriteLine($"{index}: {task}");
            index++;
        }

    }

    public static void AddTask()
    {
        Console.WriteLine(" --- Add Task ---");
        string newTask = Console.ReadLine()!;
        tasks.Add(newTask);
    }

    public static void CompleteTask()
    {

        Console.WriteLine(" --- Select Task to Complete ---");

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {tasks[i]}");
        }
        Console.Write("Enter the number of the task to mark complete: ");
        string input = Console.ReadLine()!;

        if (int.TryParse(input, out int index) && index > 0 && index <= tasks.Count)
        {
            if (!tasks[index - 1].EndsWith("[x]")) {
                tasks[index - 1] += " [x]";
                Console.WriteLine($"Task marked complete: {tasks[index - 1]}");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

    }

    public static void DeleteTask()
    {
        Console.WriteLine(" --- Delete Task  ---");

        if (tasks.Count == 0)
        {
            Console.WriteLine("Your To-Do List is empty");
            return;
        }

        Console.WriteLine("Enter the number of the task you want to delete: ");
        string input = Console.ReadLine()!;

        if (int.TryParse(input, out int index) && index > 0 && index <= tasks.Count)
        {
            Console.WriteLine($"Removed: {tasks[index - 1]}");
            tasks.RemoveAt(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }


}