using UnityEngine;
using System.Collections;
using CityFuture.Streets.Enums;

namespace CityFuture.Streets
{
	public abstract class Street : MonoBehaviour
	{

		private Vector3 origin, end;
		private int lanes;
		private int traffic;
		private StreetDirection street_direction;

		public void placeStreet()
		{

		}

		public abstract bool upgradeStreet();
		public abstract bool downgradeStreet();

		public StreetDirection getStreetDirection()
		{
			return this.street_direction;
		}
		public void setStreetDirection(StreetDirection direction)
		{
			this.street_direction = direction;
		}

	}
}
