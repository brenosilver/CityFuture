using CityFuture.Agents.Enums;
using System.Collections;
using CityFuture.Buildings;
using UnityEngine;

namespace CityFuture.Agents
{
	public interface IAgent
	{
		// Hide the agent from the map
		bool showAgent();

		// Hide the agent from the map
		bool hideAgent();

		// get the id of this agent
		int getID();

		// set the id of this agent
		void setID(int id);

		// Move a given agent to a given Building
		bool moveAgent(Building origin, Building dest);

		// Move a given agent to a given Building
		void moveAgent(Transform origin, Transform dest);

	}
}