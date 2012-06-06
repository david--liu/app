using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace app.code_kata.ExpressionTree
{
    public class ExpressionConverter : IExpressionConverter
    {
        char plus = '+';
        char minus = '-';
        char multi = '*';
        char divide = '/';
        char leftBracket = '(';
        char rightBraket = ')';
        char EOS = ';';

        private bool IsSecondOperatorPrecedenceHigherThanFirst(char left, char right)
        {
            if (left == plus || left == minus)
                return (right == multi || right == divide);
            else
            {
                return false;
            }
        }

        private bool IsAnOperator(char chr)
        {
            return chr == plus || chr == minus || chr == multi || chr == divide;
        }

        public string ConvertToPostfix(string infix)
        {
            var builder = new StringBuilder();
            var stack = new Stack<char>();
            stack.Push(EOS);
            foreach (var chr in infix.ToCharArray())
            {
                if(chr == ' ')
                    continue;

                if (IsAnOperator(chr))
                {
                    var peek = stack.Peek();
                    if(IsAnOperator(peek))
                    {
                        if (!IsSecondOperatorPrecedenceHigherThanFirst(peek, chr))
                        {
                            builder.Append(stack.Pop());
                        }
                    }
                    builder.Append(' ');
                    stack.Push(chr);
                }
                else if(chr == leftBracket)
                {
                    stack.Push(chr);
                }
                else if(chr == rightBraket)
                {
                    while (stack.Peek() != leftBracket)
                    {
                        builder.Append(stack.Pop());
                    }

                    stack.Pop();
                }
                else
                {
                    builder.Append(chr);
                }
                
            }

            while (stack.Peek() != EOS)
            {
                builder.Append(stack.Pop());
            }
            
            return builder.ToString();
        }

        private BinaryNode CreateOperatorBinaryNode(char chr)
        {
            if (chr == plus) return new AddBinaryNode();
            if (chr == minus) return new SubBinaryNode();
            if (chr == multi) return new MultiBinaryNode();
            if (chr == divide) return new DivBinaryNode();
            throw new NotSupportedException();
        }

        public BinaryNode ConstructBinaryTree<T>(string expression) 
        {
            var operandStack = new Stack<BinaryNode>();
            var operatorStack = new Stack<char>();
            var operatorNodeStack = new Stack<BinaryNode>();
            operatorStack.Push(EOS);
            foreach (var chr in expression.ToCharArray())
            {
                if (chr == ' ')
                    continue;

                if (IsAnOperator(chr))
                {
                    var peek = operatorStack.Peek();
                    if (IsAnOperator(peek))
                    {
                        if (!IsSecondOperatorPrecedenceHigherThanFirst(peek, chr))
                        {
                            PopOperator(operandStack, operatorStack);
                        }
                    }
                    operatorStack.Push(chr);
                }
                else if (chr == leftBracket)
                {
                    operatorStack.Push(chr);
                }
                else if (chr == rightBraket)
                {
                    while (operatorStack.Peek() != leftBracket)
                    {
                        PopOperator(operandStack, operatorStack);
                    }

                    operatorStack.Pop();
                }
                else
                {
                    //TODO: need to support multi digits
                    var node = new BinaryNode((int)Char.GetNumericValue(chr));
                    operandStack.Push(node);
                }
            }

            while (operatorStack.Peek() != EOS)
            {
                PopOperator(operandStack, operatorStack);
            }

            return operandStack.Pop();
        }

        void PopOperator(Stack<BinaryNode> operandStack, Stack<char> operatorStack)
        {
            var operatorBinaryNode = CreateOperatorBinaryNode(operatorStack.Pop());
            operatorBinaryNode.rightNode = operandStack.Pop();
            operatorBinaryNode.leftNode = operandStack.Pop();
            operandStack.Push(operatorBinaryNode);
        }
    }
}