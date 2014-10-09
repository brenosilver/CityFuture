using UnityEngine;
using System.Collections;
using CityFuture.Agents.Enums;

namespace CityFuture.Agents
{
	public class Elder : Citizen
	{

		private ElderVariation variation;
		private CitizenTraits traits;
		private ElderEducation education;

		// Add Agent Component to the gameObject
		public static Elder CreateComponent (GameObject agent_obj,
		                                   CitizenGender parameter1,
		                                   ElderVariation parameter2,
		                                   CitizenTraits parameter3,
		                                   ElderEducation parameter4)
		{
			Elder myC = agent_obj.AddComponent<Elder>();
			myC.setGender(parameter1);
			myC.variation = parameter2;
			myC.traits = parameter3;
			myC.education = parameter4;
			
			return myC;
		}
	}
}