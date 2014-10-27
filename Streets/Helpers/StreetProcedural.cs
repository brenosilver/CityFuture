using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CityFuture.Streets.Helpers
{
	public class StreetProcedural : MonoBehaviour
	{
		GameObject street;
		public float length;
		public float width;
		public bool show_node;
		public int min_length;
		
		private NodeColliderType nodeColStart, nodeColEnd;
		public enum NodeColliderType {
			OnTerrain = 1,
			OnNode = 2,
		};
		
		Terrain terrain;
		string street_path = "Prefabs/Streets/street2lane";
		string node_path = "Prefabs/Streets/Node";
		
		//Vector3 street_start;
		GameObject node_start;
		GameObject node_end;
		GameObject prefab_node;
		
		
		// Start method
		void Start()
		{
			terrain = FindObjectOfType<Terrain>();
			show_node = true;
			width = 4;
			min_length = 5;
			nodeColStart = NodeColliderType.OnTerrain;
			nodeColEnd = NodeColliderType.OnTerrain;
		}
		
		// update
		void Update()
		{
			
			// On mouse button down
			if(Input.GetMouseButtonDown(0))
			{
				prefab_node = Resources.Load(node_path) as GameObject; // load node prefab
				
				// defines the start of the street and node
				Vector3 street_start;
				// If we hit something
				if(clickLocation(out street_start))
				{
					node_start = Instantiate(prefab_node, street_start, Quaternion.identity) as GameObject;
					// Set last node as current one
					node_start.GetComponent<NodeClick>().ground = this;
					nodeColStart = NodeColliderType.OnTerrain;
				}
			}
			
			// On Mouse Button up
			if(Input.GetMouseButtonUp(0))
			{
				// defines the end of the street and node
				Vector3 street_end;
				// If mouse up location is on terrain
				if (node_start != null && clickLocation(out street_end))
				{
					node_end = Instantiate(prefab_node, street_end, Quaternion.identity) as GameObject;
					// Set last node as current one
					node_end.GetComponent<NodeClick>().ground = this;
					
					nodeColEnd = NodeColliderType.OnTerrain;
					
					// if street wasnt created
					if(!createStreet(node_start.transform.position, node_end.transform.position)){
						destroyNodes();
					}
					
				}
				// else if mouse up location is on node
				else if(node_start != null && clickLocationNode(out street_end))
				{
					if(!createStreet(node_start.transform.position, street_end)){
						destroyNodes();
					}
				}
				
				showNode(); // Inspector mode only
				node_start = null;
			}
		}
		
		// Set the start node
		public void setNodeStart(GameObject node )
		{
			node_start = node;
			nodeColStart = NodeColliderType.OnNode;
		}
		
		// Set the end node
		public void setNodeEnd(GameObject node )
		{
			createStreet(node_start.transform.position, node.transform.position);
			node_start = null;
		}
		
		// Click Location
		// Checks collision on terrain only
		bool clickLocation(out Vector3 point)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo = new RaycastHit();
			
			if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
			{
				if(hitInfo.collider == terrain.collider)
				{
					point = hitInfo.point;
					return true;
				}
			}
			point = Vector3.zero;
			return false;
		}
		
		// Click Location
		// Checks collision on nodes only
		bool clickLocationNode(out Vector3 point)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo = new RaycastHit();
			
			if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
			{
				if(hitInfo.collider.transform.parent != null && hitInfo.collider.transform.parent.tag == "Node")
				{
					point = hitInfo.collider.transform.position;
					nodeColEnd = NodeColliderType.OnNode;
					return true;
				}
			}
			point = Vector3.zero;
			return false;
		}
		
		// Draw Street method
		// return true if created, and false if not
		bool createStreet(Vector3 origin, Vector3 end)
		{
			// Length of the street
			length = Vector3.Distance(origin, end);
			
			// if length is less than min length stop creation
			if(length < min_length)
				return false;
			
			street = Instantiate(Resources.Load(street_path)) as GameObject;
			street.transform.position = origin + new Vector3(0.0f,0.1f,0.0f);

			// Rotate the street to the correct mouse direction
			street.transform.rotation = Quaternion.FromToRotation(Vector3.right, end - origin);

			// Fix unwanted rotation on x/z
			// if nodes are in the same plane
			if(node_start.transform.position.y == node_end.transform.position.y){
				street.transform.eulerAngles = new Vector3(0.0f,street.transform.eulerAngles.y,0.0f);
				Debug.Log("Same Plane");
			}
			else{
			//	street.transform.rotation = Quaternion.FromToRotation(origin+ upShift, end - origin);

				float angle = Vector3.Angle(street.transform.rotation.eulerAngles, Vector3.up);
				angle = 90.0f - angle;


				street.transform.Rotate(Vector3.left, angle);
				Debug.Log("-----------");
				Debug.Log("street Rot: " + street.transform.rotation.eulerAngles);
				Vector3 newRot = street.transform.rotation.eulerAngles;
				float newangle = 0.0f;
				if(newRot.x > 0.0f && newRot.x <= 45.0f){
					newangle = newRot.x;
					street.transform.Rotate(Vector3.left, newangle);
				}
				else if(newRot.x <= 360.0f && newRot.x > 45.0f){
					newangle = 360.0f - newRot.x;
					street.transform.Rotate(Vector3.right, newangle);
				}

			//	street.transform.Rotate(Vector3.right, newangle);

				//street.transform.rotation = Quaternion.FromToRotation(Vector3.right, end - origin);

				Debug.Log("Angle: " + angle);
				Debug.Log("street Rot: " + street.transform.rotation.eulerAngles);
				Debug.Log("newangle: " + newangle);

			}

			//Debug.Log ("up: "+up);
			//Debug.Log ("rotation quaternion: "+street.transform.rotation);

			// vertices
			Vector3[] vertices = {
				new Vector3(0, 		0,	-width/2),
				new Vector3(length, 0,	-width/2),
				new Vector3(length, 0,	 width/2),
				new Vector3(0, 		0,	 width/2)
			};

			// triangles
			int[] triangles = {
				1, 0, 2,
				2, 0, 3
			};

			// UV
			Vector2[] uv = {
				new Vector2(0, 0),
				new Vector2(length, 0),
				new Vector2(length, 1),
				new Vector2(0, 1)
			};

			// normals
			Vector3[] normals = {
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up
			};

			Mesh mesh = new Mesh();

			mesh.vertices = vertices;
			mesh.triangles = triangles;
			mesh.uv = uv;
			mesh.normals = normals;

			MeshFilter mesh_filter = street.GetComponent<MeshFilter>();
			mesh_filter.mesh = mesh;

			return true;
		}

		void destroyNodes()
		{
			if(node_start != null)
			{
				if(nodeColStart == NodeColliderType.OnTerrain && nodeColEnd == NodeColliderType.OnTerrain)
				{
					Destroy(node_start);
					Destroy(node_end);
					node_start = null;
					node_end = null;
				}
				else if(nodeColStart == NodeColliderType.OnTerrain && nodeColEnd == NodeColliderType.OnNode)
				{
					Destroy(node_start);
					node_start = null;
				}
				else if(nodeColStart == NodeColliderType.OnNode && nodeColEnd == NodeColliderType.OnTerrain)
				{
					Destroy(node_end);
					node_end = null;
				}
			}
		}

		void showNode()
		{

		}

		float quaternionMagnitude(Quaternion q)
		{
			return Mathf.Sqrt(Mathf.Pow(q.w,2) + Mathf.Pow(q.x,2) + Mathf.Pow(q.y,2) + Mathf.Pow(q.z,2));
		}
		Quaternion normalizeQuaternion(Quaternion q)
		{
			float magnitude = quaternionMagnitude(q);
			Quaternion newQ = new Quaternion();
			newQ.w = q.w / magnitude;
			newQ.x = q.x / magnitude;
			newQ.y = q.y / magnitude;
			newQ.z = q.z / magnitude;

			return newQ;
		}
	}
}