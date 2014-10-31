using UnityEngine;
using System.Collections;
using System;

// TODO Fix linked list order

namespace CityFuture.Streets.Helpers
{
	public class StraightRoad : MonoBehaviour
	{
		private Terrain terrain;
		private NodeList node_list;
		private UnityEngine.Object node_prefab;
		GameObject NodeParent;
		GameObject node_obj_origin, node_obj_end;

		Vector3 node_end_pos, node_start_pos, node_start_normal, node_end_normal;

		// Road creation properties
		public int min_road_length = 4;
		private const string ROAD_PATH = "Prefabs/Streets/street2lane";
		GameObject road;
		Quaternion rot;

		// Flags for saving where the collision occured
		private NodeColliderType node_origin_collider, node_end_collider;
		public enum NodeColliderType {
			OnTerrain = 1,
			OnNode = 2,
		};


		// Use this for initialization
		void Start () {
			this.terrain = FindObjectOfType<Terrain>();
			node_list = new NodeList();
			node_prefab = Resources.Load("Prefabs/Streets/Node");
			NodeParent = new GameObject("Road System") as GameObject;

			node_origin_collider = NodeColliderType.OnTerrain;
			node_end_collider = NodeColliderType.OnTerrain;
		}
		
		// Update is called once per frame
		void Update ()
		{
			// Mouse Button Down
			if(Input.GetMouseButtonDown(0))
			{
				// hit terrain
				if(TerrainRayCast(out node_start_pos, out node_start_normal))
				{
					node_obj_origin = Instantiate(node_prefab, node_start_pos, Quaternion.Euler(Vector3.zero)) as GameObject;
					node_obj_origin.transform.parent = NodeParent.transform;

					// Set last node clicked as current one
					node_obj_origin.GetComponent<NodeClick>().straightRoad = this;
					node_list.add(node_obj_origin);

					node_origin_collider = NodeColliderType.OnTerrain;
					Debug.Log ("Node Count: " + node_list.countIt(node_list.list));
				}
			}
		
			// Mouse up
			if(Input.GetMouseButtonUp(0))
			{
				if(node_obj_origin != null)
				{
					GameObject nodeHit;
					// MouseUp hit terrain
					if(TerrainRayCast(out node_end_pos, out node_end_normal))
					{
						node_obj_end = Instantiate(node_prefab, node_end_pos, Quaternion.Euler(Vector3.zero)) as GameObject;
						node_obj_end.transform.parent = NodeParent.transform;

						// Set last node clicked as current one
						node_obj_end.GetComponent<NodeClick>().straightRoad = this;
						node_end_collider = NodeColliderType.OnTerrain;

						// if road was not created delete nodes
						if(!createRoad(node_obj_origin.transform.position, node_obj_end.transform.position))
							destroyNodes();
						else
						{
							// add node to list and register road to node
							node_list.add(node_obj_end);
							//node_list.insert(node_obj_origin, node_obj_end);
							node_obj_origin.GetComponent<Node>().connected_roads.Add(this.road);
							node_obj_end.GetComponent<Node>().connected_roads.Add(this.road);
						}

						Debug.Log ("Node Count: " + node_list.countIt(node_list.list));
					}

					// MouseUp hit node
					else if(NodeRayCast(out nodeHit))
					{
						node_obj_end = nodeHit.collider.transform.parent.gameObject;
						node_end_collider = NodeColliderType.OnNode;
						if(!createRoad(node_obj_origin.transform.position, node_obj_end.transform.position))
							destroyNodes();

						else{
							// register road to node
							node_obj_origin.GetComponent<Node>().connected_roads.Add(this.road);
							node_obj_end.GetComponent<Node>().connected_roads.Add(this.road);
						}
						Debug.Log ("Node Count: " + node_list.countIt(node_list.list));
					}
				}

			}

		}


		// Collider with Terrain
		bool TerrainRayCast(out Vector3 point, out Vector3 normal)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();

			if(Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				if(hit.collider == getTerrain().collider)
				{
					point = hit.point;
					normal = hit.normal;
					return true;
				}
			}
			normal = Vector3.zero;
			point = Vector3.zero;
			return false;
		}

		// Collide with Node
		// return hit
		bool NodeRayCast(out GameObject point)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			
			if(Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				if(hit.collider.transform.parent != null && hit.collider.transform.parent.tag == "Node")
				{
					point = hit.collider.gameObject;
					return true;
				}
			}
			point = null;
			return false;
		}

		// Rotation raycast
		bool RotationRayCast(out Vector3 point, Vector3 from, Vector3 dir)
		{
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			
			//if(Physics.Raycast(from, dir, out hit, Mathf.Infinity))
			//{
				Physics.Raycast(from, dir, out hit, Mathf.Infinity);
					point = hit.point;
					return true;
			//}
			//point = Vector3.zero;
			//return false;
		}


		// Set the start node
		public void setNodeStart(GameObject node )
		{
			node_obj_origin = node;
			node_origin_collider = NodeColliderType.OnNode;
		}


		// Create Road method
		bool createRoad(Vector3 origin, Vector3 end)
		{
			float length = Vector3.Distance(origin, end);
			float width = 5.0f;

			Debug.Log("Distance: " + length);
			if(length < min_road_length)
				return false;

			road = Instantiate(Resources.Load(ROAD_PATH)) as GameObject;
			road.transform.position = origin + new Vector3(0.0f,0.1f,0.0f);

			// Rotation
			road.transform.rotation = Quaternion.LookRotation(end - origin, Vector3.up);
			//road.transform.rotation = Quaternion.FromToRotation(Vector3.forward, end - origin);

			// If roads are not in the same plane
			if(node_obj_origin.transform.position.y != node_obj_end.transform.position.y)
			{
				//road.transform.rotation = Quaternion.FromToRotation(Vector3.up, node_end_normal) * road.transform.rotation;
				//road.transform.rotation = Quaternion.LookRotation(end - origin, node_end_normal);
				//road.transform.rotation = Quaternion.LookRotation(end - origin, Vector3.up);

				Debug.DrawRay(road.transform.position, node_start_normal * 10, Color.green, 10000.0f, false);
				Debug.DrawRay(end, Vector3.up * 10, Color.red, 10000.0f, false);
				Debug.DrawRay(end , road.transform.up * 10, Color.cyan, 10000.0f, false);
				Debug.DrawRay(road.transform.position, road.transform.forward * 10, Color.green, 10000.0f, false);
			}

			// Vertices
			Vector3[] vertices = {
				new Vector3(-width/2, 0, length),
				new Vector3( width/2, 0, length),
				new Vector3(-width/2, 0,	  0),
				new Vector3( width/2, 0, 	  0),
			};

			/*	  Vertex Layout
			 *  	0 ------1
			 *      |     / |
			 *		|   /   |
			 * 		| /     |
			 * 		2 ------3
			 */

			// triangles
			int[] triangles = {
				0,1,2,
				2,1,3
			};

			// UV
			Vector2[] uv = {
				new Vector2(length,	0),
				new Vector2(length, 1),
				new Vector2(0,		0),
				new Vector2(0, 		1)
			};


			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.triangles = triangles;
			mesh.uv = uv;
			mesh.RecalculateNormals();

			MeshFilter meshFilter = road.GetComponent<MeshFilter>();
			meshFilter.mesh = mesh;

			return true;
		}

		// Destroy nodes that should not exist
		private void destroyNodes()
		{
			if(node_obj_origin != null)
			{
				if(node_origin_collider == NodeColliderType.OnTerrain && node_end_collider == NodeColliderType.OnTerrain)
				{
					node_list.delete(node_obj_origin);
					node_list.delete(node_obj_end);
					Destroy(node_obj_origin);
					Destroy(node_obj_end);
					node_obj_origin = null;
					node_obj_end = null;
				}
				else if(node_origin_collider == NodeColliderType.OnTerrain && node_end_collider == NodeColliderType.OnNode)
				{
					Debug.Log("terrain > node");
					node_list.delete(node_obj_origin);
					Destroy(node_obj_origin);
					node_obj_origin = null;
				}
				else if(node_origin_collider == NodeColliderType.OnNode && node_end_collider == NodeColliderType.OnTerrain)
				{
					node_list.delete(node_obj_end);
					Destroy(node_obj_end);
					node_obj_end = null;
				}
			}
		}



		#region Setter && getter methods

		protected Terrain getTerrain()
		{
			return this.terrain;
		}

		protected NodeList getNodeList()
		{
			return this.node_list;
		}

		#endregion

	}
}