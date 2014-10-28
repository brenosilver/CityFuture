using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CityFuture.Streets.Helpers
{
	public class Node : MonoBehaviour
	{

		public Node previous;
		public GameObject road;
		public Node next;
		public List<GameObject> roads;

		public Node(GameObject road)
		{
			roads = new List<GameObject>();
			this.road = road;
			this.previous = null;
			this.next = null;
		}
	}
}