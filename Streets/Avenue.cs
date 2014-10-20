using CityFuture.Streets.Enums;
using UnityEngine;

namespace CityFuture.Streets
{
	public class Avenue : Street
	{
		// Add building Component to the gameObject
		public static Avenue CreateComponent (GameObject where,
		                                              StreetDirection parameter1)
		{
			Avenue myC = where.AddComponent<Avenue>();
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