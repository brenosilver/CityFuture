//Created by Neodrop
//neodrop@unity3d.ru
using System.Collections.Generic;
using UnityEngine;
//#pragma warning disable

namespace CityFuture.Streets.Helpers
{
	public class CurvedRoad : MonoBehaviour
	{
	    public GameObject road;
	    public bool generateUv2 = true;
	    public int raycastLayer = 0;
	    public Material roadMaterial;
	    public float roadWidth = 6f;
	    public float roadUnderWidth = 12;
	    public float scaleU = 1f, scaleV = 1f, yShift = .1f;

	    //protected AntaresBezierController bc = null;
	    protected Vector3[] wayPoints;
	    protected Transform marker, markerLeft, markerRight;
	    protected Quaternion currentRotation;



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





	    void Awake()
	    {
	      /*  MeshFilter mf = road.GetComponent<MeshFilter>();
	        if (mf == null)
	        {
	            CreateRoad();
	            return;
	        }
	        if (mf.mesh == null)
	        {
	            Destroy(road.GetComponent<MeshRenderer>());
	            Destroy(mf);
	            CreateRoad();
	        }*/


			terrain = FindObjectOfType<Terrain>();
			show_node = true;
			width = 1;
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
					node_start.GetComponent<NodeClick>().ground2 = this;
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
					node_end.GetComponent<NodeClick>().ground2 = this;
					
					nodeColEnd = NodeColliderType.OnTerrain;
					
					// if street wasnt created
					CreateRoad();

					
				}
				// else if mouse up location is on node
				else if(node_start != null && clickLocationNode(out street_end))
				{
					CreateRoad();

				}

				node_start = null;
			}

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

	  /*  public void InitFromEditor()
	    {
	        AntaresBezierController bc = gameObject.GetComponent<AntaresBezierController>();
	        if (bc)
	        {
	            wayPoints = bc.wayPoints;
	            return;
	        }
	        AntaresBezierCurve c3 = gameObject.GetComponent<AntaresBezierCurve>();
	        if (c3)
	        {
	            wayPoints = c3.GetCurvePoints();
	        }
	    }*/

	    public void CreateRoad()
	    {
	        /*if (road == null || road.renderer) return;
	        InitFromEditor();
	        if (wayPoints == null || wayPoints.Length < 2)
	        {
	            Debug.Log("No Way points!");
	            return;
	        }*/
	        MeshFilter mf = road.AddComponent<MeshFilter>();
	        MeshRenderer mr = road.AddComponent<MeshRenderer>();
	        Mesh myMesh = new Mesh();
	        int count = wayPoints.Length;
	        int vertCount = (count - 1) * 6;
	        Color[] colors = new Color[vertCount];
	        for (int i = 0; i < vertCount; i++) colors[i] = Color.white;
	        myMesh.vertices = new Vector3[vertCount];
	        myMesh.triangles = new int[vertCount * 2];
	        myMesh.tangents = new Vector4[myMesh.vertices.Length];
	        Vector4[] tangents = new Vector4[myMesh.tangents.Length];
	        int[] triangles = new int[myMesh.triangles.Length];
	        Vector3[] vertices = new Vector3[vertCount];
	        myMesh.uv = new Vector2[vertCount];
	        Vector2[] uv = new Vector2[vertCount];

	        if (marker == null)
	        {
	            marker = new GameObject("Road Points Marker").transform;
	            markerLeft = new GameObject("Road Points Marker Left").transform;
	            markerLeft.position = Vector3.left * (roadWidth * .5f);
	            markerRight = new GameObject("Road Points Marker Right").transform;
	            markerRight.position = Vector3.right * (roadWidth * .5f);
	            markerLeft.parent = markerRight.parent = marker;
	            marker.parent = road.transform;
	            marker.position = wayPoints[0];
	            marker.LookAt(wayPoints[1]);
	        }

	        int vindex = 0, tindex = 0;
	        bool closed = false;
			float texVSum = 0f;
			
			
			
	        //AntaresBezierCurve abc = gameObject.GetComponent<AntaresBezierCurve>();
	       // if (abc != null && abc.IsClosed) closed = true;


	        marker.position = wayPoints[0];
	        marker.LookAt(wayPoints[1]);

	        vertices[vindex] = RayCast(markerLeft);
	        uv[vindex] = new Vector2(texVSum, 0);
	            
	        vindex++;
	            
	        vertices[vindex] = RayCast(markerRight);
	        uv[vindex] = new Vector2(texVSum, scaleU);

	        vindex++;
	        texVSum=texVSum+scaleV;
	        
	        for (int i = 1; i < count; i++)
	        {

	            marker.position = wayPoints[i];
	            currentRotation = marker.rotation;
	            if (i < count - 1)
	            {
	                marker.LookAt(wayPoints[i]);
	                marker.rotation = Quaternion.Lerp(currentRotation, marker.rotation, .5f);
	            }
	            else if (closed)
	            {
	                marker.LookAt(wayPoints[1]);
	            }

	            vertices[vindex] = RayCast(markerLeft);
	            uv[vindex] = new Vector2(texVSum, 0);
				vindex++;

	            vertices[vindex] = RayCast(markerRight);
	            uv[vindex] = new Vector2(texVSum, scaleU);
	            vindex++;

	            triangles[tindex++] = vindex - 4;
	            triangles[tindex++] = vindex - 3;
	            triangles[tindex++] = vindex - 2;

	            triangles[tindex++] = vindex - 3;
	            triangles[tindex++] = vindex - 1;
	            triangles[tindex++] = vindex - 2;

	            //tangents[vindex - 4] = tangents[vindex - 3] = tangents[vindex - 2] = ComputeTangentBasis(vertices[vindex - 4], vertices[vindex - 3], vertices[vindex - 2]);
	            //tangents[vindex - 1] = tangents[vindex - 2] = tangents[vindex - 3] = ComputeTangentBasis(vertices[vindex - 1], vertices[vindex - 2], vertices[vindex - 3]);
				
				texVSum=texVSum+scaleV;
	        }

	        myMesh.vertices = vertices;
	        myMesh.uv = uv;
	        myMesh.triangles = triangles;
	        myMesh.tangents = tangents;
	        myMesh.colors = colors;

	        mf.sharedMesh = myMesh;
	        mf.sharedMesh.RecalculateNormals();
	        mf.sharedMesh.RecalculateBounds();
	        mf.sharedMesh.name = road.name + "_mesh";
	        mr.material = roadMaterial;
	        road.renderer.castShadows = false;
	        ReverseNormals(mf.sharedMesh);
	        road.transform.localPosition = transform.position * (-1f) + Vector3.up * yShift;
	        DestroyImmediate(marker);
	        RoadFinalize();
	    }

	    private void RoadFinalize()
	    {
	        road.isStatic = true;
	        Mesh mesh = road.GetComponent<MeshFilter>().sharedMesh;
	        if (gameObject.GetComponent<CurvedRoad>().generateUv2 && mesh)
	        {
	            Vector2[] uv2 = mesh.uv;
	            int count = mesh.vertices.Length;
	            float minX = float.MaxValue, minZ = float.MaxValue, maxX = float.MinValue, maxZ = float.MinValue;
	            for (int i = 0; i < count; i++)
	            {
	                Vector3 pos = mesh.vertices[i];
	                if (pos.x < minX)
	                    minX = pos.x;
	                else if (pos.x > maxX)
	                    maxX = pos.x;
	                if (pos.z > maxZ)
	                    maxZ = pos.z;
	                else if (pos.z < minZ)
	                    minZ = pos.z;
	            }

	            float X = Vector3.Distance(new Vector3(minX, 0, minZ), new Vector3(maxX, 0, minZ));
	            float Z = Vector3.Distance(new Vector3(minX, 0, minZ), new Vector3(minX, 0, maxZ));

	            float toZeroX = minX < 0 ? Mathf.Abs(minX) : 0;
	            float toZeroZ = minZ < 0 ? Mathf.Abs(minZ) : 0;

	            for (int i = 0; i < count; i++)
	            {
	                Vector3 pos = mesh.vertices[i];
	                pos.x += toZeroX;
	                pos.z += toZeroZ;
	                uv2[i] = new Vector2(pos.x / X, pos.z / Z);
	            }
	            mesh.uv2 = uv2;

	            road.GetComponent<MeshFilter>().sharedMesh = mesh;
	        }
	    }

	    Vector4 ComputeTangentBasis(Vector3 v0, Vector3 v1, Vector3 v2)
	    {
	        Vector2 e0uv = v1 - v0;
	        Vector2 e1uv = v2 - v0;
	        Vector4 tangent = new Vector4();

	        float cp = e0uv.y * e1uv.x - e0uv.x * e1uv.y;

	        if (cp != 0.0f)
	        {
	            float k = 1.0f / cp;
	            tangent = ((v1 - v0) * -e1uv.y + (v2 - v0) * e0uv.y) * k;

	            tangent.Normalize();
	        }
	        return tangent;
	    }

	    public static void ReverseNormals(Mesh mesh)
	    {
	        Vector3[] normals = mesh.normals;
	        int l = normals.Length;
	        for (int k = 0; k < l; k++)
	        {
	            normals[k] = -normals[k];
	        }
	        l = mesh.subMeshCount;
	        for (int m = 0; m < l; m++)
	        {
	            int[] triangles = mesh.GetTriangles(m);
	            int tl = triangles.Length;
	            for (int t = 0; t < tl; t += 3)
	            {
	                int temp = triangles[t + 0];
	                triangles[t + 0] = triangles[t + 1];
	                triangles[t + 1] = temp;
	            }
	            mesh.SetTriangles(triangles, m);
	        }
	        mesh.normals = normals;
	        mesh.RecalculateNormals();
	    }

	    Vector3 upShift = Vector3.up * 100;
	    Vector3 RayCast(Transform pos)
	    {
	        RaycastHit hit;
	        if (Physics.Raycast(pos.position + upShift, Vector3.down, out hit, 200f, 1 << raycastLayer))
	        {
	            return hit.point;
	        }
	        Debug.Log("No hit from " + (pos.position + upShift)); return Vector3.zero;
	    }




		// Set the start node
		public void setNodeStart(GameObject node )
		{
			node_start = node;
			nodeColStart = NodeColliderType.OnNode;
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
	}
}