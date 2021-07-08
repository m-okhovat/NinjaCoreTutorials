using System.Collections.Generic;

namespace NinjaAspNetCore.Pipes
{
    public class Pipeline
    {
        private List<IFilter> _filters;

        public Pipeline()
        {
            _filters = new List<IFilter>();
        }

        public void AddFilter(IFilter filter)
        {
            _filters.Add(filter);
        }

        public void Process(Request request)
        {
            foreach (var filter in _filters)
            {
                filter.Handle(request);
            }
        }
    }
}