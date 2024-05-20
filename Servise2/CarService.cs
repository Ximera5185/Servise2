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

            while (_cars.Count > 0)
            {
                Car car = _cars.Dequeue();

                ServCar(car);
            }
        }

        private void ServCar( Car car)
        {
            int monetaryReward = 100;
            int fine = 100;
            int sparePartIndex;

            while (car.BrokenPartsCount > 0 && true)
            {
                Console.Clear();
                Console.WriteLine($"Баланс автосервиса {_cashier}");

                car.ShowBrokenParts();

                Console.WriteLine();

                _warehouse.Show();

                sparePartIndex = GetUserNumber("Введите номер детали со склада для замены") - 1;
                // сделать доп проверку для отказа от ремонта
                //реализовать второе доп меню
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

                    _cashier -= fine;

                    Console.WriteLine("Попытка заменить целую деталь, автосервис выплатил штрав");
                    // выплата штрафа
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