using System;

namespace NinjaRazorPages
{
    public interface IIdGenerator
    {
        Guid Create();
    }
}