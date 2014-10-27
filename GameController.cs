using UnityEngine;
using System.Collections;
using CityFuture.Agents.Enums;
using CityFuture.Agents.Helpers;
using CityFuture.Agents;
using CityFuture.Buildings.Helpers;
using CityFuture.Buildings.Enums;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var agent = (Citizen)AgentFactory.CreateAgent(AgentClass.Adult) ;
		agent.setAgent_name("Joe Smith");

		AgentFactory.CreateAgent(AgentClass.Adult) ;

		BuildingFactory.createBuilding(BuildingClass.Residential);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
