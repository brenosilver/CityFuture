using System;

namespace CityFuture.General.Exceptions
{
	public class NotAProperNumberException : Exception
	{
		public NotAProperNumberException()
		{
		}
		
		public NotAProperNumberException(string message)
			:base(message)
		{
			
		}
		
		public NotAProperNumberException(string message, Exception inner)
			:base(message, inner)
		{
		}
		
	}
}
