using System;
using System.Collections.Generic;

class Expense
{
    public string Category { get; set; }
    public double Amount { get; set; }

    public Expense(string category, double amount)
    {
        Category = category;
        Amount = amount;
    }

    public void Display()
    {
        Console.WriteLine($"Category: {Category}, Amount: ₹{Amount}");
    }
}

class ExpenseTracker
{
    static List<Expense> expenses = new List<Expense>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n===== Expense Tracking System =====");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. Calculate Total Expense");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddExpense();
                        break;

                    case 2:
                        ViewExpenses();
                        break;
                    case 3:
                        CalculateTotal();
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please select 1-4.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
        }
    }

    static void AddExpense()
    {
        try
        {
            Console.Write("Enter Expense Category: ");
            string category = Console.ReadLine();

            Console.Write("Enter Expense Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            if (amount < 0)
                throw new ArgumentException("Expense amount cannot be negative.");

            expenses.Add(new Expense(category, amount));
            Console.WriteLine("Expense added successfully.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Amount must be a numeric value.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ViewExpenses()
    {
        if (expenses.Count == 0)
        {
            Console.WriteLine("No expenses found.");
            return;
        }

        Console.WriteLine("\n----- Expense List -----");
        foreach (Expense expense in expenses)
        {
            expense.Display();
        }
    }

    static void CalculateTotal()
    {
        double total = 0;

        foreach (Expense expense in expenses)
        {
            total += expense.Amount;
        }

        Console.WriteLine($"Total Expense: ₹{total}");
    }
}
