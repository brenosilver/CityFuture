using UnityEngine;
using System.Collections;
using CityFuture.Buildings.Helpers;
using CityFuture.Buildings.Enums;
using CityFuture.Buildings;
using CityFuture.General.Exceptions;
using System;


public class BuildingMaker : MonoBehaviour {
	//private Building building;
	private static GameObject building_obj;
	private static GameObject prefab;
	private static string residential_path = "Prefabs/Buildings/Residential/";
	private static string commercial_path = "Prefabs/Buildings/Commercial/";
	private static string industrial_path = "Prefabs/Buildings/Industrial/";

	// Use this for initialization
	void Start () {
		createBuilding(BuildingClass.Residential);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Instantiate a new building
	public static void createBuilding(BuildingClass type_of_building)
	{
		int[] building_data = BuildingsHelper.pickBuilding(type_of_building);
		Building new_building;

		// Residential
		if(type_of_building == BuildingClass.Residential)
		{
			// Load the model and instantiate it
			prefab = Resources.Load(BuildingUtils.getResidentialPath(building_data[1])) as GameObject;
			building_obj = GameObject.Instantiate(prefab) as GameObject;

			new_building = new Residential(building_obj, (ResidentialType)building_data[0],
			                               (ResidentialSize)building_data[1],
			                               (ResidentialVariation)building_data[2]);
		}

		// Commercial
		else if(type_of_building == BuildingClass.Commercial)
		{
			prefab = Resources.Load(commercial_path + "commercial_office") as GameObject;
			building_obj = GameObject.Instantiate(prefab) as GameObject;
			new_building = new Commercial(building_obj, (CommercialType)building_data[0],
			                              (CommercialSize)building_data[1],
			                              (CommercialVariation)building_data[2]);
		}

		// Industrial
		else if(type_of_building == BuildingClass.Industrial)
		{
			prefab = Resources.Load(industrial_path + "industrial_electronics_factory") as GameObject;
			building_obj = GameObject.Instantiate(prefab) as GameObject;
			new_building = new Industrial(building_obj, (IndustrialType)building_data[0],
			                               (IndustrialSize)building_data[1],
			                               (IndustrialVariation)building_data[2]);
		}
		else
			throw new NoSuchTypeException("Building Type not found");

	}


}
