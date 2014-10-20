using CityFuture.Streets.Enums;
using UnityEngine;

namespace CityFuture.Streets
{
	public class DenseAvenue : Street
	{
		// Add building Component to the gameObject
		public static DenseAvenue CreateComponent (GameObject where,
		                                      StreetDirection parameter1)
		{
			DenseAvenue myC = where.AddComponent<DenseAvenue>();
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