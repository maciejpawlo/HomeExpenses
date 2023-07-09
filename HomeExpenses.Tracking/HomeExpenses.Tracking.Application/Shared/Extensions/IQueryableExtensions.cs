using System;
using System.Linq.Expressions;

namespace HomeExpenses.Tracking.Application.Shared.Extensions
{
	public static class IQueryableExtensions
	{
		public static IQueryable<T> ConditionalWhere<T>(this IQueryable<T> source, bool condition, Expression<Func<T, bool>> predicate)
		{
			if (condition)
			{
				return source.Where(predicate);
			}
			return source;
		}
	}
}

