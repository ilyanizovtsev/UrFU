namespace SystemOfSymbolicMathematics
{
    public class FunctionExpression : IExpression
    {
        public string Name { get; set; }
        public IExpression Argument { get; set; }

        public FunctionExpression(string name, IExpression argument)
        {
            Name = name;
            Argument = argument;
        }

        public string Representation() => Name + "(" + Argument.Representation() + ")";
        public IExpression Clone() => new FunctionExpression(Name, Argument.Clone());
    }
}