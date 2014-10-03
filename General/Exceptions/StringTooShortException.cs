using System;

namespace CityFuture.General.Exceptions
{
	public class StringTooShortException : Exception
	{
		public StringTooShortException()
		{
		}
		
		public StringTooShortException(string message)
			:base(message)
		{
			
		}
		
		public StringTooShortException(string message, Exception inner)
			:base(message, inner)
		{
		}
		
	}
}

