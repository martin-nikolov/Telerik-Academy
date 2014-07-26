namespace Cars.Tests.JustMock.Mocks
{
    using System;
    using System.Linq;
    using Cars.Contracts;
    using Cars.Models;
    using Telerik.JustMock;

    public class JustMockCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            this.CarsData = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => this.CarsData.Add(Arg.IsAny<Car>())).DoNothing();
            Mock.Arrange(() => this.CarsData.All()).Returns(this.FakeCarCollection);
            Mock.Arrange(() => this.CarsData.Search(Arg.AnyString)).Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());

            // Sort method
            Mock.Arrange(() => this.CarsData.SortedByMake()).Returns(this.FakeCarCollection.OrderBy(c => c.Make).Take(2).ToList());
            Mock.Arrange(() => this.CarsData.SortedByYear()).Returns(this.FakeCarCollection.OrderBy(c => c.Year).Take(2).ToList());

            // Search method
            Mock.Arrange(() => this.CarsData.Search(Arg.NullOrEmpty)).Throws(new ArgumentException());

            // Details/GetById method
            Mock.Arrange(() => this.CarsData.GetById(Arg.Is<int>(0))).Returns<Car>(null);
            Mock.Arrange(() => this.CarsData.GetById(Arg.IsInRange<int>(1, int.MaxValue, RangeKind.Inclusive))).Returns(this.FakeCarCollection.First());
        }
    }
}