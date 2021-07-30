using System;
using System.Collections.Generic;

namespace NinjaConsole
{

    public delegate void RequestDelegate(string context);


    public class ApplicationBuilder
    {
        private List<Func<RequestDelegate, RequestDelegate>> _handlers = new List<Func<RequestDelegate, RequestDelegate>>();

        public ApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> handler)
        {
            _handlers.Add(handler);
            return this;
        }

        public RequestDelegate Build()
        {
            RequestDelegate next = context => Console.Write("I am the last one!");
            _handlers.Reverse();

            foreach (var handler in _handlers)
            {
                next = handler(next);
            }

            return next;
        }
    }
}