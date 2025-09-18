﻿/* 
 *To-Do List App
 * A console-based task manager.
 * Author: Brandon Bailey
 * Date: 8/23/2025
 */
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a to-do list containing multiple tasks.
/// </summary>
public class ToDoList
{
    static List<TaskItem> tasks = new List<TaskItem>();

    public static void Main(string[] args)
    {
        int choice = 0;

        Console.WriteLine("\n === Welcome to your To-Do List === ");
        while (choice != 6)
        {
            Console.WriteLine("\nPlease select an option: ");
            Console.WriteLine("1. View To-Do List");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Incomplete Task");
            Console.WriteLine("5. Delete Task");
            Console.WriteLine("6. Quit");

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
                        IncompleteTask();
                        break;

                    case 5:
                        DeleteTask();
                        break;

                    case 6:
                        Console.WriteLine(" See ya! ");
                        break;

                    default:
                        Console.WriteLine("\nInvalid option. Please select a valid option");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number.");
            }
        }

    }

    /// <summary>
    /// Displays all tasks in to-do list, sorted by priority and description.
    /// </summary>
    public static void ViewList()
    {
        Console.WriteLine("\n=== To-Do List ===\n");

        if (tasks.Count == 0)
        {
            Console.WriteLine("Your To-Do list is empty");
            return;
        }

        ShowTasks();

    }

    /// <summary>
    /// Prompt user to add task to to-do list with description, and priority (high, medium, low)
    /// </summary>
    public static void AddTask()
    {
        Console.WriteLine(" --- Add Task ---");
        Console.Write("Enter task description: ");
        string desc = Console.ReadLine()!;

        Console.Write("\nEnter priority  (1 = High, 2 = Medium, 3 = Low): ");
        int priorityChoice;

        while (!int.TryParse(Console.ReadLine(), out priorityChoice) || priorityChoice < 1 || priorityChoice > 3)
        {
            Console.Write("Invalid input. Please enter 1, 2, or 3: ");
        }

        Priority priority = (Priority)priorityChoice;
        tasks.Add(new TaskItem(desc, priority));
        Console.WriteLine($"Added: {desc} (Priority: {priority})");
    }


    /// <summary>
    /// Select a selected task in the lsit to be marked as complete [x].
    /// </summary>
    public static void CompleteTask()
    {

        Console.WriteLine(" --- Select Task to Complete ---");

        var sortedTasks = ShowTasks();

        Console.Write("\nEnter the number of the task to mark complete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= sortedTasks.Count)
        {
            sortedTasks[index - 1].IsCompleted = true;
            Console.WriteLine($"Task marked complete: {sortedTasks[index - 1].Description}");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

    }

    /// <summary>
    /// Mark a selected task in the list as incomplete [ ].
    /// </summary>
    public static void IncompleteTask()
    {
        Console.WriteLine(" --- Select Task to Mark as Incomplete --- ");

        var sortedTasks = ShowTasks();

        Console.Write("\nEnter the number of the task to unmark complete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= sortedTasks.Count)
        {
            var task = sortedTasks[index - 1];

            if (task.IsCompleted)
            {
                task.IsCompleted = false;
                Console.WriteLine($"Task marked as incomplete: {task.Description}");
            }
            else
            {
                Console.WriteLine($"Task \"{task.Description}\" is already incomplete.");
            }

        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    /// <summary>
    /// Delete a selected task from the to-do list.
    /// </summary>
    public static void DeleteTask()
    {
        Console.WriteLine(" --- Delete Task  ---");

        if (tasks.Count == 0)
        {
            Console.WriteLine("Your To-Do List is empty");
            return;
        }

        var sortedTasks = ShowTasks();

        Console.WriteLine("\nEnter the number of the task you want to delete: ");
        string input = Console.ReadLine()!;

        if (int.TryParse(input, out int index) && index > 0 && index <= sortedTasks.Count)
        {
            var taskToRemove = sortedTasks[index - 1];
            Console.WriteLine($"Removed: {taskToRemove.Description}");
            tasks.Remove(taskToRemove);
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    /// <summary>
    /// View all tasks in the to-do list sorted by priority then description.
    /// </summary>
    /// <returns></returns>
    public static List<TaskItem> ShowTasks()
    {
        int totalTaskCount = 0;
        var sortedTasks = tasks
            .OrderBy(t => t.Priority)
            .ThenBy(t => t.Description)
            .ToList();

        for (int i = 0; i < sortedTasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {sortedTasks[i]}");
            totalTaskCount += 1;
        }
        Console.WriteLine($"\nTotal Tasks: {totalTaskCount}");
        return sortedTasks;
    }


}

// Priority Enum
public enum Priority
{
    High = 1,
    Medium = 2,
    Low = 3
}


public class TaskItem
{
    public string Description { get; set; }
    public Priority Priority { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(string description, Priority priority)
    {
        Description = description;
        Priority = priority;
        IsCompleted = false;
    }

    public override string ToString()
    {
        string status = IsCompleted ? "[x]" : "[ ]";
        return $"{status} {Description} (Priority: {Priority})";
    }
}