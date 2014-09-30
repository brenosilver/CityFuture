using UnityEngine;
using System.Collections;
using CityFuture.Buildings.Helpers;
using CityFuture.Buildings.Enums;
using CityFuture.Buildings;
using CityFuture.General.Exceptions;
using System;


public class BuildingMaker : MonoBehaviour
{
	private Building new_building;
	private GameObject prefab;
	private GameObject building_obj;

	// Use this for initialization
	void Start () {
		createBuilding(BuildingClass.Residential);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Instantiate a new building
	public void createBuilding(BuildingClass type_of_building)
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
