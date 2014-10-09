using CityFuture.Agents.Enums;
using System;

namespace CityFuture.Agents.Helpers
{
	public static class AgentHelper 
	{
		// Agents number of variations
		private static int kid_variations = Enum.GetNames(typeof(AdultVariation)).Length;
		private static int adult_variations = Enum.GetNames(typeof(AdultVariation)).Length;
		private static int elder_variations = Enum.GetNames(typeof(AdultVariation)).Length;
		private static int car_variations = Enum.GetNames(typeof(CarVariation)).Length;
		private static int airplane_variations = Enum.GetNames(typeof(AirplaneVariation)).Length;
		private static int boat_variations = Enum.GetNames(typeof(BoatVariation)).Length;

		// Citizen Education
		private static int kid_educations = Enum.GetNames(typeof(KidEducation)).Length;
		private static int adult_educations = Enum.GetNames(typeof(AdultEducation)).Length;
		private static int elder_educations = Enum.GetNames(typeof(ElderEducation)).Length;

		// Citizen Traits
		private static int citizen_traits = Enum.GetNames(typeof(CitizenTraits)).Length;

		// Citizen Sex
		private static int citizen_genders = Enum.GetNames(typeof(CitizenGender)).Length;

		// Vehicle Types
		private static int car_types = Enum.GetNames(typeof(CarType)).Length;
		private static int airplane_types = Enum.GetNames(typeof(AirplaneType)).Length;
		private static int boat_types = Enum.GetNames(typeof(BoatType)).Length;


		// Randozime Agent Creation Method
		public static int[] pickAgent(AgentClass agent_class)
		{
			int[] result;
			Random rand = new Random();

			int agent_variation = 1;
			int citizen_education = 1;
			int citizen_trait = 1;
			int citizen_gender = 1;
			int vehicle_type = 1;

			//If Kid
			if(agent_class == AgentClass.Kid)
			{
				citizen_gender = rand.Next(0, citizen_genders)+1;
				agent_variation = rand.Next(0, kid_variations)+1;
				citizen_trait = rand.Next(0, citizen_traits)+1;

				// Default Education
				citizen_education = (int)KidEducation.Uneducated;
			}

			//If Adult
			else if(agent_class == AgentClass.Adult)
			{
				citizen_gender = rand.Next(0, citizen_genders)+1;
				agent_variation = rand.Next(0, adult_variations)+1;
				citizen_trait = rand.Next(0, citizen_traits)+1;

				// Default Education
				citizen_education = (int)AdultEducation.Uneducated;
			}

			//If Elder
			else if(agent_class == AgentClass.Elder)
			{
				citizen_gender = rand.Next(0, citizen_genders)+1;
				agent_variation = rand.Next(0, elder_variations)+1;
				citizen_trait = rand.Next(0, citizen_traits)+1;
				
				// Default Education
				citizen_education = (int)ElderEducation.Uneducated;
			}

			//If Car
			else if(agent_class == AgentClass.Car)
			{
				vehicle_type = rand.Next(0, car_types)+1;
				agent_variation = rand.Next(0, car_variations)+1;
			}

			//If Airplane
			else if(agent_class == AgentClass.Airplane)
			{
				vehicle_type = rand.Next(0, airplane_types)+1;
				agent_variation = rand.Next(0, airplane_variations)+1;
			}

			//If Boat
			else if(agent_class == AgentClass.Boat)
			{
				vehicle_type = rand.Next(0, boat_types)+1;
				agent_variation = rand.Next(0, boat_variations)+1;
			}

			// if vehicle
			if(agent_class == AgentClass.Car || agent_class == AgentClass.Airplane || agent_class == AgentClass.Boat)
			{
				result = new int[2];
				result[0] = vehicle_type;
				result[1] = agent_variation;
			}
			else
			{
				result = new int[4];
				result[0] = citizen_gender;
				result[1] = agent_variation;
				result[2] = citizen_trait;
				result[3] = citizen_education;
			}

			return result;
		}

	}
}