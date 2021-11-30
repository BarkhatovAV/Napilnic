namespace Task02
{
    interface IReadOnlyWarehouseItem
    {
        public Item Item { get; }
        public int Count { get; }
    }
}
