namespace UserTimer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var counter = new ClassCounter();
            var handler1 = new HandlerI();
            var handler2 = new HandlerII();

            counter.OnCount += handler1.ShowMessage;
            counter.OnCount += handler2.ShowMessage;

            counter.Count();
        }
    }
}
