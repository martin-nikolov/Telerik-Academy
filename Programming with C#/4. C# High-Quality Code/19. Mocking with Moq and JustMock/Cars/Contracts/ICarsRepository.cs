namespace Cars.Contracts
{
    using System.Collections.Generic;
    using Cars.Models;

    public interface ICarsRepository
    {
        int TotalCars { get; }

        void Add(Car car);

        void Remove(Car car);

        Car GetById(int id);

        ICollection<Car> All();

        ICollection<Car> SortedByMake();

        ICollection<Car> SortedByYear();

        ICollection<Car> Search(string condition);
    }
}