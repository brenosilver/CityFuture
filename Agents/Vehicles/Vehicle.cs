
namespace CityFuture.Agents
{
	public class Vehicle : IAgent
	{
		private int id;
		private int speed;


		#region IAgent implementation

		public bool showAgent ()
		{
			throw new System.NotImplementedException ();
		}

		public bool hideAgent ()
		{
			throw new System.NotImplementedException ();
		}

		public int getID ()
		{
			return this.id;
		}

		public void setID (int id)
		{
			this.id = id;
		}

		public bool moveAgent (CityFuture.Buildings.Building origin, CityFuture.Buildings.Building dest)
		{
			throw new System.NotImplementedException ();
		}

		public void moveAgent (UnityEngine.Transform origin, UnityEngine.Transform dest)
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