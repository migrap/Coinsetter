using Coinsetter.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Coinsetter.Linq
{
    public static partial class Extensions {		

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4, Expression<Func<TSource,object>> arg5){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4, arg5));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4, Expression<Func<TSource,object>> arg5, Expression<Func<TSource,object>> arg6){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4, arg5, arg6));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4, Expression<Func<TSource,object>> arg5, Expression<Func<TSource,object>> arg6, Expression<Func<TSource,object>> arg7){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4, Expression<Func<TSource,object>> arg5, Expression<Func<TSource,object>> arg6, Expression<Func<TSource,object>> arg7, Expression<Func<TSource,object>> arg8){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4, Expression<Func<TSource,object>> arg5, Expression<Func<TSource,object>> arg6, Expression<Func<TSource,object>> arg7, Expression<Func<TSource,object>> arg8, Expression<Func<TSource,object>> arg9){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4, Expression<Func<TSource,object>> arg5, Expression<Func<TSource,object>> arg6, Expression<Func<TSource,object>> arg7, Expression<Func<TSource,object>> arg8, Expression<Func<TSource,object>> arg9, Expression<Func<TSource,object>> arg10){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4, Expression<Func<TSource,object>> arg5, Expression<Func<TSource,object>> arg6, Expression<Func<TSource,object>> arg7, Expression<Func<TSource,object>> arg8, Expression<Func<TSource,object>> arg9, Expression<Func<TSource,object>> arg10, Expression<Func<TSource,object>> arg11){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4, Expression<Func<TSource,object>> arg5, Expression<Func<TSource,object>> arg6, Expression<Func<TSource,object>> arg7, Expression<Func<TSource,object>> arg8, Expression<Func<TSource,object>> arg9, Expression<Func<TSource,object>> arg10, Expression<Func<TSource,object>> arg11, Expression<Func<TSource,object>> arg12){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4, Expression<Func<TSource,object>> arg5, Expression<Func<TSource,object>> arg6, Expression<Func<TSource,object>> arg7, Expression<Func<TSource,object>> arg8, Expression<Func<TSource,object>> arg9, Expression<Func<TSource,object>> arg10, Expression<Func<TSource,object>> arg11, Expression<Func<TSource,object>> arg12, Expression<Func<TSource,object>> arg13){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4, Expression<Func<TSource,object>> arg5, Expression<Func<TSource,object>> arg6, Expression<Func<TSource,object>> arg7, Expression<Func<TSource,object>> arg8, Expression<Func<TSource,object>> arg9, Expression<Func<TSource,object>> arg10, Expression<Func<TSource,object>> arg11, Expression<Func<TSource,object>> arg12, Expression<Func<TSource,object>> arg13, Expression<Func<TSource,object>> arg14){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4, Expression<Func<TSource,object>> arg5, Expression<Func<TSource,object>> arg6, Expression<Func<TSource,object>> arg7, Expression<Func<TSource,object>> arg8, Expression<Func<TSource,object>> arg9, Expression<Func<TSource,object>> arg10, Expression<Func<TSource,object>> arg11, Expression<Func<TSource,object>> arg12, Expression<Func<TSource,object>> arg13, Expression<Func<TSource,object>> arg14, Expression<Func<TSource,object>> arg15){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
		}

		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource,object>> arg0, Expression<Func<TSource,object>> arg1, Expression<Func<TSource,object>> arg2, Expression<Func<TSource,object>> arg3, Expression<Func<TSource,object>> arg4, Expression<Func<TSource,object>> arg5, Expression<Func<TSource,object>> arg6, Expression<Func<TSource,object>> arg7, Expression<Func<TSource,object>> arg8, Expression<Func<TSource,object>> arg9, Expression<Func<TSource,object>> arg10, Expression<Func<TSource,object>> arg11, Expression<Func<TSource,object>> arg12, Expression<Func<TSource,object>> arg13, Expression<Func<TSource,object>> arg14, Expression<Func<TSource,object>> arg15, Expression<Func<TSource,object>> arg16){
			return source.Distinct(new PropertiesEqualityComparer<TSource>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
		}
	
    }
}
