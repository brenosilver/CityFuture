using CityFuture.Streets.Enums;
using CityFuture.General.Exceptions;
using System;

namespace CityFuture.Streets.Helpers
{
	public static class StreetHelper
	{
		public static int[] pickStreet(StreetType street_ype)
		{
			int[] result = new int[2]; // 1st index = class, 2nd = direction

			int street = 1;
			int street_direction = 1;
			
			// if pedestrian pathway
			if(street_ype == StreetType.PedestrianPathway)
			{
				street = (int)StreetType.PedestrianPathway;
				street_direction = (int)StreetDirection.OneWay;
			}

			// if dirt road
			else if(street_ype == StreetType.DirtRoad)
			{
				street = (int)StreetType.DirtRoad;
				street_direction = (int)StreetDirection.OneWay;
			}

			// if 2 lane street
			else if(street_ype == StreetType.TwoLaneStreet)
			{
				street = (int)StreetType.TwoLaneStreet;
				street_direction = (int)StreetDirection.TwoWay;
			}

			// if 4 lane street
			else if(street_ype == StreetType.FourLaneStreet)
			{
				street = (int)StreetType.FourLaneStreet;
				street_direction = (int)StreetDirection.TwoWay;
			}

			// if Avenue
			else if(street_ype == StreetType.Avenue)
			{
				street = (int)StreetType.Avenue;
				street_direction = (int)StreetDirection.TwoWay;
			}

			// if Dense Avenue
			else if(street_ype == StreetType.DenseAvenue)
			{
				street = (int)StreetType.DenseAvenue;
				street_direction = (int)StreetDirection.TwoWay;
			}

			// if Avenue Plus Train
			else if(street_ype == StreetType.AvenuePlusTrain)
			{
				street = (int)StreetType.AvenuePlusTrain;
				street_direction = (int)StreetDirection.TwoWay;
			}

			// if ParkWay
			else if(street_ype == StreetType.ParkWay)
			{
				street = (int)StreetType.ParkWay;
				street_direction = (int)StreetDirection.TwoWay;
			}

			// if Freeway
			else if(street_ype == StreetType.Freeway)
			{
				street = (int)StreetType.Freeway;
				street_direction = (int)StreetDirection.TwoWay;
			}

			// if Ramp
			else if(street_ype == StreetType.Ramp)
			{
				street = (int)StreetType.Ramp;
				street_direction = (int)StreetDirection.OneWay;
			}

			// if Pre-Built
			else if(street_ype == StreetType.PreBuilt)
			{
				street = (int)StreetType.PreBuilt;
				street_direction = (int)StreetDirection.OneWay;
			}
			else{
				throw new NoSuchTypeException("The street selected does not exist!");
			}

			result[0] = street;
			result[1] = street_direction;

			return result;
		}
	}
}