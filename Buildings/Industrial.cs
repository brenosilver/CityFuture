using UnityEngine;
using System.Collections;
using CityFuture.Buildings.Enums;

namespace CityFuture.Buildings{
	public class Industrial : Building
	{
		private IndustrialType industrial_type;
		private IndustrialSize industrial_size;
		private IndustrialVariation industrial_variation;
		
		private int employees;
		
		// 3 argument contructor
		public Industrial (GameObject obj, IndustrialType type, IndustrialSize size,
		                   IndustrialVariation variation) :base(obj)
		{
			this.industrial_type = type;
			this.industrial_size = size;
			this.industrial_variation = variation;
			this.employees = 0;
		}

		public override int BuildingUpgrade()
		{
			throw new System.NotImplementedException ();
		}



	}
}