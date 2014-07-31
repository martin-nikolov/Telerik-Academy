namespace FacadePattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HomeTheaterPro es = HomeTheaterPro.GetInstance();

            es.InitHomeSystem();
            es.Next();
            es.Next();
            es.Stop();
        }
    }
}