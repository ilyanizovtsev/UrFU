using Irony.Parsing;

namespace SystemOfSymbolicMathematics
{
    [Language("Expression")]
    public class ExpressionGrammar : Grammar
    {
        public ExpressionGrammar()
        {
            // Terminals
            var number = new NumberLiteral("number");
            var identifier = new IdentifierTerminal("identifier");
            
            var expression = new NonTerminal("expression");
            var terminal = new NonTerminal("terminal");
            var binaryExpression = new NonTerminal("binaryExpression");
            var paranthesisExpression = new NonTerminal("paranthesisExpression");
            var unaryExpression = new NonTerminal("unaryExpression");
            var unaryOperator = new NonTerminal("unaryOperator");
            var binaryOperator = new NonTerminal("binaryOperator");
            var propertyAccess = new NonTerminal("propertyAccess");
            var functionCall = new NonTerminal("functionCall");
            var commandSeparatedIdentifierList = new NonTerminal("pointArgumentList");
            var argumentList = new NonTerminal("argumentList");

            // BNF rule
            expression.Rule = terminal | unaryExpression | binaryExpression;
            terminal.Rule = number | identifier | paranthesisExpression | functionCall |
                            propertyAccess;
            unaryExpression.Rule = unaryOperator + terminal;
            unaryOperator.Rule = ToTerm("-");
            binaryExpression.Rule = expression + binaryOperator + expression;
            binaryOperator.Rule = ToTerm("+") | "-" | "*" | "/" | "^";
            propertyAccess.Rule = identifier + "." + identifier;
            functionCall.Rule = identifier + "(" + argumentList + ")";
            argumentList.Rule = expression | commandSeparatedIdentifierList;
            paranthesisExpression.Rule = "(" + expression + ")";
            commandSeparatedIdentifierList.Rule = MakePlusRule(commandSeparatedIdentifierList,
                ToTerm(","), identifier);
            Root = expression;
            
            // Operators precedence
            RegisterOperators(1, "+", "-");
            RegisterOperators(2, "*", "/");
            RegisterOperators(3, Associativity.Right, "^");
            
            MarkPunctuation("(", ")", ".", ",");
            MarkTransient(terminal, expression, binaryOperator, unaryOperator, paranthesisExpression, argumentList, commandSeparatedIdentifierList);
        }
    }
}