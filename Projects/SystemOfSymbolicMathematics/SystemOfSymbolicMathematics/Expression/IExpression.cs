namespace SystemOfSymbolicMathematics
{
    public interface IExpression
    {
        string Representation();
        IExpression Clone();
    }
}