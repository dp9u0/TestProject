#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using CnblogsLinqProvider;

#endregion

namespace LinqTocnblogs.Controllers {
    public class PostController : Controller {
        [HttpGet]
        public JsonResult Index(SearchCriteria criteria = null) {
            var result = PostManager.Posts;
            if (criteria != null) {
                if (!string.IsNullOrEmpty(criteria.Title))
                    result = result.Where(
                        p => p.Title.IndexOf(criteria.Title, StringComparison.OrdinalIgnoreCase) >= 0);

                if (!string.IsNullOrEmpty(criteria.Author))
                    result =
                        result.Where(p => p.Author.IndexOf(criteria.Author, StringComparison.OrdinalIgnoreCase) >= 0);

                if (criteria.Start.HasValue)
                    result = result.Where(p => p.Published >= criteria.Start.Value);

                if (criteria.End.HasValue)
                    result = result.Where(p => p.Published <= criteria.End.Value);

                if (criteria.MinComments > 0)
                    result = result.Where(p => p.Comments >= criteria.MinComments);

                if (criteria.MinDiggs > 0)
                    result = result.Where(p => p.Diggs >= criteria.MinDiggs);

                if (criteria.MinViews > 0)
                    result = result.Where(p => p.Diggs >= criteria.MinViews);

                if (criteria.MaxComments > 0)
                    result = result.Where(p => p.Comments <= criteria.MaxComments);

                if (criteria.MaxDiggs > 0)
                    result = result.Where(p => p.Diggs <= criteria.MaxDiggs);

                if (criteria.MaxViews > 0)
                    result = result.Where(p => p.Diggs <= criteria.MaxViews);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///     The property value of an object is assigned to another object
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="source">Original object</param>
        /// <param name="result">New object</param>
        /// <param name="exceptions">Some properties doesn't need to change</param>
        protected void Transform<TSource, TResult, TProperty>(TSource source, TResult result,
            params Expression<Func<TSource, TProperty>>[] exceptions) {
            var exceptionalProp = new List<PropertyInfo>();
            foreach (var expr in exceptions) {
                MemberExpression memberAccess = null;
                switch (expr.Body.NodeType) {
                    case ExpressionType.Convert:
                        memberAccess = (expr.Body as UnaryExpression).Operand as MemberExpression;
                        break;
                    case ExpressionType.MemberAccess:
                        memberAccess = expr.Body as MemberExpression;
                        break;
                }

                if (memberAccess != null) {
                    exceptionalProp.Add(memberAccess.Member as PropertyInfo);
                }
            }

            List<PropertyInfo> resultProps =
                result.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            List<PropertyInfo> sourceProps =
                source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            sourceProps = sourceProps.Except(exceptionalProp).ToList();
            sourceProps.ForEach(v => {
                var resultProp = resultProps.SingleOrDefault(p => p.Name == v.Name);
                if (resultProp != null) {
                    resultProp.SetValue(result, v.GetValue(source));
                }
            });
        }
    }
}