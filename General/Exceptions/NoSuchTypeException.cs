using System;

namespace CityFuture.General.Exceptions
{
	public class NoSuchTypeException : Exception
	{
		public NoSuchTypeException()
		{
		}

		public NoSuchTypeException(string message)
			:base(message)
		{

		}

		public NoSuchTypeException(string message, Exception inner)
			:base(message, inner)
		{
		}

	}
}