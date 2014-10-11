using UnityEngine;
using CityFuture.General.Enums;
using CityFuture.Buildings.Enums;

namespace CityFuture.Buildings{
	public abstract class Building : MonoBehaviour
	{
		private int lotSize;
		private DensityType density;
		private int level;
		private int occupants;
		private int happiness;
		private float income, expenses, liquid_earnings, highWage, midWage, lowWage;
		private bool isEnergy, isWater;
		private int to_upgrade; // Amount left to upgrade density

		// Constructor
		public Building(){
			this.lotSize = 0;
			this.density = DensityType.Low;
			this.occupants = 0;
			this.happiness = 10;
			this.isEnergy = false;
			this.isWater = false;
			this.income = 0;
			this.expenses = 0;
			this.liquid_earnings = this.income - this.expenses;
			this.to_upgrade = 10;
		}

		public abstract int buildingUpgrade();
		public abstract int calculateLevel();


		#region Setter/Getter methods
		public int getTo_upgrade(){
			return this.to_upgrade;
		}
		public void setTo_upgrade(int value){
			this.to_upgrade = value;
		}

		// Get the wages of this building
		public float getWage(SocialStatus wageRank){
			if(wageRank == SocialStatus.LowClass)
				return this.lowWage;
			else if(wageRank == SocialStatus.MiddleClass)
				return this.midWage;
			else
				return this.highWage;
		}

		// get level
		public int getLevel()
		{
			return this.level;
		}

		// set level
		public void setLevel(int level)
		{
			this.level = level;
		}
		#endregion
	}
}