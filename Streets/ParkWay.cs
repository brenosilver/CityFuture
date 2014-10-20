using CityFuture.Streets.Enums;
using UnityEngine;

namespace CityFuture.Streets
{
	public class ParkWay : Street
	{
		// Add building Component to the gameObject
		public static ParkWay CreateComponent (GameObject where,
		                                           StreetDirection parameter1)
		{
			ParkWay myC = where.AddComponent<ParkWay>();
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