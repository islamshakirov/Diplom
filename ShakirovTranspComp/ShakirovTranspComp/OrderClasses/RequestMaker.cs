using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShakirovTranspComp.OrderClasses
{
    public static class RequestMaker
    {
        public static async Task<bool> MakeTransportationRequestAsync(string import, string export, int amount, cargoType cargo, short? loader = null, int? driver = null)
        {
            try
            {
                TransportationRequestCreator tranferCreate = new TransportationRequestCreator(import, export, amount, loader, driver, cargo);
                Transport suitableCar = await DataBase.FindSuitCarForCargo(amount, cargo);
                if (suitableCar != null)
                {
                    if (await tranferCreate.InitializeRequestAsync(DateTime.Now, suitableCar, Manager.currentUser.Client) != null)
                    {
                        tranferCreate.FactoryMethod().Request();
                        //MessageBox.Show("Заказ совершен");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка связывания типа заказа");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("У нас нет подходящих машин");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("UNKONWN ERROR");
                return false;
            }
        }
        

        public static async Task<bool> MakeMovingRequestAsync(string import, string export, short? loader = null, byte? furniture = null, byte? pack = null, int? driver = null)
        {
            try
            {
                MovingRequestCreator movingCreate = new MovingRequestCreator(import, export, loader, furniture, pack, driver);
                cargoType cargo = DataBase.GetContext().cargoType.Where(finding => finding.name == "Генеральный").First();
                Transport suitableCar = await DataBase.FindSuitCarForCargo(3000, cargo);
                if (suitableCar != null)
                {
                    if (await movingCreate.InitializeRequestAsync(DateTime.Now, suitableCar, Manager.currentUser.Client) != null)
                    {
                        movingCreate.FactoryMethod().Request();
                        //MessageBox.Show("Заказ совершен");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка связывания типа заказа");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("У нас нет подходящих машин");
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> MakeArendRequestAsync(int amount, CarType carType, DateTime start, DateTime end)
        {
            try
            {
                ArendRequestCreator arendCreate = new ArendRequestCreator(start, end);
                Transport suitableCar = await DataBase.FindSuitCar(amount, carType);
                if (suitableCar != null)
                {
                    if (await arendCreate.InitializeRequestAsync(DateTime.Now, suitableCar, Manager.currentUser.Client) != null)
                    {
                        arendCreate.FactoryMethod().Request();
                        //MessageBox.Show("Аренда совершена");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка связывания типа заказа");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("У нас нет подходящих машин");
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
