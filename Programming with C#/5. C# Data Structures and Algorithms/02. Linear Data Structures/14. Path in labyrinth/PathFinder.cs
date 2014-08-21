namespace PathFinders
{
    using System;
    using System.Linq;
    using PathFinders.PathFinderStrategies;

    public class PathFinder
    {
        public string[,] FindAllPaths(string[,] matrix, IPathFinder pathFinderStrategy)
        {
            var clonedMatrix = (string[,])matrix.Clone();
            var resultMatrix = pathFinderStrategy.FindAllPaths(clonedMatrix);
            return resultMatrix;
        }
    }
}