using UnityEngine;
using System.Collections;
using CityFuture.Buildings.Enums;
using CityFuture.Buildings.Helpers;

namespace CityFuture.Buildings{
	public class Commercial : Building
	{
		private CommercialType commercial_type;
		private CommercialSize commercial_size;
		private CommercialVariation commercial_variation;
		private int employees;

		// Add building Component to the gameObject
		public static Commercial CreateComponent(GameObject where,
		                                         CommercialType parameter1,
		                                         CommercialSize parameter2,
		                                         CommercialVariation parameter3)
		{
			Commercial myC = where.AddComponent<Commercial>();
			myC.commercial_type = parameter1;
			myC.commercial_size = parameter2;
			myC.commercial_variation = parameter3;

			return myC;
		}

		#region implemented abstract members of Building
		//TODO implement method
		public override int buildingUpgrade(){
			
			throw new System.NotImplementedException ();
		}
		
		public override int calculateLevel ()
		{
			throw new System.NotImplementedException ();
		}
		#endregion
	}
}