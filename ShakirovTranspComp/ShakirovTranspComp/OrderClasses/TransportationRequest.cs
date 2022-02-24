using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShakirovTranspComp.OrderClasses
{
    class TransportationRequest : IRequest
    {
        readonly int id;
        readonly string import;
        readonly string export;
        readonly int amount;
        readonly short? loader;
        readonly int? driver;
        readonly cargoType cargoType;

        public TransportationRequest(int id, string i, string e, int a, short? l, int? d, cargoType c)
        {
            this.id = id;
            import = i;
            export = e;
            amount = a;
            loader = l;
            driver = d;
            cargoType = c;
        }

        public void Request()
        {
            DataBase.GetContext().Transportation.Add
                (
                new Transportation
                {
                    id = this.id,
                    import = this.import,
                    export = this.export,
                    amount = this.amount,
                    loader = this.loader,
                    driver = this.driver,
                    cargoType1 = this.cargoType
                }
                );
            DataBase.SaveChanges();
        }

    }
}
