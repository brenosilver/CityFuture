using CityFuture.Buildings;

namespace CityFuture.Agents
{
	public class Adult : Citizen
	{
		private Employed employed;

		// Find a job
		public Employed findJob(Building workplace)
		{
			return this.employed = new Employed(this, workplace);

		}

		// Lose Job
		public void loseJob()
		{
			if(this.employed != null)
				this.employed = null;
		}

		// Check if adult is employed
		public bool isEmployed()
		{
			if(this.employed == null)
				return false;
			else
				return true;
		}

		// get employed
		public Employed getEmployed()
		{
			return this.employed;
		}
	}
}