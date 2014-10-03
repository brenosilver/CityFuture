using CityFuture.Buildings.Enums;
using UnityEngine;

namespace CityFuture.Buildings
{
	public class Park : Building
	{
		private ParkType park_type;
		private ParkSize park_size;
		private ParkVariation park_variation;
		private int visitants; // Not base "occupants" which are homeless

		// Add building Component to the gameObject
		public static Park CreateComponent (GameObject where,
		                                           ParkType parameter1,
		                                           ParkSize parameter2,
		                                           ParkVariation parameter3)
		{
			Park myC = where.AddComponent<Park>();
			myC.park_type = parameter1;
			myC.park_size = parameter2;
			myC.park_variation = parameter3;
			
			return myC;
		}


		#region implemented abstract members of Building
		public override int BuildingUpgrade ()
		{
			throw new System.NotImplementedException ();
		}
		#endregion

	}
}