using System;

namespace NinjaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var applicationBuilder = new ApplicationBuilder();

            var pipeline = applicationBuilder
                 .Use(FirstMiddlewareWrapper)
                 .Use(SecondMiddlewareWrapper)
                 .Build();

            pipeline("Milad");

            Console.Read();

        }

        private static RequestDelegate FirstMiddlewareWrapper(RequestDelegate next)
        {
            RequestDelegate result = context =>
            {
                var helloFromFirst = context + " Hello From first =>";
                Console.Write(helloFromFirst);
                next(helloFromFirst);
            };

            return result;

        }

        private static RequestDelegate SecondMiddlewareWrapper(RequestDelegate next)
        {
            RequestDelegate result = context =>
            {
                var helloFromSecond = context + " Hello From second =>";
                Console.Write(helloFromSecond);
                next(helloFromSecond);
            };

            return result;

        }
    }

    public abstract class Chain
    {
        protected Chain Next;
        public abstract void Handle(string input);

        public void SetNext(Chain next)
        {
            Next = next;
        }
    }

    public class FirstChain : Chain
    {
        public override void Handle(string input)
        {
            var result = input + "*** Hello from fist chain";
            Console.Write(result);
            Next.Handle(result);
        }
    }

    public class SecondChain : Chain
    {
        public override void Handle(string input)
        {
            var result = input + "*** Hello from second chain";
            Console.Write(result);
            Next.Handle(result);
        }
    }

    public class ThirdChain : Chain
    {
        public override void Handle(string input)
        {
            var result = input + "*** Hello from third chain";
            Console.Write(result);
        }
    }
}
