using UnityEngine;
using System.Collections;
using CityFuture.Buildings.Enums;
using CityFuture.Buildings;
using CityFuture.General.Exceptions;
using System;

namespace CityFuture.Buildings.Helpers
{
	public static class BuildingFactory
	{
		private static Building new_building;
		private static GameObject prefab;
		private static GameObject building_obj;


		// Instantiate a new building
		public static void createBuilding(BuildingClass type_of_building)
		{
			int[] building_data = BuildingsHelper.pickBuilding(type_of_building);

			// Residential
			if(type_of_building == BuildingClass.Residential)
			{
				prefab = Resources.Load(BuildingUtils.getResidentialPath(building_data[1])) as GameObject;
				building_obj = GameObject.Instantiate(prefab) as GameObject;

				new_building = Residential.CreateComponent(building_obj,
				                                           (ResidentialType)building_data[0],
				                                           (ResidentialSize)building_data[1],
				                                           (ResidentialVariation)building_data[2]);
			}

			// Commercial
			else if(type_of_building == BuildingClass.Commercial)
			{
				prefab = Resources.Load(BuildingUtils.getCommercialPath(building_data[1])) as GameObject;
				building_obj = GameObject.Instantiate(prefab) as GameObject;

				new_building = Commercial.CreateComponent(building_obj,
				                                          (CommercialType)building_data[0],
				                                          (CommercialSize)building_data[1],
				                                          (CommercialVariation)building_data[2]);
			}

			// Industrial
			else if(type_of_building == BuildingClass.Industrial)
			{
				prefab = Resources.Load(BuildingUtils.getIndustrialPath(building_data[1])) as GameObject;
				building_obj = GameObject.Instantiate(prefab) as GameObject;

				new_building = Industrial.CreateComponent(building_obj,
				                                          (IndustrialType)building_data[0],
				                                          (IndustrialSize)building_data[1],
				                                          (IndustrialVariation)building_data[2]);
			}
			else
				throw new NoSuchTypeException("Building Type not found");

		}
		

	}
}