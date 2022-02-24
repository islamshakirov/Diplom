using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShakirovTranspComp.OrderClasses
{
    class ArendRequest : IRequest
    {
        readonly int id;
        readonly DateTime start;
        readonly DateTime end;

        public ArendRequest(int i, DateTime s, DateTime e)
        {
            id = i;
            start = s;
            end = e;
        }

        public void Request()
        {
            DataBase.GetContext().Arend.Add
            (
                new Arend
                {
                    id = this.id,
                    start = this.start,
                    end = this.end
                }
            );
            DataBase.SaveChanges();
        }
    }
}
