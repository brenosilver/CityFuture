using UnityEngine;
using CityFuture.Agents.Enums;

namespace CityFuture.Agents
{
	public class Boat : Vehicle
	{
		private BoatVariation variation;

		// Add Boat Component to the gameObject
		public static Boat CreateComponent (GameObject agent_obj, BoatVariation parameter1)
		{
			Boat myC = agent_obj.AddComponent<Boat>();
			myC.variation = parameter1;
			
			return myC;
		}
	}
}