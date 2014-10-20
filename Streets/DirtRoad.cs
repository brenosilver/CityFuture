using CityFuture.Streets.Enums;
using UnityEngine;

namespace CityFuture.Streets
{
	public class DirtRoad : Street
	{

		// Add building Component to the gameObject
		public static DirtRoad CreateComponent (GameObject where, StreetDirection parameter1)
		{
			DirtRoad myC = where.AddComponent<DirtRoad>();
			myC.setStreetDirection(parameter1);
			
			return myC;
		}
		
		
		#region implemented abstract members of Street
		
		public override bool upgradeStreet ()
		{
			throw new System.NotImplementedException ();
		}
		
		public override bool downgradeStreet ()
		{
			throw new System.NotImplementedException ();
		}
		
		#endregion
	}
}