using CityFuture.Buildings;
using UnityEngine;
using CityFuture.Agents.Enums;

namespace CityFuture.Agents
{
	public class Kid : Citizen
	{
		private Student student;
		private KidVariation variation;
		private CitizenTraits traits;
		private KidEducation education;

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

		// Add Agent Component to the gameObject
		public static Kid CreateComponent (GameObject agent_obj,
		                                     CitizenGender parameter1,
		                                     KidVariation parameter2,
		                                     CitizenTraits parameter3,
		                                     KidEducation parameter4)
		{
			Kid myC = agent_obj.AddComponent<Kid>();
			myC.setGender(parameter1);
			myC.variation = parameter2;
			myC.traits = parameter3;
			myC.education = parameter4;
			
			return myC;
		}
	
	}
}