using UnityEngine;
using System.Collections;

namespace CityFuture.Streets
{
	public abstract class Street : MonoBehaviour
	{

		private Vector3 origin, end;
		private int lanes;

		public void placeStreet()
		{

		}

		public abstract bool upgradeStreet();
		public abstract bool downgradeStreet();

	}
}
