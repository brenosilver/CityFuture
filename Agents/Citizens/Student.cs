using CityFuture.Buildings;

namespace CityFuture.Agents
{
	public class Student
	{
		private Kid student;
		private Building school;

		// 2 argument constructor
		public Student(Kid student, Building school)
		{
			this.student = student;
			this.school = school;
		}
	}
}