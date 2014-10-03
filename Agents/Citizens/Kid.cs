using CityFuture.Buildings;

namespace CityFuture.Agents
{
	public class Kid : Citizen
	{
		private Student student;

		// Make this kid a student
		public Student turnStudent(Building school)
		{
			return this.student = new Student(this, school);
		}

		// make kid not a student
		public void unTurnStudent()
		{
			if(this.student != null)
				this.student = null;
		}

		// check if is a student
		public bool isStudent()
		{
			if(this.student == null)
				return false;
			else
				return true;
		}

		// get student
		public Student getStudent()
		{
			return this.student;
		}
	
	}
}