namespace Northwind.Models
{
    using System;
    using System.Data.Linq;
    using System.Linq;

    public partial class Employee
    {
        public EntitySet<Territory> CorrespondingTerritories
        {
            get
            {
                var territoriesAsEntitySet = new EntitySet<Territory>();
                territoriesAsEntitySet.AddRange(this.Territories);
                return territoriesAsEntitySet;
            }
        }
    }
}