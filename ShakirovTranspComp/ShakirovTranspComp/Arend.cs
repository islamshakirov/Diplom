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
    
    public partial class Arend
    {
        public int id { get; set; }
        public System.DateTime start { get; set; }
        public System.DateTime end { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
