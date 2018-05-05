namespace SystemOfSymbolicMathematics
{
    public class NameExpression : IExpression
    {
        public string Name { get; set; }

        public NameExpression(string name)
        {
            Name = name;
        }

        public string Representation() => Name;
        public IExpression Clone() => new NameExpression(Name);
    }
}