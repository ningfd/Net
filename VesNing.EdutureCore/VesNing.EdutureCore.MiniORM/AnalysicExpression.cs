using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace VesNing.EdutureCore.MiniORM
{
    class AnalysicExpression:ExpressionVisitor
    {
        StringBuilder builder = new StringBuilder();
        public override Expression Visit(Expression node)
        {
            return base.Visit(node);
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            Console.WriteLine($"VisitMember:{node.Member.Name}");
            builder.Append(node.Member.Name);
            return base.VisitMember(node);
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
           
            this.Visit(node.Left);
            if (node.NodeType ==ExpressionType.Equal)
            {
                builder.Append(" = ");
            }
            else if (node.NodeType==ExpressionType.AndAlso)
            {
                builder.Append(" AND  ");
            }
            else if (node.NodeType==ExpressionType.OrElse)
            {
                builder.Append(" Or  ");
            }
            this.Visit(node.Right);
            return node;
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Type.IsValueType)
            {
                builder.AppendFormat(" {0} ", node.Value);
            }else
            {
                builder.AppendFormat(" '{0}' ", node.Value);
            }
          
            return base.VisitConstant(node);
        }

        public string Sql()
        {
            return builder.ToString();
        }
    }
}
