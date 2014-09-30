using UnityEngine;
using System.Collections;
using CityFuture.Buildings.Enums;

namespace CityFuture.Buildings{
	public class Residential : Building
	{
		private ResidentialType residential_type;
		private ResidentialSize residential_size;
		private ResidentialVariation residential_variation;

		private int kids, elders, adults;

		// 3 argument constructor
		public Residential (GameObject obj, ResidentialType type, ResidentialSize size,
		                    ResidentialVariation variation) :base(obj)
		{
			this.residential_type = type;
			this.residential_size = size;
			this.residential_variation = variation;
			this.kids = 0;
			this.elders = 0;
			this.adults = 0;
		}

		//TODO implement method
		public override int BuildingUpgrade()
		{
			//int maxSize = 

			throw new System.NotImplementedException ();
		}
	}
}