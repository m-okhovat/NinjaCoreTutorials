namespace NinjaAspNetCore.Pipes
{
    public interface IFilter
    {
        void Handle(Request request);
    }
}