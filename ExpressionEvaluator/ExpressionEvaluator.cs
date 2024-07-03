namespace FindExpressionEvaluator;

public class ExpressionEvaluator
{
    public static int EvaluateExpression(string expression)
    {
        Stack<int> operandStack = new Stack<int>();
        Stack<char> operatorStack = new Stack<char>();
        for (int i = 0; i < expression.Length; i++)
        {
            char ch = expression[i];

            if (ch == ' ')
            {
                continue; // Skip spaces
            }
            else if (char.IsDigit(ch))
            {
                int num = 0;
                while (i < expression.Length && char.IsDigit(expression[i]))
                {
                    num = num * 10 + (expression[i] - '0');
                    i++;
                }
                i--; // Adjust i back one position
                operandStack.Push(num);
            }
            else if (ch == '(')
            {
                operatorStack.Push(ch);
            }
            else if (ch == ')')
            {
                while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
                {
                    ProcessOperator(operandStack, operatorStack);
                }
                operatorStack.Pop(); // Pop '('
            }
            else if (IsOperator(ch))
            {
                while (operatorStack.Count > 0 && Precedence(operatorStack.Peek()) >= Precedence(ch))
                {
                    ProcessOperator(operandStack, operatorStack);
                }
                operatorStack.Push(ch);
            }
            else
            {
                throw new ArgumentException("Invalid character in expression");
            }
        }

        while (operatorStack.Count > 0)
        {
            ProcessOperator(operandStack, operatorStack);
        }

        if (operandStack.Count == 1 && operatorStack.Count == 0)
        {
            return operandStack.Pop();
        }
        else
        {
            throw new ArgumentException("Invalid expression format");
        }
    }

    private static void ProcessOperator(Stack<int> operandStack, Stack<char> operatorStack)
    {
        char op = operatorStack.Pop();
        int operand2 = operandStack.Pop();
        int operand1 = operandStack.Pop();
        int result = ApplyOperator(op, operand1, operand2);
        operandStack.Push(result);
    }

    private static int ApplyOperator(char op, int operand1, int operand2)
    {
        switch (op)
        {
            case '+':
                return operand1 + operand2;
            case '-':
                return operand1 - operand2;
            case '*':
                return operand1 * operand2;
            case '/':
                if (operand2 == 0)
                    throw new DivideByZeroException("Division by zero");
                return operand1 / operand2;
            default:
                throw new ArgumentException("Invalid operator");
        }
    }

    private static bool IsOperator(char ch)
    {
        return ch == '+' || ch == '-' || ch == '*' || ch == '/';
    }

    private static int Precedence(char op)
    {
        switch (op)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            default:
                return 0;
        }
    }
}