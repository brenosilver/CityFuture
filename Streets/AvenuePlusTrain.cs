using CityFuture.Streets.Enums;
using UnityEngine;

namespace CityFuture.Streets
{
	public class AvenuePlusTrain : Street
	{
		// Add building Component to the gameObject
		public static AvenuePlusTrain CreateComponent (GameObject where,
		                                           StreetDirection parameter1)
		{
			AvenuePlusTrain myC = where.AddComponent<AvenuePlusTrain>();
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