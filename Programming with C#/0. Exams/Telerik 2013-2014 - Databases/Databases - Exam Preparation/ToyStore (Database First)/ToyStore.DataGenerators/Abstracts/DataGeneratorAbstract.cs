namespace ToyStore.DataGenerators.Abstracts
{
    using System;
    using System.Linq;
    using ToyStore.Data.Contracts;
    using ToyStore.DataGenerators.Contracts;
    
    public abstract class DataGeneratorAbstract : IDataGenerator
    {
        private IToyStoreContext toyStoreContext;
        private ILogger logger;
        private int seedDataCount;

        public DataGeneratorAbstract(IToyStoreContext toyStoreContext, int seedDataCount, ILogger logger)
        {
            this.toyStoreContext = toyStoreContext;
            this.seedDataCount = seedDataCount;
            this.logger = logger;
        }

        protected int SeedDataCount
        {
            get
            {
                return this.seedDataCount;
            }
            set
            {
                this.seedDataCount = value;
            }
        }

        protected IToyStoreContext ToyStoreContext
        {
            get
            {
                return this.toyStoreContext;
            }
            set
            {
                this.toyStoreContext = value;
            }
        }

        protected ILogger Logger
        {
            get
            {
                return this.logger;
            }
            set
            {
                this.logger = value;
            }
        }

        public abstract void Seed();
    }
}