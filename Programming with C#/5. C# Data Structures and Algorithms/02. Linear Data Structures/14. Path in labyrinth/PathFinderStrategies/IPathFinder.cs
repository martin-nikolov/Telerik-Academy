namespace PathFinders.PathFinderStrategies
{
    public interface IPathFinder
    {
        string[,] FindAllPaths(string[,] matrix);
    }
}