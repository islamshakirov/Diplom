using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShakirovTranspComp.OrderClasses
{
    class MovingRequestCreator : RequestCreator
    {
        readonly string import;
        readonly string export;
        readonly short? loader;
        readonly byte? furniture;
        readonly byte? pack;
        readonly int? driver;

        public MovingRequestCreator(string i, string e, short? l, byte? f, byte? p, int? d)
        {
            import = i;
            export = e;
            loader = l;
            furniture = f;
            pack = p;
            driver = d;
        }

        public override int CalculatePrice()
        {
            return new Random().Next(2000, 15000);
        }

        public override IRequest FactoryMethod()
        {
            return new MovingRequest(base.idOrder, import, export, loader, furniture, pack, driver);
        }
    }
}
