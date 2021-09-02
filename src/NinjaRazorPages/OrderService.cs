namespace NinjaRazorPages
{
    class OrderService : IOrderService
    {
        private string _id;
        public OrderService(string id)
        {
            _id = id;
        }
        public void RegisterOrder()
        {
            // todo : register order ....
        }
    }
}