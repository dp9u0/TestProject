#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

#endregion

namespace CnblogsLinqProvider {
    public class PostSearch : IEnumerable<Post> {
        private SearchCriteria _criteria;

        IEnumerator<Post> IEnumerable<Post>.GetEnumerator() {
            return (IEnumerator<Post>) ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            string url = PostHelper.BuildUrl(_criteria);
            IEnumerable<Post> posts = PostHelper.PerformWebQuery(url);

            return posts.GetEnumerator();
        }

        public PostSearch Where(Expression<Func<Post, bool>> predicate) {
            _criteria = new PostExpressionVisitor().ProcessExpression(predicate);
            return this;
        }

        public PostSearch Select<TResult>(Expression<Func<Post, TResult>> selector) {
            return this;
        }
    }
}