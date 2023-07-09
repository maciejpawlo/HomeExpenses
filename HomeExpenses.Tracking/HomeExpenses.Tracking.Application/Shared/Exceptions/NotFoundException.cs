using System;
namespace HomeExpenses.Tracking.Application.Shared.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException()
		{
		}

        public NotFoundException(string? message) : base(message)
        {
        }
    }
}

