using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShakirovTranspComp.OrderClasses
{
    class ArendRequestCreator : RequestCreator
    {
        readonly DateTime start;
        readonly DateTime end;

        public ArendRequestCreator(DateTime s, DateTime e)
        {
            start = s;
            end = e;
        }

        public override int CalculatePrice()
        {
            return new Random().Next(2000, 8000) * (end.Hour-start.Hour);
        }

        public override IRequest FactoryMethod()
        {
            return new ArendRequest(base.idOrder, start, end);
        }
    }
}
