using CityFuture.Streets.Enums;
using UnityEngine;

namespace CityFuture.Streets
{
	public class FourLaneStreet : Street
	{
		// Add building Component to the gameObject
	public static FourLaneStreet CreateComponent (GameObject where,
		                                                 StreetDirection parameter1)
		{
		FourLaneStreet myC = where.AddComponent<FourLaneStreet>();
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