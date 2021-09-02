using Microsoft.Extensions.DependencyInjection;
using System;

namespace NinjaRazorPages
{
    public class IdGenerator : IIdGenerator   // Singleton > Scoped > Transient
    {
        private readonly IServiceProvider _serviceProvider;

        public IdGenerator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Guid Create()
        {
            IServiceScope serviceScope = _serviceProvider.CreateScope();

            using (serviceScope)
            {
                var provider = serviceScope.ServiceProvider;

                var orderService = provider.GetRequiredService<IOrderService>();

                // .... 
            }

            //... 
            return Guid.NewGuid();
        }
    }
}