#region

using System.Collections.Generic;
using System.Linq.Expressions;

#endregion

namespace CnblogsLinqProvider {
    public class CnblogsQueryProvider : QueryProvider {
        public override string GetQueryText(Expression expression) {
            // 翻译查询条件
            var criteria = new PostExpressionVisitor().ProcessExpression(expression);
            // 生成URL
            return PostHelper.BuildUrl(criteria);
        }

        public override object Execute(Expression expression) {
            var url = GetQueryText(expression);
            var results = PostHelper.PerformWebQuery(url);
            return results;
        }
    }
}