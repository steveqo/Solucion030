//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _04Data.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Detalle_Pedido
    {
        public int id { get; set; }
        public int id_Proyecto { get; set; }
        public int id_Pedido { get; set; }
        public int Cantidad { get; set; }
    
        public virtual Pedido Pedido { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}