using UnityEngine;
using CityFuture.Agents.Enums;

namespace CityFuture.Agents
{
	public class Airplane : Vehicle
	{
		private AirplaneVariation variation;

		// Add Airplane Component to the gameObject
		public static Airplane CreateComponent (GameObject agent_obj, AirplaneVariation parameter1)
		{
			Airplane myC = agent_obj.AddComponent<Airplane>();
			myC.variation = parameter1;
			
			return myC;
		}

	}
}
