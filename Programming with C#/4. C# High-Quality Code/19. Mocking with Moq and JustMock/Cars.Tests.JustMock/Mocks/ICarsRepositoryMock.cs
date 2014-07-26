namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;

    public interface ICarsRepositoryMock
    {
        ICarsRepository CarsData { get; }
    }
}