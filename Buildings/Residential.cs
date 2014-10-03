using UnityEngine;
using CityFuture.Buildings.Enums;
using CityFuture.Buildings.Helpers;

namespace CityFuture.Buildings{
	public class Residential : Building
	{
		private ResidentialType residential_type;
		private ResidentialSize residential_size;
		private ResidentialVariation residential_variation;
		private int kids, elders, adults;

		// Add building Component to the gameObject
		public static Residential CreateComponent (GameObject where,
		                                           ResidentialType parameter1,
		                                           ResidentialSize parameter2,
		                                           ResidentialVariation parameter3)
		{
			Residential myC = where.AddComponent<Residential>();
			myC.residential_type = parameter1;
			myC.residential_size = parameter2;
			myC.residential_variation = parameter3;

			return myC;
		}

		//TODO implement method
		public override int BuildingUpgrade()
		{
			//int maxSize = 

			throw new System.NotImplementedException ();
		}
	}
}