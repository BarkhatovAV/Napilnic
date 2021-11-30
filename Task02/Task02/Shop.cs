using System;
using System.Collections.Generic;
using System.Text;

namespace Task02
{
    class Shop
    {
        public Warehouse _warehous { get; private set; }

        public Shop(Warehouse warehouse)
        {
            _warehous = warehouse;
        }

        public Cart Cart()
        {
            return new Cart(_warehous);
        }
    }
}
