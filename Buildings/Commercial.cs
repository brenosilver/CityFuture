using UnityEngine;
using System.Collections;
using CityFuture.Buildings.Enums;

namespace CityFuture.Buildings{
	public class Commercial : Building
	{
		private CommercialType commercial_type;
		private CommercialSize commercial_size;
		private CommercialVariation commercial_variation;
		
		private int employees;

		// 3 argument contructor
		public Commercial (GameObject obj, CommercialType type, CommercialSize size,
		                   CommercialVariation variation) :base(obj)
		{
			this.commercial_type = type;
			this.commercial_size = size;
			this.commercial_variation = variation;
			this.employees = 0;
		}
		
		//TODO implement method
		public override int BuildingUpgrade(){
			
			throw new System.NotImplementedException ();
		}

	}
}