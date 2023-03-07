using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Human.Human;
using static Menu_and_other_staff.Menu;

namespace Menu_and_other_staff
{
    public class Input
    {
        public static void Input_Teacher(List<Teacher> teacher) //Ввод препода
        {
            Console.Clear();
            Console.WriteLine("Введите фамилию преподователя");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите др преподователя");
            string birthday = Console.ReadLine();
            Console.WriteLine("Введите предыдущие должности преподователя");
            string[] jobs = Console.ReadLine().Split(' ');
            Console.WriteLine("Введите предметы, которые ведёт преподователь");
            string[] subjects = Console.ReadLine().Split(' ');
            Console.WriteLine("Введите общий стаж преподователя");
            string worked = Console.ReadLine();
            Console.WriteLine("Введите стаж преподователя в поликеке");
            string working = Console.ReadLine();

            teacher = Teacher.Constract(teacher, surname, birthday, jobs, subjects, worked, working);

            Console.Clear();
        }

        public static void Input_Tech(List<Tech> tech) // Ввод технички
        {
            Console.Clear();
            Console.WriteLine("Введите фамилию технички");
            string name = Console.ReadLine();
            Console.WriteLine("Введите др технички");
            string birthday = Console.ReadLine();
            Console.WriteLine("Введите предыдущие должности технички");
            string[] jobs = Console.ReadLine().Split(' ');

            tech = Tech.Constract(tech, name, birthday, jobs);

            Console.Clear();
        }

        public static void Input_Boss(List<Boss> boss) // Ввод босса
        {
            Console.Clear();
            Console.WriteLine("Введите фамилию босса");
            string name = Console.ReadLine();
            Console.WriteLine("Введите др босса");
            string birthday = Console.ReadLine();

            boss = Boss.Constract(boss, name, birthday);

            boss[boss.Count - 1].order = Boss.Decanat(boss[boss.Count - 1].order);  // Взял словарь только что добавленного босса и пишу туда данные

            Console.Clear();
        }

        public static void Input_Student(List<Student> student) // Ввод студента
        {
            Console.Clear();

            Console.WriteLine("Введите фамилию студента");
            string name = Console.ReadLine();
            Console.WriteLine("Введите др студента");
            string birthday = Console.ReadLine();

            student = Student.Constract(student, name, birthday);

            student[student.Count - 1].letters = Student.Input(student[student.Count - 1].letters);
            Console.Clear();
        }
    }
    public class Output
    {
        public static void Search_Bad_Guys(List<Student> student) //поиск должников
        {

            Console.Clear();
            foreach (Student mihunchik in student)
            {
                foreach (string subject in mihunchik.letters.Keys)
                {
                    if (mihunchik.letters[subject][0] == "неуд")
                    {
                        Console.WriteLine($"{mihunchik.surname}\t имеет долг у {mihunchik.letters[subject][1]}");
                    }
                }
            }

            Going_Back();
        }

        public static void Search_Debt(List<Student> student) //поиск должников у конкретного препода
        {

            Console.Clear();
            Console.WriteLine("Введите фамилию препода");
            string teacher = Console.ReadLine();

            foreach (Student mihunchik in student)
            {
                foreach (string subject in mihunchik.letters.Keys)
                {
                    if (mihunchik.letters[subject][0] == "неуд" && mihunchik.letters[subject][1] == teacher)
                    {
                        Console.WriteLine($"{mihunchik.surname}\t имеет долг по предмету {subject}");
                    }
                }
            }

            Going_Back();
        }
        public static void Search_Subject(List<Teacher> teacher) // поиск предметов, которые ведёт препод
        {
            Console.Clear();
            Console.WriteLine("Введите фамилию препода");
            string someone = Console.ReadLine();
            foreach (Teacher tchr in teacher)
            {
                if (tchr.surname == someone)
                {
                    Console.Write($"{someone} ведёт следующие предметы:");
                    foreach (string subject in tchr.subject)
                        Console.Write($" {subject}");
                }
            }
            Console.WriteLine();
            Going_Back();
        }

        public static void Search_Orders(List<Boss> boss) // поиск по приказам
        {
            Console.Clear();

            Console.WriteLine("Существует 4 направления приказов: для студентов, для преподов, для тех.персонала и общие");
            Console.WriteLine("Введите нужную категорию");
            string direction = Console.ReadLine();

            foreach (Boss gangster in boss)
            {
                Console.Write($"{gangster.surname} издал приказ(ы) для {direction}:");
                if (gangster.order.ContainsKey(direction))
                {
                    foreach (string order in gangster.order[direction])
                    {
                        Console.Write($" {order}");
                    }
                    Console.WriteLine();
                }
            }

            Going_Back();
        }

        public static void Search_Teacher_Experience(List<Teacher> teacher) // поиск различного стажа препода
        {
            Console.Clear();

            Console.WriteLine("Введите фамилию препода");
            string surname = Console.ReadLine();
            foreach (Teacher tchr in teacher)
            {
                if (surname == tchr.surname)
                {
                    Console.WriteLine($"{surname} проработал в поликеке {tchr.working}, общий стаж равен {tchr.worked}");
                }
            }

            Going_Back();
        }
    }

    public class Menu
    {
        public static int Move(ConsoleKeyInfo key, int i, int n)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                i = (n + i - 1) % n;
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                i = (i + 1) % n;
            }
            return i;
        }

        public static void Menu_Start(int i) // стартовая менюшка
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Ввод данных");
            Console.WriteLine("Выборки");
            Console.WriteLine("Выход");
            Console.SetCursorPosition(40, i);
        }

        public static void Menu_Input(int i) // Меню ввода
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Преподы");
            Console.WriteLine("Технички");
            Console.WriteLine("Управляющий персонал");
            Console.WriteLine("Студэнты");
            Console.WriteLine("Завершить заполнение");
            Console.SetCursorPosition(40, i);
        }

        public static void Menu_Search(int i) // Меню выборок
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Выдать студентов с долгами");
            Console.WriteLine("Выдать долги у препода");
            Console.WriteLine("Выдать список дисциплин, которые ведёт препод");
            Console.WriteLine("Выдать приказы");
            Console.WriteLine("Выдать стаж препода");
            Console.WriteLine("Вернуться назад");
            Console.SetCursorPosition(50, i);
        }

        public static void Going_Back()
        {
            Console.WriteLine("Для возврата нажмите ентр");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }
            }
        }

        static void Main(string[] args)
        {

        }
    }
}