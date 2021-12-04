namespace Task02
{
    class Shop
    {
        public Warehouse _warehouse { get; private set; }

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public Cart Cart()
        {
            return new Cart(_warehouse);
        }
    }
}
