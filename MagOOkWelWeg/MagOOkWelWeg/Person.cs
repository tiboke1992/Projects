//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagOOkWelWeg
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        public Person()
        {
            this.Car = new HashSet<Car>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string PreName { get; set; }
        public short Age { get; set; }
    
        public virtual ICollection<Car> Car { get; set; }
    }
}