using System;
using System.Collections.Generic;

namespace Task02
{
    class Warehouse
    {
        private Dictionary<Item, int> _items = new Dictionary<Item, int>();
        protected Dictionary<Item, int> Items => _items;

        public void Delive(Item item, int count)
        {
            if (item == null)
                throw new InvalidOperationException();

            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            AddItem(_items, item, count);
        }

        public void Ship(Item item, int count)
        {
            if (item == null)
                throw new InvalidOperationException();

            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            Remove(item, count);
        }

        protected void AddItem(Dictionary<Item, int> items, Item item, int count)
        {
            if (items.ContainsKey(item))
                items[item] += count;
            else
                items.Add(item, count);
        }

        protected void Remove( Item item, int count)
        {
            if (!_items.ContainsKey(item))
                throw new ArgumentOutOfRangeException(nameof(item));
            
            if (_items[item] < count)
                throw new ArgumentOutOfRangeException(nameof(count));

                _items[item] -= count;
        }

        public void ShowWarehouseItems()
        {
            ShowItems(_items);
        }

        protected void ShowItems(Dictionary<Item, int> items)
        {
            foreach (KeyValuePair<Item, int> keyValue in items)
            {
                Console.WriteLine($"{keyValue.Key.Name} количество - {keyValue.Value}");
            }
        }
    }
}