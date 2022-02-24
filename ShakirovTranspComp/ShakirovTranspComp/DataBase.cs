using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShakirovTranspComp
{
    public sealed class DataBase
    {

        private static cargo_trEntities context;
        private static readonly object alock = new object();
        
        public static cargo_trEntities GetContext()
        {
            if (context == null)
            {
                lock (alock)
                {
                    if (context == null)
                    {
                        context = new cargo_trEntities();
                    }
                }
            }
            return context;
        }
       
        public static void SaveChanges()
        {
            GetContext().SaveChanges();
        }

        public static async Task<Transport> FindSuitCarForCargo(int minAmount, cargoType type)
        {
            CarType suitType = CargoTypeToCarType(type);
            return await Task.Run(() => GetContext().Transport.Where(finding => finding.capacity >= minAmount && finding.busy == 0
             && finding.CarType.id == suitType.id).OrderByDescending(ord => ord.capacity).FirstOrDefault());
        }

        public static async Task<Transport> FindSuitCar(int minAmount, CarType type)
        {
            return await Task.Run(() => GetContext().Transport.Where(finding => finding.capacity >= minAmount && finding.busy == 0
             && finding.CarType.id == type.id).OrderByDescending(ord => ord.capacity).FirstOrDefault());
        }

        public static CarType CargoTypeToCarType(cargoType type)
        {
            CarType suitableType = new CarType();
            cargoType[] cargoTypes = GetContext().cargoType.ToArray();
            CarType[] carTypes = GetContext().CarType.ToArray();

            if (type == cargoTypes.Where(suit => suit.name == "Скоропортящийся").First())
                suitableType = carTypes.Where(suit => suit.name == "Рефрижератор").First();
            else if (type == cargoTypes.Where(suit => suit.name == "Длинномерный").First())
                suitableType = carTypes.Where(suit => suit.name == "Крупногабаритный").First();
            else if (type == cargoTypes.Where(suit => suit.name == "Генеральный").First())
                suitableType = carTypes.Where(suit => suit.name == "Тентованный").First();
            else if (type == cargoTypes.Where(suit => suit.name == "Большая масса").First())
                suitableType = carTypes.Where(suit => suit.name == "Крупногабаритный").First();
            else if (type == cargoTypes.Where(suit => suit.name == "Негабаритный").First())
                suitableType = carTypes.Where(suit => suit.name == "Открытый").First();

            return suitableType;
        }

        public static async Task<User> AuthorizationAsync(string phone, string password)
        {
            return await Task.Run(() => GetContext().User.Where(finding => finding.phone == phone && finding.password == password).FirstOrDefault());
        }
        public static async Task<bool> RegistrationAsync(string regFio, string regPhone, string regPassword)
        {
            int? newClient;
            if ((newClient = await Task.Run(() => GetContext().User.Add(new User { fio = regFio, phone = regPhone, password = regPassword }).id)) != null)
            {
                GetContext().Client.Add(new Client { id = newClient.Value});
                SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
