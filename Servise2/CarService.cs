using System;
using System.Collections.Generic;

namespace Servise2
{
    internal class CarService
    {
        private CreatorCar _creatorCar = new CreatorCar();

        private Queue<Car> _cars = new Queue<Car>();

        private Warehouse _warehouse = new Warehouse();

        private int _cashier;

        private bool _isRepairs = true;

        private  bool _isProgrammWork = true;
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


            string inputUser;

            while (_isProgrammWork)
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
                        _isProgrammWork = false;
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
            while (_cars.Count > 0 && _isRepairs)
            {
                Car car = _cars.Dequeue();

                ServCar(car);
            }
        }

        private void ServCar(Car car)
        {
            int monetaryReward = 100;
            int fine = 100;
            int sparePartIndex = 0;


            while (car.BrokenPartsCount > 0 && _isRepairs)
            {
                Console.Clear();
                Console.WriteLine($"Баланс автосервиса {_cashier}");

                car.ShowBrokenParts();

                Console.WriteLine();

                _warehouse.Show();

                Console.WriteLine("Для выбора детали введите 1 " +
                "Для выхода из этого меню введите 2");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        sparePartIndex = GetUserNumber("Введите номер детали со склада для замены") -1;
                        break;
                    case "2":
                        _isRepairs = false;
                        break;
                        default :
                        Console.WriteLine("Вы не чего не выбрали, нажмите Enter и попробуйте сново");
                        Console.ReadKey();
                        break;
                        
                }

                if (_isRepairs == false)
                {
                    _isProgrammWork = false;

                    break;
                }

                if (_warehouse.TryGetPart(sparePartIndex, out SparePart newPart) == false)
                {
                    Console.WriteLine("Такой детали нет");

                    continue;
                }

                if (car.HaveBrokenPart(newPart.Name))
                {
                    car.FixPart(newPart);

                    _cashier += monetaryReward;

                    Console.WriteLine("Деталь заменили");
                }
                else
                {
                    car.AddPart(newPart);

                    //_cashier -= fine;

                    Console.WriteLine("Попытка заменить целую деталь");
                    Console.ReadKey();
                    // выплата штрафа
                }
            }

            Console.WriteLine("Обслуживание машины завершено");
            Console.ReadKey();
        }

        private int GetUserNumber(string message)
        {
            int number;

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