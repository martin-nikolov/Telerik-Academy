namespace App.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUowData : IDisposable
    {
        IRepository<Model> Models { get; }

        int SaveChanges();
    }
}
