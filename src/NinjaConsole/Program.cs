using System;

namespace NinjaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstChain = new FirstChain();
            var secondChain = new SecondChain();
            var thirdChain = new ThirdChain();

            firstChain.SetNext(secondChain);
            secondChain.SetNext(thirdChain);

            firstChain.Handle("Hello Milad ... ");

            Console.Read();
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
