using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task02
{
    class Warehouse
    {
        private readonly List<WarehouseItem> _items = new List<WarehouseItem>();

        public void Delive(Item item, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            int _itemIndex = _items.FindIndex(i => i.Item == item);
            if (_itemIndex == -1)
                _items.Add(new WarehouseItem(item, count));
            else _items[_itemIndex].Merge(item, count);
        }

        public IReadOnlyList<IReadOnlyWarehouseItem> Items => _items;

        public void Ship(Item item, int count)
        {
            int _itemIndex = _items.FindIndex(i => i.Item == item);
            if (_itemIndex == -1)
                throw new InvalidOperationException();
            else _items[_itemIndex].Remove(item, count);
        }

        public void Show()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                Console.WriteLine($"{_items[i].Item.Name} количество - {_items[i].Count}" );
            }
        }
    }
}
