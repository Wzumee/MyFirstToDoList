using SubProgram;

namespace MainProgram
{
    class StartScreen
    {
        public static bool SeeToDo = false;

        static void Main(string[] args)
        {
            MethodClass.LoadTodos();

            bool KeepOpening = true;
            while (KeepOpening == true)
            {
                Console.Clear();
                MethodClass.SeeAllTodo();
                if (SeeToDo == true)
                {
                    Console.WriteLine("----------ToDo list Program----------" +
                    "\n" +
            "\nWhat do you want to do?" +
            "\n" +
            "\n[1]Hide all TODO" +
            "\n[2]Add a TODO" +
            "\n[3]Remove a TODO" +
            "\n[4]Exit");
                }
                else
                {
                    Console.WriteLine("-----Welcome to ToDo list Program-----" +
                        "\n" +
                "\nWhat do you want to do?" +
                "\n" +
                "\n[1]See all TODO" +
                "\n[2]Add a TODO" +
                "\n[3]Remove a TODO" +
                "\n[4]Exit");
                }
                Console.Write("Pick Your Choice: ");
                var choice = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(choice))
                {
                    MethodClass.ClearLastLine();
                    do
                    {
                        Console.Write("Choice Can't Be NullOrWhiteSpace: ");
                        choice = Console.ReadLine();
                        MethodClass.ClearLastLine();
                    }
                    while (string.IsNullOrWhiteSpace(choice));
                }
                MethodClass.ClearLastLine();
                switch (choice)
                {
                    case "1":
                        if (SeeToDo == true)
                        {
                            SeeToDo = false;
                            break;
                        }
                        SeeToDo = true;
                        break;
                    case "2":
                        MethodClass.AddTodo();
                        break;
                    case "3":
                        MethodClass.RemoveToDo();
                        break;
                    case "4":
                        KeepOpening = false;
                        Console.WriteLine("Program is Closing.....");
                        MethodClass.Wait2sec();
                        return;
                    default:
                        Console.WriteLine("Invalid Input....");
                        MethodClass.Wait2sec();
                        break;
                }
                MethodClass.SaveTodos();
            }
        }
    }
}