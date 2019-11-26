using System;
using System.Collections.Generic;
using System.Threading;

public class Menu
{
    private int idCounter = 1;  //Counter to generate unique id

    private List<Task> unfinishedList = new List<Task>();   //List for unfinished tasks
    private List<Task> finishedList = new List<Task>();     //List for finished tasks

    //Function to add some examples at the beginning
    public void addExempleTask() {
        unfinishedList.Add(new TaskType1(idCounter++, "Task 1", Status.leftToDo, true));
        unfinishedList.Add(new TaskType1(idCounter++, "Task 2", Status.Done, true));
        unfinishedList.Add(new TaskType1(idCounter++, "Task 3", Status.leftToDo, true));
        unfinishedList.Add(new TaskType1(idCounter++, "Task 4", Status.Done, true));
        unfinishedList.Add(new TaskType2(idCounter++, "Task 5", Status.leftToDo, DateTime.Today));
        unfinishedList.Add(new TaskType2(idCounter++, "Task 6", Status.Done, DateTime.Today));
        unfinishedList.Add(new TaskType2(idCounter++, "Task 7", Status.leftToDo, DateTime.Today));
        unfinishedList.Add(new TaskType2(idCounter++, "Task 8", Status.Done, DateTime.Today));
    }

    //Function to display the main menu
    public void showMenu() {
        System.Console.Clear();
        System.Console.WriteLine(unfinishedList);
        System.Console.WriteLine("Wälkommen till Left To Do!!!");
        System.Console.WriteLine("Välj ett alternativ:");
        System.Console.WriteLine("  [0] Avsluta programmet.");
        System.Console.WriteLine("  [1] Lista alla dagens uppgifter.");
        System.Console.WriteLine("  [2] Lägga till en ny uppgift.");
        System.Console.WriteLine("  [3] Arkiverade alla uppgifter som för närvarande är utförda.");
        System.Console.WriteLine("  [4] Lista alla arkiverande uppgifter.");
        System.Console.Write("  \nDitt val är: ");  
        
        string input = Console.ReadKey().KeyChar.ToString();
        int option = -1;
        while (!int.TryParse(input, out option)) {
            System.Console.Write("  \nFel val, ange ett nytt val: ");                    
            input = Console.ReadKey().KeyChar.ToString();
        }
        option = int.Parse(input); 

        switch (option) {
            case 0:
                System.Console.Write("\nVälkommen tillbaka");
                Animate('!', 100, 10);
                break;
            case 1:
                showSubMenu1();
                break;
            case 2:
                showSubMenu2();
                break;
            case 3:
                ArchiveAllTasks();
                break;
            case 4:
                showArchivedTasks();
                break;
            default:
                throw new ArgumentException ($"\nInvalid {nameof(option)}");
        }
    }

    //Function to display the menu after choosing '1' in the main menu
    private void showSubMenu1 () {
        if (unfinishedList.Count > 0) {
            System.Console.Clear();
            System.Console.WriteLine("Här är listan över alla uppgifter:");

            foreach (Task task in unfinishedList) {
                if (task is TaskType1) {
                    TaskType1 item1 = (TaskType1) task;
                    System.Console.WriteLine($" Id: {item1.getId()}, Namn: {item1.getName()}. Nuvarande status: {item1.getStatus()}, Är kontrollerad: {item1.getIsChecked()}");
                } else {
                    TaskType2 item2 = (TaskType2) task;
                    System.Console.WriteLine($" Id: {item2.getId()}, Namn: {item2.getName()}. Nuvarande status: {item2.getStatus()}, Datum: {item2.getDate().ToString("yyyy/MM/dd")}");
                }
            }

        } else {
            System.Console.Write("\nListan är tom, vänlige lägg till nya uppgifter");
            Animate('.', 100, 10);
            showMenu();
        }
        showSubMenu1_1();
    }

    //Function to display the menu that shows and modifies the status of pending tasks
    private void showSubMenu1_1 () { 
        System.Console.WriteLine("\nVill du ändra statusen till utförda av någon uppgift?");
        System.Console.WriteLine("  [0] Gå tillbaka till huvudmenyn utan att göra några ändringar.");
        System.Console.WriteLine("  [N] Ange ID från en uppgift som inte är utförda och tryck Enter.");
        System.Console.Write("  \nDitt val är: ");

        string input = Console.ReadLine();
        int option_2 = -1;
        while (!int.TryParse(input, out option_2)) {
            System.Console.Write("  Fel val, ange ett nytt val: ");                    
            input = Console.ReadLine();
        }
        option_2 = int.Parse(input); 
        bool found = false;
        if (option_2 != 0) {
            foreach (Task task in unfinishedList) {
                if (task.getId() == option_2) {
                    found = true;
                    if (task.getStatus() == Status.Done) {
                        System.Console.Write("\nOgiltig id, försök igen");
                    } else {
                        task.setStatus(Status.Done);
                        System.Console.Write("\nStatus ändrad. Gå tillbaka till menyn");
                    }
                } 
            }
            if (!found)
                throw new ArgumentException ($"\nInvalid {nameof(option_2)}");

            Animate('.', 100, 10);
            System.Console.Clear();
            showSubMenu1();
        } else
            showMenu();
    }

    //Function to display the menu that allows you to add new tasks
    private void showSubMenu2 () {
        System.Console.WriteLine("\nVilken typ av uppgift du vill lägga till?");
        System.Console.WriteLine("  [1] Typ 1, dvs en uppgift som är kontrollerad.");
        System.Console.WriteLine("  [2] Typ 2, dvs en uppgift som är daterad.");
        System.Console.Write("  \nDitt val är: ");

        string input = Console.ReadKey().KeyChar.ToString();
        int option_3 = -1;
        while (!int.TryParse(input, out option_3)) {
            System.Console.Write("  \nFel val, ange ett nytt val: ");                    
            input = Console.ReadKey().KeyChar.ToString();
        }
        option_3 = int.Parse(input); 
        
        if (option_3 != 1 && option_3 != 2) {
            throw new ArgumentException ($"\nInvalid {nameof(option_3)}");
        } else {
            System.Console.Write("\nAnge namnet på uppgiften: ");
            switch (option_3) {
                case 1:
                    unfinishedList.Add(new TaskType1(idCounter++, Console.ReadLine(), Status.leftToDo, true));
                    break;
                case 2:
                    unfinishedList.Add(new TaskType2(idCounter++, Console.ReadLine(), Status.leftToDo, DateTime.Today));
                    break;
                default:
                    System.Console.Write("\nFel i menyvalet, vänlige försök igen");
                    Animate('.', 100, 5);
                    showSubMenu2 ();
                    break;
            }
            System.Console.Write("\nUppgift tillagd. Gå tillbaka till menyn");
            Animate('.', 100, 10);
            showMenu();
        }
    }

    //Function to display the menu that allows you to archive all completed tasks
    private void ArchiveAllTasks() {
        //First we go through the list to add as completed
        foreach (Task task in unfinishedList) {
            if (task.getStatus() == Status.Done) {
                finishedList.Add(task);
            }
        }
        //Then we go through the list eliminating
        foreach (Task task in finishedList) {
            unfinishedList.Remove(task);
        }
        System.Console.Write("\nArkivera alla uppgifter som för närvarande är utförda. Gå tillbaka till menyn");
        Animate('.', 100, 10);
        showMenu();
    }

    //Function to display archived tasks
    private void showArchivedTasks() {
        if (finishedList.Count > 0) {
            System.Console.Clear();
            System.Console.WriteLine("Här är listan över alla arkiverade uppgifter:");

            foreach (Task task in finishedList) {
                System.Console.WriteLine($" Id: {task.getId()}, Namn: {task.getName()}.");
            }
        } else {
            System.Console.Write("\nListan är tom");
            Animate('.', 100, 10);
            showMenu();
        }
        System.Console.WriteLine("\nVill du gå till huvudmenyn?");
        System.Console.WriteLine("  [J]a, jag vill.");
        System.Console.WriteLine("  [N]ej, jag vill försätta här.");
        System.Console.Write("  \nDitt val är: ");
        ConsoleKeyInfo input = Console.ReadKey(true);

        if (input.Key == ConsoleKey.J)
           showMenu(); 
        else 
            showArchivedTasks();
    }

    //Function to show an animation every x milliseconds
    public void Animate (char c, int milliseconds, int times) {
        for (int i = 0; i < times; i++) {
            System.Console.Write(c);
            Thread.Sleep(milliseconds);
        } 
    }
    
}