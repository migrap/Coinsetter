using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Coinsetter.Collections.Generic {
    internal class PropertiesEqualityComparer<T> : IEqualityComparer<T> {
        private List<Func<T, object>> _predicates;

        public PropertiesEqualityComparer(params Expression<Func<T, object>>[] expressions)
            : this(expressions.Select(x => x.Compile())) {
        }

        public PropertiesEqualityComparer(IEnumerable<Func<T, object>> predicates) {
            _predicates = new List<Func<T, object>>(predicates);
        }

        public bool Equals(T x, T y) {
            foreach(var predicate in _predicates) {
                var xo = predicate(x);
                var yo = predicate(y);
                if(false == xo.Equals(yo)) {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(T obj) {
            return _predicates.GetHashCode();
        }
    }
}