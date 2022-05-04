using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShakirovTranspComp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void CorrectAuthorizationAsync()
        {
            string phone = "+79522233529";
            string pass = "123";

            User auth = DataBase.AuthorizationAsync(phone, pass).Result;
            int actual = auth.id;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async void InCorrectAuthorizationAsync()
        {
            string phone = "+795229";
            string pass = "123";

            User auth = DataBase.AuthorizationAsync(phone, pass).Result;
            int? expected = null;

            Assert.AreEqual(expected, auth.id);
        }

        [TestMethod]
        public async void CorrectReg()
        {
            string fio = "test user";
            string phone = "+79522231222";
            string pass = "322";

            bool act = await DataBase.RegistrationAsync(fio, phone, pass);
            bool expected = true;

            Assert.AreEqual(expected, act);
        }

        [TestMethod]
        public void CargoTypeTEst()
        {
            cargoType cargo = DataBase.GetContext().cargoType.Where(f =>f.name == "Генеральный").FirstOrDefault();
            int actual =  DataBase.CargoTypeToCarType(cargo).id;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async void FindSuitableCarForCargoTest()
        {
            cargoType cargo = DataBase.GetContext().cargoType.Where(f => f.name == "Генеральный").FirstOrDefault();
            int amount = 1500;
            Transport suitable = DataBase.FindSuitCarForCargo(amount, cargo).Result;
            if (suitable != null)
            {
                int suitableAmount = suitable.capacity;

                bool actual = false;
                if (suitableAmount >= amount) actual = true;
                bool expected = true;

                Assert.AreEqual(expected, actual);
            }
        }

    }
}
