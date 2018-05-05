using System;
using Irony.Parsing;

namespace SystemOfSymbolicMathematics
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Grammar grammar = new ExpressionGrammar();;
            var parser = new Parser(grammar);
            var parseTree = parser.Parse("sin(x)");

            foreach (var node in parseTree.Tokens)
            {
                // TODO: abstract syntax tree
            }
        }
    }
}