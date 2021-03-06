﻿#region

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

#endregion

namespace CnblogsLinqProvider {
    public class PostExpressionVisitor {


        private SearchCriteria _criteria;

// 入口方法
        public SearchCriteria ProcessExpression(Expression expression) {
            _criteria = new SearchCriteria();
            VisitExpression(expression);
            return _criteria;
        }

        private void VisitExpression(Expression expression) {
            switch (expression.NodeType) {
                // 访问 &&
                case ExpressionType.AndAlso:
                    VisitAndAlso((BinaryExpression) expression);
                    break;
                // 访问 等于
                case ExpressionType.Equal:
                    VisitEqual((BinaryExpression) expression);
                    break;
                // 访问 小于和小于等于
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                    VisitLessThanOrEqual((BinaryExpression) expression);
                    break;
                // 访问大于和大于等于
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                    GreaterThanOrEqual((BinaryExpression) expression);
                    break;
                // 访问调用方法，主要有于解析Contains方法，我们的Title会用到
                case ExpressionType.Call:
                    VisitMethodCall((MethodCallExpression) expression);
                    break;
                // 访问Lambda表达式
                case ExpressionType.Lambda:
                    VisitExpression(((LambdaExpression) expression).Body);
                    break;
            }
        }

// 访问  &&
        private void VisitAndAlso(BinaryExpression andAlso) {
            VisitExpression(andAlso.Left);
            VisitExpression(andAlso.Right);
        }

// 访问 等于
        private void VisitEqual(BinaryExpression expression) {
            // 我们这里面只处理在Author上的等于操作
            // Views, Comments, 和 Diggs 我们都是用的大于等于，或者小于等于
            if ((expression.Left.NodeType == ExpressionType.MemberAccess) &&
                (((MemberExpression) expression.Left).Member.Name == "Author")) {
                if (expression.Right.NodeType == ExpressionType.Constant)
                    _criteria.Author =
                        (string) ((ConstantExpression) expression.Right).Value;

                else if (expression.Right.NodeType == ExpressionType.MemberAccess)
                    _criteria.Author =
                        (string) GetMemberValue((MemberExpression) expression.Right);

                else
                    throw new NotSupportedException("Expression type not supported for author: " +
                                                    expression.Right.NodeType);
            }
        }

// 访问大于等于
        private void GreaterThanOrEqual(BinaryExpression expression) {
            // 处理 Diggs >= n  推荐人数
            if ((expression.Left.NodeType == ExpressionType.MemberAccess) &&
                (((MemberExpression) expression.Left).Member.Name == "Diggs")) {
                if (expression.Right.NodeType == ExpressionType.Constant)
                    _criteria.MinDiggs =
                        (int) ((ConstantExpression) expression.Right).Value;

                else if (expression.Right.NodeType == ExpressionType.MemberAccess)
                    _criteria.MinDiggs =
                        (int) GetMemberValue((MemberExpression) expression.Right);

                else
                    throw new NotSupportedException("Expression type not supported for Diggs:"
                                                    + expression.Right.NodeType);
            }
            // 处理 Views>= n   访问人数
            else if ((expression.Left.NodeType == ExpressionType.MemberAccess) &&
                     (((MemberExpression) expression.Left).Member.Name == "Views")) {
                if (expression.Right.NodeType == ExpressionType.Constant)
                    _criteria.MinViews =
                        (int) ((ConstantExpression) expression.Right).Value;

                else if (expression.Right.NodeType == ExpressionType.MemberAccess)
                    _criteria.MinViews =
                        (int) GetMemberValue((MemberExpression) expression.Right);

                else
                    throw new NotSupportedException("Expression type not supported for Views: "
                                                    + expression.Right.NodeType);
            }
            // 处理 comments >= n   评论数
            else if ((expression.Left.NodeType == ExpressionType.MemberAccess) &&
                     (((MemberExpression) expression.Left).Member.Name == "Comments")) {
                if (expression.Right.NodeType == ExpressionType.Constant)
                    _criteria.MinComments =
                        (int) ((ConstantExpression) expression.Right).Value;

                else if (expression.Right.NodeType == ExpressionType.MemberAccess)
                    _criteria.MinComments =
                        (int) GetMemberValue((MemberExpression) expression.Right);

                else
                    throw new NotSupportedException("Expression type not supported for Comments: "
                                                    + expression.Right.NodeType);
            }
            // 处理 发布时间>=
            else if ((expression.Left.NodeType == ExpressionType.MemberAccess) &&
                     (((MemberExpression) expression.Left).Member.Name == "Published")) {
                if (expression.Right.NodeType == ExpressionType.Constant)
                    _criteria.Start =
                        (DateTime) ((ConstantExpression) expression.Right).Value;

                else if (expression.Right.NodeType == ExpressionType.MemberAccess)
                    _criteria.Start =
                        (DateTime) GetMemberValue((MemberExpression) expression.Right);

                else
                    throw new NotSupportedException("Expression type not supported for Published: "
                                                    + expression.Right.NodeType);
            }
        }

// 访问 小于和小于等于
        private void VisitLessThanOrEqual(BinaryExpression expression) {
            // 处理 Diggs <= n  推荐人数
            if ((expression.Left.NodeType == ExpressionType.MemberAccess) &&
                (((MemberExpression) expression.Left).Member.Name == "Diggs")) {
                if (expression.Right.NodeType == ExpressionType.Constant)
                    _criteria.MaxDiggs =
                        (int) ((ConstantExpression) expression.Right).Value;

                else if (expression.Right.NodeType == ExpressionType.MemberAccess)
                    _criteria.MaxDiggs =
                        (int) GetMemberValue((MemberExpression) expression.Right);

                else
                    throw new NotSupportedException("Expression type not supported for Diggs: "
                                                    + expression.Right.NodeType);
            }
            // 处理 Views<= n   访问人数
            else if ((expression.Left.NodeType == ExpressionType.MemberAccess) &&
                     (((MemberExpression) expression.Left).Member.Name == "Views")) {
                if (expression.Right.NodeType == ExpressionType.Constant)
                    _criteria.MaxViews =
                        (int) ((ConstantExpression) expression.Right).Value;

                else if (expression.Right.NodeType == ExpressionType.MemberAccess)
                    _criteria.MaxViews =
                        (int) GetMemberValue((MemberExpression) expression.Right);

                else
                    throw new NotSupportedException("Expression type not supported for Views: "
                                                    + expression.Right.NodeType);
            }
            // 处理 comments <= n   评论数
            else if ((expression.Left.NodeType == ExpressionType.MemberAccess) &&
                     (((MemberExpression) expression.Left).Member.Name == "Comments")) {
                if (expression.Right.NodeType == ExpressionType.Constant)
                    _criteria.MaxComments =
                        (int) ((ConstantExpression) expression.Right).Value;

                else if (expression.Right.NodeType == ExpressionType.MemberAccess)
                    _criteria.MaxComments =
                        (int) GetMemberValue((MemberExpression) expression.Right);

                else
                    throw new NotSupportedException("Expression type not supported for Comments: "
                                                    + expression.Right.NodeType);
            }

            // 处理发布时间 <= 
            else if ((expression.Left.NodeType == ExpressionType.MemberAccess) &&
                     (((MemberExpression) expression.Left).Member.Name == "Published")) {
                if (expression.Right.NodeType == ExpressionType.Constant)
                    _criteria.End =
                        (DateTime) ((ConstantExpression) expression.Right).Value;

                else if (expression.Right.NodeType == ExpressionType.MemberAccess)
                    _criteria.End =
                        (DateTime) GetMemberValue((MemberExpression) expression.Right);

                else
                    throw new NotSupportedException("Expression type not supported for Published: "
                                                    + expression.Right.NodeType);
            }
        }

// 访问 方法调用
        private void VisitMethodCall(MethodCallExpression expression) {
            if ((expression.Method.DeclaringType == typeof(Queryable)) &&
                (expression.Method.Name == "Where")) {
                VisitExpression(((UnaryExpression) expression.Arguments[1]).Operand);
            } else if ((expression.Method.DeclaringType == typeof(string)) &&
                       (expression.Method.Name == "Contains")) {
                // Handle Title.Contains("")
                if (expression.Object != null && expression.Object.NodeType == ExpressionType.MemberAccess) {
                    var memberExpr = (MemberExpression) expression.Object;
                    if (memberExpr.Expression.Type == typeof(Post)) {
                        if (memberExpr.Member.Name == "Title") {
                            var argument = expression.Arguments[0];
                            if (argument.NodeType == ExpressionType.Constant) {
                                _criteria.Title =
                                    (string) ((ConstantExpression) argument).Value;
                            } else if (argument.NodeType == ExpressionType.MemberAccess) {
                                _criteria.Title =
                                    (string) GetMemberValue((MemberExpression) argument);
                            } else {
                                throw new NotSupportedException("Expression type not supported: "
                                                                + argument.NodeType);
                            }
                        }
                    }
                }
            } else {
                throw new NotSupportedException("Method not supported: "
                                                + expression.Method.Name);
            }
        }

// 获取属性值
        private object GetMemberValue(MemberExpression memberExpression) {
            object obj;

            if (memberExpression == null)
                throw new ArgumentNullException(nameof(memberExpression));


            if (memberExpression.Expression is ConstantExpression)
                obj = ((ConstantExpression) memberExpression.Expression).Value;
            else if (memberExpression.Expression is MemberExpression)
                obj = GetMemberValue((MemberExpression) memberExpression.Expression);
            else
                throw new NotSupportedException("Expression type not supported: "
                                                + memberExpression.Expression.GetType().FullName);

            var memberInfo = memberExpression.Member;
            var info = memberInfo as PropertyInfo;
            if (info != null) {
                var property = info;
                return property.GetValue(obj, null);
            }
            var fieldInfo = memberInfo as FieldInfo;
            if (fieldInfo != null) {
                var field = fieldInfo;
                return field.GetValue(obj);
            }
            throw new NotSupportedException("MemberInfo type not supported: "
                                            + memberInfo.GetType().FullName);
        }
    }
}