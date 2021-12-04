using System;
using System.Collections.Generic;

namespace Task02
{
    class Cart : Warehouse
    {
        private Warehouse _warehouse;
        private Dictionary<Item, int> _items = new Dictionary<Item, int>();

        public Cart(Warehouse warehous)
        {
            _warehouse = warehous;
        }

        public void Add(Item item, int count)
        {
            if (item == null)
                throw new InvalidOperationException();

            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (!Items.ContainsKey(item))
                throw new ArgumentOutOfRangeException(nameof(item));
            
            if (Items[item] < count)
                throw new ArgumentOutOfRangeException(nameof(count));
             
            AddItem(_items, item, count);
            _warehouse.Ship(item, count);        
        }


        public void ShowCartItems()
        {
            ShowItems(_items);
        }
        public Order Order()
        {
            return new Order();
        }
    }
}