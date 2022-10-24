namespace Turing.Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*   data = [
     ['Frank', 33],
     ['Stacy', 15],
     ['Juan', 24],
     ['Dom', 32],
     ['Steve', 24],
     ['Jill', 24]
   ] */

            var data = new Person[]
            {
                new Person("Frank", 33),
                new Person("Stacy", 15),
                new Person("Juan", 24),
                new Person("Dom", 32),
                new Person("Steve", 24),
                new Person("Jill", 24)
            };

            //Output names in ascending order
            Console.WriteLine("Names in Ascending Order");
            var orderNames = data.OrderBy(x => x.Name).ToList();
            orderNames.ForEach(x => { Console.WriteLine(x.Name); });

            Console.WriteLine();
            //Output names in ascending order in the format Name (Age)
            Console.WriteLine("Display Names in the format Name (Age) ");
            orderNames.ForEach(x => { Console.WriteLine($"{x.Name} ({x.Age})"); });

            Console.WriteLine();
            //Build hash with the age as key. Then names of all persons with the same age as value in an array.
            var dictionary = new Dictionary<int, List<string>>();
            Console.WriteLine("Build hash with the age as key. Then names of all persons with the same age as value in an array.");
            orderNames = data.OrderBy(x => x.Age).ToList();
            orderNames.ForEach(x =>
            {
                if (dictionary.ContainsKey(x.Age))
                {
                    dictionary[x.Age].Add(x.Name);                    
                }
                else
                {
                    dictionary.Add(x.Age, new List<string>() { x.Name });
                }
            });

            dictionary.Keys.ToList().ForEach(k =>
            {
                List<string> names = dictionary[k] ?? new List<string>();
                var joinedNames = names.Aggregate(string.Empty, (x, s) => !string.IsNullOrWhiteSpace(x) ? $" {x}, '{s}'" : $"'{s}'") ; // string.Join(",", names.ToArray());
                Console.WriteLine($"{{{k} => {joinedNames}}}");
            });


        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; } = string.Empty;  
        public int Age { get; set; }

    }

}