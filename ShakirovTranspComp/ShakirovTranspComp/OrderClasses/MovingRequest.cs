using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShakirovTranspComp.OrderClasses
{
    class MovingRequest : IRequest
    {
        readonly int id;
        readonly string import;
        readonly string export;
        readonly short? loader;
        readonly byte? furniture;
        readonly byte? pack;
        readonly int? driver;

        public MovingRequest(int id, string i, string e, short? l, byte? f, byte? p, int? d)
        {
            this.id = id;
            import = i;
            export = e;
            loader = l;
            furniture = f;
            pack = p;
            driver = d;
        }

        public void Request()
        {
            DataBase.GetContext().Moving.Add
            (
                new Moving
                {
                    id = this.id,
                    import = this.import,
                    export = this.export,
                    loader = this.loader,
                    furniture = this.furniture,
                    pack = this.pack,
                    driver = this.driver
                }
            );
            DataBase.SaveChanges();
        }

    }
}
