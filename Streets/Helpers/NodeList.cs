using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CityFuture.Streets.Helpers
{
	public class NodeList
	{
		public Node list;

		// Constructor
		public NodeList()
		{
			list = null;
		}

		// Add node to the end of the list
		public void add(GameObject new_node)
		{
			//Node node = new Node(newNode);
			Node node = new_node.GetComponent<Node>();
			node.node = new_node;
			Debug.Log("add");
			Node current;

			if(list == null){
				list = node;
			}
			else
			{
				current = list;
				while(current.next != null){
					current = current.next;
				}
				current.next = node;
				current.next.previous = current;
			}
		}

		// Add a break and add a node
		public void add2(GameObject new_node)
		{
			//Node node = new Node(newNode);
			Node node = new_node.GetComponent<Node>();
			node.node = new_node;
			Debug.Log("add2");
			Node current;
			
			if(list == null){
				list = node;
			}

			else
			{
				current = node;
				/*while(current.next != null){
					current = current.next;
				}
				current = node;
				current.next.previous = current;*/
			}
		}

		// Add node after break
		public void add3(GameObject new_node)
		{
			//Node node = new Node(newNode);
			Node node = new_node.GetComponent<Node>();
			node.node = new_node;
			Debug.Log("add3");
			Node current;
			
			if(list == null){
				list = node;
			}
			else
			{
				current = node;
				/*while(current.next != null){
					current = current.next;
				}*/
				current.next = node;
				current.next.previous = current;
			}
		}
		
		public void insert(GameObject index_node, GameObject new_node)
		{
			Node node = new_node.GetComponent<Node>();
			node.node = new_node;

			Node current;
			Node previous = null;
			bool done = false;
			Debug.Log("insert");
			if(isEmpty())
				list = node;

			else
			{
				current = index_node.GetComponent<Node>();
				while(!done)
				{
					 if(current.previous == null)   			// add before current
					{
						current.previous = node;
						current.previous.next = current;
						done = true;
					}
					else if (current.next == null)				// add after current
					{
						current.next = node;
						current.next.previous = current;
						done = true;
					}
					else if(current.intersectionT == null) 		// add when 3way intersection
					{
						current.intersectionT = node;
						current.intersectionT.next = current;
						done = true;
					}
					else if(current.intersectionCross == null) 	// add when 4way intersection
					{
						current.intersectionCross = node;
						current.intersectionCross.next = current;
						done = true;
					}
					else // move to previous in the list
					{
						previous = current;
						current = current.previous;
					}

				}
			}

		}

		// get the passed node
		public Node getNode(GameObject obj)
		{
			int currentId = obj.GetInstanceID();

			Node temp = list;
			while(temp != null)
			{
				if(temp.node.GetInstanceID() == currentId)
					return temp;
				temp = temp.next;
			}
			return null;
		}

		// Get next node
		public Node getNext(GameObject obj)
		{
			int currentId = obj.GetInstanceID();

			Node temp = list;
			while(temp != null)
			{
				if(temp.node.GetInstanceID() == currentId)
					if(temp.next != null)
						return temp.next;
				temp = temp.next;
			}
			return null;
		}

		// Get previous node
		public Node getPrevious(GameObject obj)
		{
			int currentId = obj.GetInstanceID();
			
			Node temp = list;
			while(temp != null)
			{
				if(temp.node.GetInstanceID() == currentId)
					if(temp.previous != null)
						return temp.previous;
				temp = temp.previous;
			}
			return null;
		}

		// delete the passed node
		public Node delete(GameObject obj)
		{
			int currentId = obj.GetInstanceID();
			
			Node current = list;
			Node previous = list;

			if(isEmpty())
				return null;

			else
			{
				while(current.node.GetInstanceID() != currentId)
				{
					if(current.next == null)
						return null;

					else
					{
						previous = current;
						current = current.next;
					}
				}
				if(current == list)
					list = list.next;
				else{
					previous.next = current.next;
				}

				return current;
			}
		}
		
		// Count number of nodes in list
		public int countIt(Node temp)
		{
			int count = 0;
			while(temp != null)
			{
				count ++;
				temp = temp.next;
			}
			return count;
		}

		public bool isEmpty()
		{
			return this.list == null;
		}

	}
}