//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShakirovTranspComp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Moving
    {
        public int id { get; set; }
        public string import { get; set; }
        public string export { get; set; }
        public Nullable<short> loader { get; set; }
        public Nullable<byte> furniture { get; set; }
        public Nullable<byte> pack { get; set; }
        public Nullable<int> driver { get; set; }
    
        public virtual Drivers Drivers { get; set; }
        public virtual Order Order { get; set; }
    }
}
