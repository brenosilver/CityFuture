using CityFuture.Agents.Enums;
using System.Collections;
using CityFuture.Buildings;
using UnityEngine;

namespace CityFuture.Agents
{
	public abstract class Agent : MonoBehaviour
	{
		// Hide the agent from the map
		public abstract bool showAgent();

		// Hide the agent from the map
		public abstract bool hideAgent();

		// get the id of this agent
		public abstract int getID();

		// set the id of this agent
		public abstract void setID(int id);

		// Move a given agent to a given Building
		public abstract bool moveAgent(Building origin, Building dest);

		// Move a given agent to a given Building
		public abstract void moveAgent(Transform origin, Transform dest);

	}
}