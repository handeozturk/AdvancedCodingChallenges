using FindExpressionEvaluator;

string expression1 = "3 + 4 * (2 - 1)";
string expression2 = "(1 + 2) * 3 - 6 / 2";

Console.WriteLine("Result of expression1: " + ExpressionEvaluator.EvaluateExpression(expression1)); // Output: 7
Console.WriteLine("Result of expression2: " + ExpressionEvaluator.EvaluateExpression(expression2)); // Output: 9