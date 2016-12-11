#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

#endregion

namespace CnblogsLinqProvider {
    public class Query<T> : IOrderedQueryable<T> {

        private readonly Expression _expression;
        private readonly QueryProvider _provider;

        public Query(QueryProvider provider) {
            if (provider == null) {
                throw new ArgumentNullException(nameof(provider));
            }
            this._provider = provider;
            _expression = Expression.Constant(this);
        }

        public Query(QueryProvider provider, Expression expression) {
            if (provider == null) {
                throw new ArgumentNullException(nameof(provider));
            }
            if (expression == null) {
                throw new ArgumentNullException(nameof(expression));
            }
            if (!typeof(IQueryable<T>).IsAssignableFrom(expression.Type)) {
                throw new ArgumentOutOfRangeException(nameof(expression));
            }
            _provider = provider;
            _expression = expression;
        }

        Expression IQueryable.Expression => _expression;

        Type IQueryable.ElementType => typeof(T);

        IQueryProvider IQueryable.Provider => _provider;

        public IEnumerator<T> GetEnumerator() {
            return ((IEnumerable<T>) _provider.Execute(_expression)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable) _provider.Execute(_expression)).GetEnumerator();
        }

        public override string ToString() {
            return _provider.GetQueryText(_expression);
        }
    }
}