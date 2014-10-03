using CityFuture.Buildings;

namespace CityFuture.Agents
{
	public class Employed
	{
		private Adult employed;
		private Building workplace;
		private float salary;

		// 2 argument constructor
		public Employed (Adult employed, Building workplace)
		{
			this.employed = employed;
			this.workplace = workplace;
		}

		public void setSalary()
		{
			this.salary = this.workplace.getWage(employed.getSocialStatus());
		}

		public float getSalary()
		{
			return this.salary;
		}
		
	}
}