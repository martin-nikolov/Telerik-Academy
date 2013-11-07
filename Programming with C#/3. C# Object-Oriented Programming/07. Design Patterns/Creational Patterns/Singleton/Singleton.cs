namespace Singleton
{
    public sealed class Singleton
    {
        private Singleton() { }

        private static readonly Singleton instance = new Singleton();

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
