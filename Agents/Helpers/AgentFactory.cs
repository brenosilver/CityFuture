using UnityEngine;
using System.Collections;
using CityFuture.Agents;
using CityFuture.Agents.Enums;

namespace CityFuture.Agents.Helpers
{
	public static class AgentFactory
	{

		private static Agent new_agent;
		private static GameObject prefab;
		private static GameObject agent_obj;
		
		public static Agent CreateAgent(AgentClass type_of_agent)
		{
			int[] agent_data = AgentHelper.pickAgent(type_of_agent);

			// If Kid
			if(type_of_agent == AgentClass.Kid)
			{
				// Instantiate prefab
				prefab = Resources.Load(AgentUtils.getCitizenPath(type_of_agent)) as GameObject;
				agent_obj = GameObject.Instantiate(prefab) as GameObject;

				// Add component to new agent
				new_agent = Kid.CreateComponent(agent_obj,
				                                (CitizenGender)agent_data[0],
				                                (KidVariation)agent_data[1],
				                                (CitizenTraits)agent_data[2],
				                                (KidEducation)agent_data[3]);
			}

			// If Adult
			else if(type_of_agent == AgentClass.Adult)
			{
				// Instantiate prefab
				prefab = Resources.Load(AgentUtils.getCitizenPath(type_of_agent)) as GameObject;
				agent_obj = GameObject.Instantiate(prefab) as GameObject;
				
				// Add component to new agent
				new_agent = Adult.CreateComponent(agent_obj,
				                                (CitizenGender)agent_data[0],
				                               	(AdultVariation)agent_data[1],
				                                (CitizenTraits)agent_data[2],
				                               	(AdultEducation)agent_data[3]);
			}

			// If Elder
			else if(type_of_agent == AgentClass.Elder)
			{
				// Instantiate prefab
				prefab = Resources.Load(AgentUtils.getCitizenPath(type_of_agent)) as GameObject;
				agent_obj = GameObject.Instantiate(prefab) as GameObject;
				
				// Add component to new agent
				new_agent = Elder.CreateComponent(agent_obj,
				                                  (CitizenGender)agent_data[0],
				                                  (ElderVariation)agent_data[1],
				                                  (CitizenTraits)agent_data[2],
				                                  (ElderEducation)agent_data[3]);
			}

			// If Car
			else if(type_of_agent == AgentClass.Car)
			{
				// Instantiate prefab
				prefab = Resources.Load(AgentUtils.getCarPath(agent_data[0])) as GameObject;
				agent_obj = GameObject.Instantiate(prefab) as GameObject;

				// Add component to new agent
				new_agent = Car.CreateComponent(agent_obj, (CarVariation)agent_data[1]);
			}

			// If Airplane
			else if(type_of_agent == AgentClass.Airplane)
			{
				// Instantiate prefab
				prefab = Resources.Load(AgentUtils.getAirplanePath(agent_data[0])) as GameObject;
				agent_obj = GameObject.Instantiate(prefab) as GameObject;

				// Add component to new agent
				new_agent = Airplane.CreateComponent(agent_obj, (AirplaneVariation)agent_data[1]);
			}

			// If Boat
			else if(type_of_agent == AgentClass.Boat)
			{
				// Instantiate prefab
				prefab = Resources.Load(AgentUtils.getBoatPath(agent_data[0])) as GameObject;
				agent_obj = GameObject.Instantiate(prefab) as GameObject;

				// Add component to new agent
				new_agent = Boat.CreateComponent(agent_obj, (BoatVariation)agent_data[1]);
			}

			return new_agent;
		}
	}
}
