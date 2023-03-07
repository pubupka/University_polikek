using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    public class Human
    {
        public string surname;
        public string birthday;

        public class Teacher : Human
        {
            public string[] subject;
            public string[] jobs;
            public string working;
            public string worked;
            //конструктор, который создаёт обьект этого класса и добавляет его в список, такой есть в каждом классе.
            static public List<Teacher> Constract(List<Teacher> teacher, string surname, string birthday, string[] jobs, string[] subject, string worked, string working)
            {
                Teacher person = new Teacher();

                person.surname = surname;
                person.birthday = birthday;
                person.jobs = jobs;
                person.subject = subject;
                person.worked = worked;
                person.working = working;

                teacher.Add(person);
                return teacher;
            }
        }

        public class Tech : Human
        {
            public string[] jobs;
            static public List<Tech> Constract(List<Tech> tech, string surname, string birthday, string[] jobs)
            {
                Tech person = new Tech();

                person.surname = surname;
                person.birthday = birthday;
                person.jobs = jobs;

                tech.Add(person);

                return tech;
            }
        }

        public class Boss : Human
        {
            //словарь. йоу
            public Dictionary<string, List<string>> order;
            static public List<Boss> Constract(List<Boss> boss, string surname, string birthday)
            {
                Boss person = new Boss();

                person.surname = surname;
                person.birthday = birthday;
                person.order = new Dictionary<string, List<string>>();
                boss.Add(person);

                return boss;
            }

            //он нужен для разделения приказов на 4 группы, у каждой свои приказы.

            static public Dictionary<string, List<string>> Decanat(Dictionary<string, List<string>> order)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Для кого назначаются приказы?");
                    string direction = Console.ReadLine();
                    Console.WriteLine("Какие приказы назначаются?");
                    List<string> orders = Console.ReadLine().Split(' ').ToList();
                    order[direction] = orders;

                    Console.WriteLine("Ввести для другого направления?");
                    string answer = Console.ReadLine();

                    if (answer == "Нет" || answer == "нет")
                    {
                        break;
                    }
                }
                return order;
            }
        }

        public class Student : Human
        {
            public Dictionary<string, string[]> letters; //предмет - оценка, препод   //так все ключи будут уникальными
            static public List<Student> Constract(List<Student> student, string surname, string birthday)
            {
                Student person = new Student();

                person.surname = surname;
                person.birthday = birthday;
                person.letters = new Dictionary<string, string[]>();

                student.Add(person);

                return student;
            }

            static public Dictionary<string, string[]> Input(Dictionary<string, string[]> letters)
            {
                Console.WriteLine("Сколько предметов у студента?");
                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите предмет");
                    string subject = Console.ReadLine();
                    Console.WriteLine("Введите оценку и преподавателя через пробел");
                    string inf = Console.ReadLine();
                    string[] information = inf.Split(' ');

                    letters[subject] = information;  //information - оценка, препод
                }

                return letters;
            }
        }
        public static void Main()
        {

        }
    }
}
