using CityFuture.Streets.Enums;
using UnityEngine;

namespace CityFuture.Streets
{
	public class Freeway : Street
	{
		// Add building Component to the gameObject
		public static Freeway CreateComponent (GameObject where,
		                                       StreetDirection parameter1)
		{
			Freeway myC = where.AddComponent<Freeway>();
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