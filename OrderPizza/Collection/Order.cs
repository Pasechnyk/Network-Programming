using System;

namespace Collection
{
    [Serializable]
    public class Order
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Pizza { get; set; }
    }
}
