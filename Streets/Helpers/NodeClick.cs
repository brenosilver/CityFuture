using UnityEngine;
using System.Collections;

namespace CityFuture.Streets.Helpers
{
	public class NodeClick : MonoBehaviour {

		public CurvedRoad curvedRoad;
		public StraightRoad straightRoad;

		// On Mouse Down
		void OnMouseDown()
		{
			straightRoad.setNodeStart(gameObject);
		}

	}
}