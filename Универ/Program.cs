using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Human.Human;
using static Menu_and_other_staff.Menu;
using static Menu_and_other_staff.Input;
using static Menu_and_other_staff.Output;

namespace Универ
{
    class Program
    {
        static void Main(string[] args)
        {
            //преподы-фио.предметы.история препода, технички, управляющий персонал-издавать приказы: касаются студ, преподов, техничек, всех, студэнтов - оценки по разным дисц у разных преподов,
            //студенты с долгами(предмет,препод)
            // препод - долги именно у етого препода
            // приказы (написать, кто выдал) для студентов
            // для преподов
            // для вспомог состава
            // общие приказы
            // по преподу выдать список дисциплин которые он ведёт
            // общий стаж работы и стаж работы в поликеке для каждого препода
            // в общий класс засунуть фио и дату рождения. забубенить наследованием

            int i = 0;
            //списки со всем-всем-всем.
            List<Teacher> teacher = new List<Teacher>();
            List<Tech> tech = new List<Tech>();
            List<Boss> boss = new List<Boss>();
            List<Student> student = new List<Student>();

            while (true)
            {
                Menu_Start(i);

                ConsoleKeyInfo key = Console.ReadKey();
                int n = 3;
                if (key.Key == ConsoleKey.Enter && i == 0) // Ввод данных
                {
                    Console.Clear();
                    while (true)
                    {
                        Menu_Input(i);

                        ConsoleKeyInfo new_key = Console.ReadKey();
                        n = 5;

                        if (new_key.Key == ConsoleKey.Enter && i == 0) //Ввод препода
                        {
                            Input_Teacher(teacher);
                        }
                        if (new_key.Key == ConsoleKey.Enter && i == 1) //Ввод технички
                        {
                            Input_Tech(tech);
                        }

                        if (new_key.Key == ConsoleKey.Enter && i == 2) //Ввод управленца
                        {
                            Input_Boss(boss);
                        }

                        if (new_key.Key == ConsoleKey.Enter && i == 3) //Ввод студэнта
                        {
                            Input_Student(student);
                        }

                        if (new_key.Key == ConsoleKey.Enter && i == 4) //Выход
                        {
                            Console.Clear();
                            Console.SetCursorPosition(40, 0);
                            break;
                        }

                        i = Move(new_key, i, n);
                    }
                    i = 0;
                }

                if (key.Key == ConsoleKey.Enter && i == 1) // Выборки
                {
                    Console.Clear();
                    i = 0;
                    while (true)
                    {
                        Menu_Search(i);

                        ConsoleKeyInfo very_new_key = Console.ReadKey();
                        n = 6;

                        if (very_new_key.Key == ConsoleKey.Enter && i == 0) //Студенты с долгами
                        {
                            Search_Bad_Guys(student);
                        }

                        if (very_new_key.Key == ConsoleKey.Enter && i == 1) //Долги у конкретного препода
                        {
                            Search_Debt(student);
                        }

                        if (very_new_key.Key == ConsoleKey.Enter && i == 2) //Список дисциплин, которые ведёт препод
                        {
                            Search_Subject(teacher);
                        }

                        if (very_new_key.Key == ConsoleKey.Enter && i == 3) //Приказы 
                        {
                            Search_Orders(boss);
                        }

                        if (very_new_key.Key == ConsoleKey.Enter && i == 4) //выдать стаж в поликеке и в целом 
                        {
                            Search_Teacher_Experience(teacher);
                        }

                        if (very_new_key.Key == ConsoleKey.Enter && i == 5) //Выход
                        {
                            Console.Clear();
                            break;
                        }

                        i = Move(very_new_key, i, n);
                    }
                    i = 0;
                }

                if (key.Key == ConsoleKey.Enter && i == 2)
                {
                    break;
                }

                i = Move(key, i, n);
            }
        }
    }
}