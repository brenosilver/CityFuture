using CityFuture.Buildings;
using UnityEngine;
using CityFuture.Agents.Enums;

namespace CityFuture.Agents
{
	public class Adult : Citizen
	{
		private Employed employed;
		private AdultVariation variation;
		private CitizenTraits traits;
		private AdultEducation education;


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

		// Add Agent Component to the gameObject
		public static Adult CreateComponent (GameObject agent_obj,
		                                           CitizenGender parameter1,
		                                           AdultVariation parameter2,
		                                           CitizenTraits parameter3,
		                                           AdultEducation parameter4)
		{
			Adult myC = agent_obj.AddComponent<Adult>();
			myC.setGender(parameter1);
			myC.variation = parameter2;
			myC.traits = parameter3;
			myC.education = parameter4;
			
			return myC;
		}

	}
}