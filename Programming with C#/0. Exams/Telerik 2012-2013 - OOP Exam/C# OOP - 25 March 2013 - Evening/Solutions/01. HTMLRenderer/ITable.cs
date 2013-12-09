namespace HTMLRenderer
{
    public interface ITable : IElement
    {
        int Rows { get; }

        int Cols { get; }

        IElement this[int row, int col] { get; set; }
    }
}