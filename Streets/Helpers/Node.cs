using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CityFuture.Streets.Helpers
{
	public class Node : MonoBehaviour
	{

		public Node previous;
		public GameObject node;
		public Node next;
		public Node intersectionT;
		public Node intersectionCross;
		public List<GameObject> connected_roads;

		public Node(GameObject node)
		{
			connected_roads = new List<GameObject>();
			this.node = node;
			this.previous = null;
			this.next = null;
		}
	}
}