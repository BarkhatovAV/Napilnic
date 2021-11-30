using System;
using System.Collections.Generic;
using System.Text;

namespace Task02
{
    class Cart
    {
        private Warehouse _warehouse;
        private List<CartItem> _itemsToBuy = new List<CartItem>();

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void Add(Item item, int count)
        {
            if ((count <= 0)&&(item == null))
                throw new InvalidOperationException();

            foreach (var warehouseItem in _warehouse.Items)
            {
                if(warehouseItem.Item.Name == item.Name)
                {
                    if(warehouseItem.Count >= count)
                    {
                        _itemsToBuy.Add(new CartItem(item, count));
                        _warehouse.Ship(item, count);
                        Console.WriteLine($"В корзину добавлен {item.Name} в количестве {count}");
                    }
                    else
                    {
                        Console.WriteLine("Товара на складе не достаточно");
                    }
                }
            }
        }

        public Order Order()
        {
            return new Order();
        }
    }
}
