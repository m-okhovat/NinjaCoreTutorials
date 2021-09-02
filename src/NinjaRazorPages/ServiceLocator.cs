using System;
using System.Collections.Generic;

namespace NinjaRazorPages
{
    public static class ServiceLocator // => ServiceProvider
    {
        private static readonly Dictionary<Type, object> _serviceCollection
            = new Dictionary<Type, object>();



        public static void AddService(Type key, object value)
        {
            _serviceCollection.TryAdd(key, value);
        }

        public static T GetService<T>()
        {
            _serviceCollection.TryGetValue(typeof(T), out var value);

            return (T)value;
        }
    }


    public class Consumer
    {
        private readonly IProductService _orderService;

        /// Explicitly programming 

        public Consumer(IProductService orderService)
        {
            _orderService = orderService;
            //_orderService = orderService;
        }

        public void Calculate()
        {
            // var orderService = ServiceLocator.GetService<IOrderService>();
            var calculate = _orderService.Calculate();

            // calculate something
        }

    }

    public interface IProductService
    {
        int Calculate();
    }

    class ProductService : IProductService
    {
        public int Calculate()
        {
            return 1000;
        }
    }
}