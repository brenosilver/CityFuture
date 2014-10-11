using UnityEngine;
using System.Collections;
using CityFuture.Buildings.Enums;
using CityFuture.Buildings;
using System;

namespace CityFuture.Buildings.Helpers{
	public static class BuildingsHelper
	{
		private static int residential_variations = Enum.GetNames(typeof(ResidentialVariation)).Length;
		private static int residential_types = Enum.GetNames(typeof(ResidentialType)).Length;
		private static int commercial_variations = Enum.GetNames(typeof(IndustrialVariation)).Length;
		private static int commercial_types = Enum.GetNames(typeof(IndustrialType)).Length;
		private static int industrial_variations = Enum.GetNames(typeof(IndustrialVariation)).Length;
		private static int industrial_types = Enum.GetNames(typeof(IndustrialType)).Length;

		// Randomize building type
		public static int[] pickBuilding(BuildingClass building_class)
		{
			int[] result = new int[3]; // 1st index = class, 2nd = type 3rd = variation
			System.Random rand = new System.Random();

			int building_size = 1;
			int building_variation = 1;

			// Check what type of building we want
			if(building_class == BuildingClass.Residential)
			{
				building_size = (int)ResidentialSize.Shack;
				building_variation = rand.Next(0, residential_variations)+1;
				Debug.Log(building_class + " " + (ResidentialSize)building_size + " " + 
				          (ResidentialVariation)building_variation);
			}

			else if(building_class == BuildingClass.Commercial)
			{
				building_size = (int)CommercialSize.Small;
				building_variation = rand.Next(0, commercial_variations)+1;
				Debug.Log(building_class + " " + (IndustrialSize)building_size + " " + 
				          (IndustrialVariation)building_variation);
			}

			else if(building_class == BuildingClass.Industrial)
			{
				building_size = (int)IndustrialSize.Small;
				building_variation = rand.Next(0, industrial_variations)+1;
			}

			result[0] = (int)building_class;
			result[1] = building_size;
			result[2] = building_variation;

			Debug.Log(result[0] + " " + result[1] + " " + result[2]);
			//Debug.Log((tt)building_type);
			//return (ResidentialType)house_type;
			return result;
		}

		// calculates how much the building needs to upgrade to next density
		public static int toUpgrade(Building building){
			if(building.getTo_upgrade() == 0)
				building.buildingUpgrade();
			return 10;
		}

	}
}