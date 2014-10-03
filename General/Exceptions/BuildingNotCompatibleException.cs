using System;

namespace CityFuture.General.Exceptions
{
	public class BuildingNotCompatibleException : Exception
	{
		public BuildingNotCompatibleException()
		{
		}
		
		public BuildingNotCompatibleException(string message)
			:base(message)
		{
			
		}
		
		public BuildingNotCompatibleException(string message, Exception inner)
			:base(message, inner)
		{
		}
		
	}
}
