using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShakirovTranspComp.OrderClasses
{
    class TransportationRequestCreator : RequestCreator
    {
        readonly string import;
        readonly string export;
        readonly int amount;
        readonly short? loader;
        readonly int? driver;
        readonly cargoType cargoType;

        public TransportationRequestCreator(string i, string e, int a, short? l, int? d, cargoType c)
        {
            import = i;
            export = e;
            amount = a;
            loader = l;
            driver = d;
            cargoType = c;
        }

        public override int CalculatePrice()
        {
            return new Random().Next(5000, 50000);
        }

        public override IRequest FactoryMethod()
        {
            return new TransportationRequest(base.idOrder, import, export, amount, loader, driver, cargoType);
        }
    }
}
