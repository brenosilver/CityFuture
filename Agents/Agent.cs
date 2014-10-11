using CityFuture.Agents.Enums;
using System.Collections;
using CityFuture.Buildings;
using UnityEngine;

namespace CityFuture.Agents
{
	public abstract class Agent : MonoBehaviour
	{
		// Properties
		private int id;

		// Hide the agent from the map
		public void showAgent(){ renderer.enabled = true; }

		// Hide the agent from the map
		public void hideAgent(){ renderer.enabled = false; }

		// Move a given agent to a given Building
		public abstract bool moveAgent(Building origin, Building dest);

		// Move a given agent to a given Building
		public abstract void moveAgent(Vector3 dest);

		#region setter/getter methods
		public int getID (){ return this.id; }
		public void setID (int id){ this.id = id; }
		#endregion

	}
}