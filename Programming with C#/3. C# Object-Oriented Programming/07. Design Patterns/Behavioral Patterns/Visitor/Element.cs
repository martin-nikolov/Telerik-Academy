namespace Visitor
{
    /// <summary>
    /// The 'Element' abstract class
    /// </summary>
    internal abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
}
