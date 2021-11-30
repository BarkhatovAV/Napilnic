using System;

namespace Task02
{
    class AbstractCollectionOfItem : IReadOnlyWarehouseItem
    {
        public Item Item { get; private set; }
        public int Count { get; private set; }

        public AbstractCollectionOfItem(Item item, int count)
        {
            Item = item;
            Count = count;
        }

        public void Merge(Item item, int count)
        {
            if (Item == item)
                Count += count;
            else
                throw new InvalidOperationException();
        }

        public void Remove(Item item, int count)
        {
            if (Item == item)
                Count -= count;
            else
                throw new InvalidOperationException();
        }
    }
}
