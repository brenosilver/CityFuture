
namespace CityFuture.Agents
{
	public class Vehicle : Agent
	{
		private int id;
		private int speed;


		#region IAgent implementation

		public override bool showAgent ()
		{
			throw new System.NotImplementedException ();
		}

		public override bool hideAgent ()
		{
			throw new System.NotImplementedException ();
		}

		public override int getID ()
		{
			return this.id;
		}

		public override void setID (int id)
		{
			this.id = id;
		}

		public override bool moveAgent (CityFuture.Buildings.Building origin, CityFuture.Buildings.Building dest)
		{
			throw new System.NotImplementedException ();
		}

		public override void moveAgent (UnityEngine.Transform origin, UnityEngine.Transform dest)
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