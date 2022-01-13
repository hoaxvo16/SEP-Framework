using IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = MyContainer.GetInstance();

            container.RegisterSingleton<IRegisterableObject, Student>();

            var result = container.GetResult(typeof(IRegisterableObject));

            var result2 = container.GetResult(typeof(IRegisterableObject));

            Console.WriteLine(result == result2);


            Console.WriteLine(result.GetType());
        }

        public interface IRegisterableObject
        {
        }

        public interface IRegisterableObject2
        {

        }

        public class Student : IRegisterableObject
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Student(Address address)
            {
                Name = address.Content;
            }
        }

        public class Address
        {
            public string Content { get; set; } = "Shit";
        }

        public interface ICar
        {
            int Run();
        }

        public class BMW : ICar
        {
            private int _miles = 0;

            public int Run()
            {
                return ++_miles;
            }
        }

        public class Ford : ICar
        {
            private int _miles = 0;

            public int Run()
            {
                return ++_miles;
            }
        }

        public class Audi : ICar
        {
            private int _miles = 0;

            public int Run()
            {
                return ++_miles;
            }

        }
        public class Driver
        {
            private ICar _car = null;

            public Driver(ICar car)
            {
                _car = car;
            }

            public void RunCar()
            {
                Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
            }
        }
    }
}
