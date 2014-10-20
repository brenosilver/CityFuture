using UnityEngine;
using CityFuture.Streets.Enums;
using CityFuture.General.Exceptions;

namespace CityFuture.Streets.Helpers
{
	public static class StreetFactory
	{
		private static Street new_street;
		private static GameObject prefab;
		private static GameObject street_obj;

		public static void createStreet(StreetType type_of_street)
		{
			int[] street_data = StreetHelper.pickStreet(type_of_street);
			
			// Pedestrian Pathway
			if(type_of_street == StreetType.PedestrianPathway)
			{
				prefab = Resources.Load(StreetUtils.getStreetPath(street_data[0])) as GameObject;
				street_obj = GameObject.Instantiate(prefab) as GameObject;
				
				new_street = PedestrianPathWay.CreateComponent(street_obj, (StreetDirection)street_data[1]);
			}

			// Pedestrian Pathway
			else if(type_of_street == StreetType.DirtRoad)
			{
				prefab = Resources.Load(StreetUtils.getStreetPath(street_data[0])) as GameObject;
				street_obj = GameObject.Instantiate(prefab) as GameObject;
				
				new_street = DirtRoad.CreateComponent(street_obj, (StreetDirection)street_data[1]);
			}

			// TwoLaneStreet
			else if(type_of_street == StreetType.TwoLaneStreet)
			{
				prefab = Resources.Load(StreetUtils.getStreetPath(street_data[0])) as GameObject;
				street_obj = GameObject.Instantiate(prefab) as GameObject;
				
				new_street = TwoLaneStreet.CreateComponent(street_obj, (StreetDirection)street_data[1]);
			}

			// FourLaneStreet
			else if(type_of_street == StreetType.FourLaneStreet)
			{
				prefab = Resources.Load(StreetUtils.getStreetPath(street_data[0])) as GameObject;
				street_obj = GameObject.Instantiate(prefab) as GameObject;
				
				new_street = FourLaneStreet.CreateComponent(street_obj, (StreetDirection)street_data[1]);
			}

			// Avenue
			else if(type_of_street == StreetType.Avenue)
			{
				prefab = Resources.Load(StreetUtils.getStreetPath(street_data[0])) as GameObject;
				street_obj = GameObject.Instantiate(prefab) as GameObject;
				
				new_street = Avenue.CreateComponent(street_obj, (StreetDirection)street_data[1]);
			}

			// DenseAvenue
			else if(type_of_street == StreetType.DenseAvenue)
			{
				prefab = Resources.Load(StreetUtils.getStreetPath(street_data[0])) as GameObject;
				street_obj = GameObject.Instantiate(prefab) as GameObject;
				
				new_street = DenseAvenue.CreateComponent(street_obj, (StreetDirection)street_data[1]);
			}

			// AvenuePlusTrain
			else if(type_of_street == StreetType.AvenuePlusTrain)
			{
				prefab = Resources.Load(StreetUtils.getStreetPath(street_data[0])) as GameObject;
				street_obj = GameObject.Instantiate(prefab) as GameObject;
				
				new_street = AvenuePlusTrain.CreateComponent(street_obj, (StreetDirection)street_data[1]);
			}

			// ParkWay
			else if(type_of_street == StreetType.ParkWay)
			{
				prefab = Resources.Load(StreetUtils.getStreetPath(street_data[0])) as GameObject;
				street_obj = GameObject.Instantiate(prefab) as GameObject;
				
				new_street = ParkWay.CreateComponent(street_obj, (StreetDirection)street_data[1]);
			}

			// Freeway
			else if(type_of_street == StreetType.Freeway)
			{
				prefab = Resources.Load(StreetUtils.getStreetPath(street_data[0])) as GameObject;
				street_obj = GameObject.Instantiate(prefab) as GameObject;
				
				new_street = Freeway.CreateComponent(street_obj, (StreetDirection)street_data[1]);
			}

			// Ramp
			else if(type_of_street == StreetType.Ramp)
			{
				prefab = Resources.Load(StreetUtils.getStreetPath(street_data[0])) as GameObject;
				street_obj = GameObject.Instantiate(prefab) as GameObject;
				
				new_street = Ramp.CreateComponent(street_obj, (StreetDirection)street_data[1]);
			}

			// PreBuilt
			else if(type_of_street == StreetType.PreBuilt)
			{
				prefab = Resources.Load(StreetUtils.getStreetPath(street_data[0])) as GameObject;
				street_obj = GameObject.Instantiate(prefab) as GameObject;
				
				new_street = PreBuilt.CreateComponent(street_obj, (StreetDirection)street_data[1]);
			}
			else
				throw new NoSuchTypeException("Street Type not found");
		}
	}
}