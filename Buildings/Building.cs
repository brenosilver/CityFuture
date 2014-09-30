using UnityEngine;
using System.Collections;

namespace CityFuture.Buildings{
	public abstract class Building : MonoBehaviour
	{
		private int lotSize;
		private int occupants;
		private int happiness;
		private int income, expenses, liquid_earnings;
		private bool isEnergy, isWater;
		private int to_upgrade; // Amount left to upgrade density
		public GameObject building_obj;

		public Building(GameObject obj){
			this.lotSize = 0;
			this.occupants = 0;
			this.happiness = 10;
			this.isEnergy = false;
			this.isWater = false;
			this.income = 0;
			this.expenses = 0;
			this.liquid_earnings = 0;
			this.to_upgrade = 10;
			this.building_obj = obj;
		}

		public abstract int BuildingUpgrade();

		// Mutable Methods
		public int getTo_upgrade(){
			return this.to_upgrade;
		}
		public void setTo_upgrade(int value){
			this.to_upgrade = value;
		}

	}
}