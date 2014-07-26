namespace Cars.Contracts
{
    using System.Collections.Generic;
    using Cars.Models;

    public interface IDatabase
    {
        IList<Car> Cars { get; set; }
    }
}