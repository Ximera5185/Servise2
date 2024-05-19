using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servise2
{
    internal class CarService
    {
        private CreatorCar _creatorCar = new CreatorCar();

        private Queue<Car> _cars = new Queue<Car>();

        private Warehouse _warehouse = new Warehouse();

        private int _cashier;

        public CarService()
        {
            _cashier = 0;

            AddCars();

            RunSelectMenu();
        }


        private void RunSelectMenu()
        {
            const string ServCarMenu = "1";
            const string ExitProgrammMenu = "2";

            bool isProgrammWork = true;

            string inputUser;

            while (isProgrammWork)
            {
                Console.Clear();
                Console.WriteLine($"Баланс автосервиса {_cashier}");
                Console.WriteLine($"Автомобилей для обслуживания {_cars.Count} штук");
                Console.WriteLine($"Для ремонта автомобилей введите {ServCarMenu}");
                Console.WriteLine($"Для выхода из программы введите {ExitProgrammMenu}");

                inputUser = Console.ReadLine();

                switch (inputUser)
                {
                    case ServCarMenu:
                        Work();
                        break;
                    case ExitProgrammMenu:
                        isProgrammWork = false;
                        break;
                }
            }
        }

        private void AddCars()
        {
            int maxValueCars = 4;

            for (int i = 0; i < maxValueCars; i++)
            {
                _cars.Enqueue(_creatorCar.Create());
            }
        }

        private void Work()
        {
            int monetaryReward = 100;
            int fine = 100;

            while (_cars.Count > 0)
            {
                Car car = _cars.Dequeue();

                ServCar(fine, monetaryReward, car);
            }
        }

        private void ServCar(int fine, int monetaryReward, Car car)
        {
            SparePart partCar;
            SparePart partWarehouse;

            int inputUserPartCar;
            int inputUserPartWarehouse;
            int pricePart;

            while (car.Count > 0)
            {
                Console.Clear();
                Console.WriteLine($"Баланс автосервиса {_cashier}");

                car.ShowBrokenParts();

                Console.WriteLine();

<<<<<<< HEAD
                int inputUser = GetUserNumber("Введите порядковый номер детали для ремонта") - 1;

                if (_warehouse.GetParts(car.GetNamePart(inputUser)))
                {
                    car.RemovePart(inputUser);

=======
                 inputUserPartCar = GetUserNumber("Введите порядковый номер детали для ремонта") - 1;

                partCar = car.GetPart(inputUserPartCar);
>>>>>>> 1
                    _warehouse.Show();

                    inputUserPartWarehouse = GetUserNumber("Введите порядковый номер детали со склада") - 1;


                    if (_warehouse.TryGetParts(inputUserPartWarehouse, out partWarehouse))
                    {

                        if (partCar == partWarehouse)
                        {
                            car.RemovePart(inputUserPartCar);
                            Database.RemovePart(inputUserPartWarehouse);

                            Console.WriteLine("Заменили деталь");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Деталь не совподает, заменили сломанную");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        _cashier -= fine;

                        Console.WriteLine("Подходящей детали на складе нет");
                        Console.ReadKey();
                    }
                }

                Console.WriteLine("Обслуживание машины завершено");
                Console.ReadKey();
            }

            private int GetUserNumber(string message)
            {
                int number = 0;

                string input = "";

                while (int.TryParse(input, out number) == false)
                {
                    Console.WriteLine(message);

                    input = Console.ReadLine();

                    Console.WriteLine("Вы ввели не целое число.");
                }

                return number;
            }
        }
    }
}