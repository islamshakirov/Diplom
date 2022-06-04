using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShakirovTranspComp
{
    public sealed class DataBase
    {

        private static cargotEntities context;
        private static readonly object alock = new object();
        
        public static cargotEntities GetContext()
        {
            if (context == null)
            {
                lock (alock)
                {
                    if (context == null)
                    {
                        context = new cargotEntities();
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
            return await Task.Run(
                () => GetContext().Transport.
                Where(finding => finding.capacity >= minAmount && finding.busy == 0 && finding.CarType.id == suitType.id).
                OrderBy(ord => ord.capacity).
                FirstOrDefault()
             );
        }
        
        public static async Task<Transport> FindSuitCar(int minAmount, CarType type)
        {
            return await Task.Run(
                () => GetContext().Transport.
             Where(finding => finding.capacity >= minAmount && finding.busy == 0 && finding.CarType.id == type.id).
             OrderBy(ord => ord.capacity).
             FirstOrDefault()
             );
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
            if (phone.Length < 12 || phone.Length > 18) return null;
            else
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

        public static async Task<List<Transport>> GetAutoList()
        {
            Task<List<Transport>> t1 = new Task<List<Transport>>(() => GetContext().Transport.ToList());
            
            List<Transport> collection = new List<Transport>();
            try
            {
                t1.Start();
                collection = await t1;
            }
            finally
            {
                t1.Dispose();
            }

            return collection;
        }

        public static async void DeleteAuto(Transport onDelete)
        {
            Task t1 = new Task(() => GetContext().Transport.Remove(onDelete));

            try
            {
                t1.Start();
                await t1;
                SaveChanges();
            }
            finally
            {
                t1.Dispose();
            }
           
        }

        private static async Task<bool> IsStateNumfree(string newNum)
        {
            try
            {
                Task<Transport> t1 = new Task<Transport>(() => GetContext().Transport.Where(f => f.StateNum == newNum).FirstOrDefault());
                Transport finded;

                try
                {

                    t1.Start();
                    finded = await t1;
                    SaveChanges();
                }
                finally
                {
                    t1.Dispose();
                }

                if (finded == null) return true;
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return false;
        }

        public static async void UpdateAuto(Transport updating, Transport updated)
        {
           
           Task t1 = new Task ( () => GetContext().Transport.Attach(updating));

            t1.Start();
            await t1;

            if (updated.fuel > 0 && updated.capacity > 0 && updated.length > 0)
            {
                try
                {
                    updating.automodel = updated.automodel;
                    updating.fuel = updated.fuel;
                    updating.capacity = updated.capacity;
                    updating.length = updated.length;
                    updating.kind = updated.kind;
                    updating.busy = updated.busy;
                    updating.CarType = updated.CarType;

                    if (updating.StateNum != updated.StateNum)
                    {
                        if (await IsStateNumfree(updated.StateNum))
                        {
                            updating.StateNum = updated.StateNum;
                        }
                        else MessageBox.Show("Машина с таким государственным номером уже зарегистрирована в автопарке");
                    }

                    SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка обработки запроса");
                }
            }
            else MessageBox.Show("Все численные значения должны быть положительны");

            t1.Dispose();
        }

        public static async void AddAuto(Transport onAdd)
        {
            if (await IsStateNumfree(onAdd.StateNum))
            {
                if (onAdd.fuel > 0 && onAdd.capacity > 0 && onAdd.length > 0)
                {
                    Task t1 = new Task(() => GetContext().Transport.Add(onAdd));
                    try
                    {
                        t1.Start();
                        await t1;
                        SaveChanges();
                    }
                    finally
                    {
                        t1.Dispose();
                    }
                   
                }
                else MessageBox.Show("Все численные значения должны быть положительны");
            }
            else MessageBox.Show("Машина с таким государственным номером уже зарегистрирована в автопарке");
        }

        public static async Task<List<Drivers>> GetDriverList()
        {
            Task<List<Drivers>> t1 = new Task<List<Drivers>>(() => GetContext().Drivers.ToList());
            List<Drivers> collection = new List<Drivers>();
            try
            {
                t1.Start();
                collection = await t1;
            }
            finally
            {
                t1.Dispose();
            }

            return collection;
        }

        public static async void DeleteDriver(Drivers onDelete)
        {
            Task t1 = new Task(() => GetContext().User.Remove(onDelete.User));
            Task t2 = new Task(() => GetContext().Drivers.Remove(onDelete));

            try
            {
                t1.Start();
                t2.Start();
                await t1;
                await t2;
                SaveChanges();
            }
            finally
            {
                t1.Dispose();
                t2.Dispose();
            }

        }

        private static async Task<bool> IsPhoneFree(string newNum)
        {
            try
            {
                Task<User> t1 = new Task<User>(() => GetContext().User.Where(f => f.phone == newNum).FirstOrDefault());
                User finded;

                try
                {
                    t1.Start();
                    finded = await t1;
                    SaveChanges();
                }
                finally
                {
                    t1.Dispose();
                }

                if (finded == null) return true;
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return false;
        }

        public static async void UpdateDriver(Drivers updating, Drivers updated)
        {

            Task t1 = new Task(() => GetContext().Drivers.Attach(updating));

            t1.Start();
            await t1;

           
                try
                {
                    updating.User.fio = updated.User.fio;
                    updating.User.password = updated.User.password;

                if (updating.User.phone != updated.User.phone)
                {
                    if (await IsPhoneFree(updated.User.phone))
                    {
                        updating.User.phone = updated.User.phone;
                    }
                    else MessageBox.Show("Номер телефона уже зарегистрирован");
                }

                SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка обработки запроса");
                }

            t1.Dispose();
        }

        public static async void AddDriver(Drivers onAdd)
        {

            if (await IsPhoneFree(onAdd.User.phone))
            {
                Task<User> t1 = new Task<User>(() => GetContext().User.Add(onAdd.User));
                User newU;
                try
                {
                    t1.Start();
                    newU = await t1;
                    onAdd.id = newU.id;
                    SaveChanges();
                }
                finally
                {
                    t1.Dispose();
                }

                Task t2 = new Task(() => GetContext().Drivers.Add(onAdd));
                try
                {
                    t2.Start();
                    await t2;
                    SaveChanges();
                }
                finally
                {
                    t2.Dispose();
                }
                   

            }
            else MessageBox.Show("Номер телефона уже зарегистрирован");

        }

        private static Moving FindCurrentDriversMoving()
        {
            return GetContext().Moving.Where(mo => mo.driver == Manager.currentUser.Drivers.id && mo.isReady == 0).FirstOrDefault();
        }

        private static Transportation FindCurrentDriversTransportation()
        {
            return GetContext().Transportation.Where(to => to.driver == Manager.currentUser.Drivers.id && to.isReady == 0).FirstOrDefault();
        }
        public static Order FindCurrentDriversOrder()
        {
            Order currentOrder = new Order();

            currentOrder.Transportation = FindCurrentDriversTransportation();
            currentOrder.Moving = FindCurrentDriversMoving();

            return currentOrder;
        }
        public static List<Transportation> FreeTranportation()
        {
            return GetContext().Transportation.Where(f => f.driver == null).ToList();
        }

        public static List<Moving> FreeMoving()
        {
            return GetContext().Moving.Where(f => f.driver == null).ToList();
        }
        public static List<Order> GetFreeOrders()
        {
            List<Order> freeOrders = new List<Order>();

            foreach (Transportation tr in FreeTranportation())
            {
                freeOrders.Add(tr.Order);
            }
            foreach (Moving m in FreeMoving())
            {
                freeOrders.Add(m.Order);
            }

            return freeOrders;
        }

        public static bool FinishOrder(Order onFinish)
        {
            if (onFinish.Transportation != null)
            {
                try
                {
                    GetContext().Transportation.Attach(onFinish.Transportation);
                    onFinish.Transportation.isReady = 1;
                    SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else if (onFinish.Moving != null)
            {
                try
                {
                    GetContext().Moving.Attach(onFinish.Moving);
                    onFinish.Moving.isReady = 1;
                    SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }

        public static bool AcceptOrder(Order onAccept)
        {
            if (onAccept.Transportation != null)
            {
                try
                {
                    GetContext().Transportation.Attach(onAccept.Transportation);
                    onAccept.Transportation.driver = Manager.currentUser.Drivers.id;
                    SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else if (onAccept.Moving != null)
            {
                try
                {
                    GetContext().Moving.Attach(onAccept.Moving);
                    onAccept.Moving.driver = Manager.currentUser.Drivers.id;
                    SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }
    }
}
