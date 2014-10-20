using CityFuture.Streets.Enums;
using UnityEngine;

namespace CityFuture.Streets
{
	public class Ramp : Street
	{
		// Add building Component to the gameObject
		public static Ramp CreateComponent (GameObject where,
		                                       StreetDirection parameter1)
		{
			Ramp myC = where.AddComponent<Ramp>();
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