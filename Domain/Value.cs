using System;

namespace Domain
{
    public class Value
    {
        // int automatically configure database like a number
        // automatically is gonna be use as the primary key
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
