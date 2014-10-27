using UnityEngine;
using System.Collections;

namespace CityFuture.Streets.Helpers
{
	public class Node
	{

		public Node previous;
		public GameObject node;
		public Node next;
		public int info;

		public Node(GameObject node)
		{
			this.node = node;
			this.previous = null;
			this.next = null;
		}
	}
}