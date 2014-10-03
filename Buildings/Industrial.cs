using UnityEngine;
using System.Collections;
using CityFuture.Buildings.Enums;
using CityFuture.Buildings.Helpers;

namespace CityFuture.Buildings{
	public class Industrial : Building
	{
		private IndustrialType industrial_type;
		private IndustrialSize industrial_size;
		private IndustrialVariation industrial_variation;
		private int employees;

		// Add building Component to the gameObject
		public static Industrial CreateComponent(GameObject where,
		                                         IndustrialType parameter1,
		                                         IndustrialSize parameter2,
		                                         IndustrialVariation parameter3)
		{
			Industrial myC = where.AddComponent<Industrial>();
			myC.industrial_type = parameter1;
			myC.industrial_size = parameter2;
			myC.industrial_variation = parameter3;

			return myC;
		}

		public override int BuildingUpgrade()
		{
			throw new System.NotImplementedException ();
		}



	}
}