using UnityEngine;
using System.Collections;

namespace CityFuture.Streets.Helpers
{
	public class NodeClick : MonoBehaviour {

		public CurvedRoad ground2;
		public StraightRoad road;

		// On Mouse Down
		void OnMouseDown()
		{
			road.setNodeStart(gameObject);
		}
	}
}