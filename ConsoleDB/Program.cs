using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LibDB;


namespace ConsoleDB
{
  
    internal class Program
    {
        static Manager manager = new Manager();
        public enum Commands
        {
            stop,
            add,
            delete,
            update,
            show
        }
        static void Main(string[] args)
        {
            

            manager.Connect();

            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(Commands.stop + ": прекращение работы");
            Console.WriteLine(Commands.add + ": добавление данных");
            Console.WriteLine(Commands.delete + ": удаление данных");
            Console.WriteLine(Commands.update + ": обновление данных");
            Console.WriteLine(Commands.show + ": просмотр данных");
            string command;
            do
            {
                Console.WriteLine("Введите команду:");
                command = Console.ReadLine();
                Console.WriteLine();
                switch (command)
                {
                    case
                    nameof(Commands.add):
                        {
                            Add();
                            break;
                        }

                    case
                    nameof(Commands.delete):
                        {
                            Delete();
                            break;
                        }
                    case
                    nameof(Commands.update):
                        {
                            Update();
                            break;
                        }
                    case
                    nameof(Commands.show):
                        {
                            manager.ShowData();
                            break;
                        }

                }
            }
            while (command != nameof(Commands.stop));

            /*  manager.ShowData();

              Console.WriteLine("Введите логин для удаления:");

              var count = manager.DeleteUserByLogin(Console.ReadLine());

              Console.WriteLine("Количество удаленных строк " + count);

              manager.ShowData();


              Console.WriteLine("Введите логин для добавления:");

              var login = Console.ReadLine();

              Console.WriteLine("Введите имя для добавления:");
              var name = Console.ReadLine();
              manager.AddUser(login, name);

              */
            manager.Disconnect();


            Console.ReadKey();

            /* var connector = new MainConnector();

            var result = connector.ConnectAsync();

            var data = new DataTable();

            if (result.Result)
            {
                Console.WriteLine("Подключено успешно!");

                var db = new DbExecutor(connector);

                var tablename = "NetworkUser";

                Console.WriteLine("Получаем данные таблицы " + tablename);

                data = db.SelectAll(tablename);

                Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);
              
                foreach (DataRow row in data.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (var cell in cells)
                    {
                        Console.Write($"{cell}\t");
                    }
                    Console.WriteLine();
                }

                //


                //

                Console.WriteLine("Отключаем БД!");
                connector.DisconnectAsync();

                result = connector.ConnectAsync();

                if (result.Result)
                {
                    Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);

                    var reader = db.SelectAllCommandReader(tablename);
                    var columnList = new List<string>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var name = reader.GetName(i);
                        columnList.Add(name);
                    }

                    for (int i = 0; i < columnList.Count; i++)
                    {
                        Console.Write($"{columnList[i]}\t");
                    }
                    Console.WriteLine();

                    while (reader.Read())
                    {
                        for (int i = 0; i < columnList.Count; i++)
                        {
                            var value = reader[columnList[i]];
                            Console.Write($"{value}\t");
                        }

                        Console.WriteLine();
                    }
                }

            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }

            Console.ReadKey();
           bilo*/

        }
        static void Update()
        {
            Console.WriteLine("Введите логин для обновления:");

            var login = Console.ReadLine();

            Console.WriteLine("Введите имя для обновления:");
            var name = Console.ReadLine();

            var count = manager.UpdateUserByLogin(login, name);

            Console.WriteLine("Строк обновлено" + count);

            manager.ShowData();
        }

        static void Add()
        {
            Console.WriteLine("Введите логин для добавления:");

            var login = Console.ReadLine();

            Console.WriteLine("Введите имя для добавления:");
            var name = Console.ReadLine();

            manager.AddUser(name, login);

            manager.ShowData();
        }

        static void Delete()
        {
            Console.WriteLine("Введите логин для удаления:");

            var count = manager.DeleteUserByLogin(Console.ReadLine());

            Console.WriteLine("Количество удаленных строк " + count);

            manager.ShowData();
        }
    }
}
