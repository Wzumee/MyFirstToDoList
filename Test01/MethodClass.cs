using MainProgram;
using Newtonsoft.Json;

namespace SubProgram
{
    class MethodClass
    {
        public static List<string> todoList = new List<string>();
        public static void LoadTodos()
        {
            if (File.Exists("todos.json"))
            {
                string readToDo = File.ReadAllText("todos.json"); 
                todoList = JsonConvert.DeserializeObject<List<string>>(readToDo); 
            }
        }
        public static void SaveTodos()
        {
            string json = JsonConvert.SerializeObject(todoList, Formatting.Indented); 
            File.WriteAllText("todos.json", json);
        }
        public static void Wait2sec()
        {
            Thread.Sleep(2000);
        }
        public static void ClearLastLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
        public static void SeeAllTodo()
        {
            if (StartScreen.SeeToDo)
            {
                Console.WriteLine("-----Here are your current TODOs-----");
                Console.WriteLine(todoList.Count == 0
                    ? "\nNo TODOs to display."
                    : string.Join("\n", todoList.Select((todo, i) => $"\n{i + 1}. {todo}")));
                Console.WriteLine(" ");
            }
        }
        public static void AddTodo()
        {
            Console.Clear();
            Console.WriteLine("-----Here are your current TODOs-----");
            for (int i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine($"\n{i + 1}. {todoList[i]}");
            }
            Console.Write("\nReference: .............. xx/xx/xxxx xx:xx" +
                "\n" +
                "\nEnter a new TODO:");
            string newTodo = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newTodo) || todoList.Contains(newTodo))
            {
                MethodClass.ClearLastLine();
                Console.Write(string.IsNullOrWhiteSpace(newTodo) ? "ToDo Can't be NullorWhiteSpace: " : "ToDo Already Exist: ");
                newTodo = Console.ReadLine();
            }
            todoList.Add(newTodo);
            Console.WriteLine("TODO added successfully.");
            Console.WriteLine("\nPress any key to return to the main menu...");
            
            Console.ReadKey();
        }
        public static void RemoveToDo()
        {
            Console.Clear();
            if (todoList.Count == 0)
            {
                Console.WriteLine("No TODOs to remove.");
            }
            else
            {
                Console.WriteLine("-----Here are your current TODOs-----");
                for (int i = 0; i < todoList.Count; i++)
                {
                    Console.WriteLine($"\n{i + 1}. {todoList[i]}");
                }
                Console.Write("\nEnter a Number/All To Remove: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "all")
                {
                    todoList.Clear();
                    Console.WriteLine("All ToDo it Removed...");
                    Wait2sec();
                    return;
                }
                while (!int.TryParse(input, out int number) || number < 1 || number > todoList.Count)
                {
                    ClearLastLine();
                    Console.Write("Invalid input Please try again: ");
                    Wait2sec();
                    input = Console.ReadLine();
                    if (input.ToLower() == "all")
                    {
                        todoList.Clear();
                        Console.WriteLine("All ToDo is removed...");
                        Wait2sec();
                        return;
                    }
                }
                int todoNumber = int.Parse(input);
                string removeTodo = todoList[todoNumber - 1];
                todoList.RemoveAt(todoNumber - 1);
                Console.WriteLine($"\nRemove ToDo: {todoNumber}  \"{removeTodo}\"");
            };
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
