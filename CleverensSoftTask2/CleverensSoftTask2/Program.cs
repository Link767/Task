namespace CleverensSoftTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 5 читателей 
            for(int i = 0; i < 5; i++)
            {
                new Thread(ReadServer).Start();
            }
            // 2 писателя
            for (int i = 0; i < 2; i++)
            {
                new Thread(WriteServer).Start();
            }

            static void ReadServer()
            {
                while (true)
                {
                    int c = Server.GetCount();
                    Console.WriteLine($"[Reader] Count = {c}");
                    Thread.Sleep(600);
                }
            }
            static void WriteServer()
            {
                while (true)
                {
                    Server.AddToCount(5);
                    Console.WriteLine("[Writer] +1 to count");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
