
using UnityEngine;

namespace CityFuture.Agents
{
	public class Vehicle : Agent
	{
		// Properties
		private int speed;


		#region IAgent implementation
		public override bool moveAgent (CityFuture.Buildings.Building origin, CityFuture.Buildings.Building dest)
		{
			throw new System.NotImplementedException ();
		}

		public override void moveAgent (Vector3 dest)
		{
			throw new System.NotImplementedException ();
		}

		#endregion


		#region getter/setter methods
		public int getSpeed()
		{
			return this.speed;
		}

		public void setSpeed(int speed)
		{
			this.speed = speed;
		}
		#endregion

	}
}