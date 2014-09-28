using UnityEngine;
using System.Collections;
using CityFuture.Buildings.Helpers;
using CityFuture.Buildings.Enums;
using CityFuture.Buildings;
using CityFuture.General.Exceptions;
using System;


public class BuildingMaker : MonoBehaviour {
	//private Building building;

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

		//TODO Implement the rest of this
		if(type_of_building == BuildingClass.Residential)
			new_building = new Residential((ResidentialType)building_data[0],
			                               (ResidentialSize)building_data[1],
			                               (ResidentialVariation)building_data[2]);
		else if(type_of_building == BuildingClass.Commercial)
			new_building = new Commercial((CommercialType)building_data[0],
			                              (CommercialSize)building_data[1],
			                              (CommercialVariation)building_data[2]);
		else if(type_of_building == BuildingClass.Industrial)
			new_building = new Industrial((IndustrialType)building_data[0],
			                               (IndustrialSize)building_data[1],
			                               (IndustrialVariation)building_data[2]);
		else
			throw new NoSuchTypeException("Building Type not found");

	}


}
