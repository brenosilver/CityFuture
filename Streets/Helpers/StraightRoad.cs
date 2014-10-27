using UnityEngine;
using System.Collections;
using System;

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


		// Use this for initialization
		void Start () {
			this.terrain = FindObjectOfType<Terrain>();
			node_list = new NodeList();
			node_prefab = Resources.Load("Prefabs/Streets/Node");
			NodeParent = new GameObject("Road System") as GameObject;
		}
		
		// Update is called once per frame
		void Update () {
		
			// Mouse Button Down
			if(Input.GetMouseButtonDown(0))
			{
				//Vector3 node_start_pos;

				// hit terrain
				if(TerrainRayCast(out node_start_pos, out node_start_normal))
				{
					node_obj_origin = Instantiate(node_prefab, node_start_pos, Quaternion.Euler(Vector3.zero)) as GameObject;
					node_obj_origin.transform.parent = NodeParent.transform;
					node_list.add(node_obj_origin);

					Debug.Log ("Node Count: " + node_list.countIt(node_list.list));
				}
			}
		
			// Mouse up
			if(Input.GetMouseButtonUp(0))
			{
				//Vector3 node_end_pos;

				// hit terrain
				if(TerrainRayCast(out node_end_pos, out node_end_normal))
				{
					node_obj_end = Instantiate(node_prefab, node_end_pos, Quaternion.Euler(Vector3.zero)) as GameObject;
					node_obj_end.transform.parent = NodeParent.transform;
					node_list.add(node_obj_end);

					createRoad(node_obj_origin.transform.position, node_obj_end.transform.position);
					
					Debug.Log ("Node Count: " + node_list.countIt(node_list.list));
				}
			}
			/*if(road != null && node_obj_end != null){
				float verAngle = Quaternion.Angle(node_obj_end.transform.rotation, node_obj_end.transform.rotation);
				Quaternion nee = Quaternion.AngleAxis(verAngle, Vector3.up);
				rot = Quaternion.RotateTowards(Quaternion.identity, nee , Time.deltaTime*10);
				road.transform.rotation = rot * transform.rotation;
				Debug.Log(rot);
			}*/


				/*int speed = 5;
				Vector3 fwd = road.transform.forward;
				
				road.transform.position += fwd * speed * Time.deltaTime;
				
				RaycastHit hit;
				// instead of -Vector3.up you could use -transform.up but as hit point will jump
				// when slope changes it will give jitter. That's solvable as well by working from
				// a pivot point in bottom centre of object instead of centre (and to make sure
				// your raycast won't be too low move start pos back by a bit using again
				// transform.up as direction.
				if (Physics.Raycast(road.transform.position, -Vector3.up, out hit, 10)){
					
					if ( hit.distance > 1 ){
						//ly = road.transform.localPosition.y;
						//ly -= road.transform.localPosition.y - hit.distance-1;
					road.transform.localPosition -= new Vector3(0, hit.distance-1, 0);
					} else if ( hit.distance < 1 ){
					road.transform.localPosition += new Vector3(0, 1-hit.distance, 0);
					}
					
					Vector3 proj = fwd - (Vector3.Dot(fwd, hit.normal)) * hit.normal;
					road.transform.rotation = Quaternion.LookRotation(proj, hit.normal);
				}*/




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
		bool NodeRayCast(out Vector3 point)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			
			if(Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				if(hit.collider.transform.parent != null && hit.collider.transform.parent.tag == "Node")
				{
					point = hit.point;
					return true;
				}
			}
			point = Vector3.zero;
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



		// Create Road method
		bool createRoad(Vector3 origin, Vector3 end)
		{
			float length = Vector3.Distance(origin, end);
			float width = 5.0f;

			if(length < min_road_length)
				return false;

			road = Instantiate(Resources.Load(ROAD_PATH)) as GameObject;
			road.transform.position = origin + new Vector3(0.0f,0.1f,0.0f);

			// Rotation
			float angle = SignedAngle(Vector3.right,  end - origin);
			road.transform.Rotate(Vector3.up, angle, Space.World);

			road.transform.rotation = Quaternion.FromToRotation(Vector3.right, end - origin);
			if(node_obj_origin.transform.position.y != node_obj_end.transform.position.y)
			{
				//Vector3 rot;
				//RotationRayCast(out rot, road.transform.position, road.transform.rotation.eulerAngles);
				float vertical_angle = SignedAngle(Vector3.up, road.transform.up); // down
				Quaternion rota = Quaternion.FromToRotation(origin, Vector3.up);
				//road.transform.Rotate(road.transform.up, vertical_angle);
				//road.transform.Rotate(Vector3.right, vertical_angle);
				//road.transform.rotation = Quaternion.FromToRotation(road.transform.rotation.eulerAngles, road.transform.rotation.eulerAngles);
				Debug.DrawRay(road.transform.position, node_start_normal * 10, Color.green, 10000.0f, false);
				Debug.DrawRay(end, node_end_normal * 10, Color.green, 10000.0f, false);
				Debug.Log(vertical_angle);
			}

			// Vertices
			Vector3[] vertices = {
				new Vector3(0, 		0, -width/2),
				new Vector3(length, 0, -width/2),
				new Vector3(length, 0,  width/2),
				new Vector3(0, 		0,  width/2),
			};

			// triangles
			int[] triangles = {
				1, 0, 2,
				2, 0, 3
			};

			// UV
			Vector2[] uv = {
				new Vector2(0,		0),
				new Vector2(length, 0),
				new Vector2(length, 1),
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

		float SignedAngle(Vector3 a, Vector3 b){
			float angle = Vector3.Angle(a, b); // calculate angle
			// assume the sign of the cross product's Y component:
			return angle * Mathf.Sign(Vector3.Cross(a, b).y);
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