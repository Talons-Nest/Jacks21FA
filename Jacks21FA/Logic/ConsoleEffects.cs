
public interface IConsoleEffects

{
        public void TypeWriterEffect(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(10); //This gives us a more typewriter like effect.
            }
            Console.WriteLine();
        }

        public void PrintDelayEffect(string text)
    {
           foreach (char c in text)
           {
                Console.Write(c);//Print one character as a time.
                System.Threading.Thread.Sleep(100);
                Console.Out.Flush();
           }
            Console.WriteLine();
    }   

}
