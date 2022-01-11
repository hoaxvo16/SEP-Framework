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
            var container = new IoCContainer();
            //container.RegisterType<ICar, BMW>();
            //container.RegisterType<ICar, Audi>();

            //var driver = container.Resolve<Driver>();
            //driver.RunCar();
            //driver.RunCar();

            ICar audi = new Audi();
            container.RegisterInstance<ICar>(audi);

            Driver driver1 = container.Resolve<Driver>();
            driver1.RunCar();
            driver1.RunCar();

            Driver driver2 = container.Resolve<Driver>();
            driver2.RunCar();
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
