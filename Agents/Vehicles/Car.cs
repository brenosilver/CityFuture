using UnityEngine;
using CityFuture.Agents.Enums;

namespace CityFuture.Agents
{
	public class Car : Vehicle
	{
		private CarVariation variation;

		// Add Car Component to the gameObject
		public static Car CreateComponent (GameObject agent_obj, CarVariation parameter1)
		{
			Car myC = agent_obj.AddComponent<Car>();
			myC.variation = parameter1;
			
			return myC;
		}

	}
}