using UnityEngine;
using System.Collections;
using CityFuture.Streets.Enums;

namespace CityFuture.Streets.Helpers
{
	public static class StreetUtils
	{
		private const string PedestrianPathway = "Prefabs/Streets/pedestrianPathway";
		private const string DirtRoad = "Prefabs/Streets/dirtRoad";
		private const string TwoLaneStreet = "Prefabs/Streets/twoLaneStreet";
		private const string FourLaneStreet = "Prefabs/Streets/fourLaneStreet";
		private const string Avenue = "Prefabs/Streets/avenue";
		private const string DensityAvenue = "Prefabs/Streets/densityAvenue";
		private const string ParkWay = "Prefabs/Streets/parkWay";
		private const string Freeway = "Prefabs/Streets/freeway";
		private const string Ramp = "Prefabs/Streets/ramp";

		private const string PreBuilt1 = "Prefabs/Streets/preBuilt1";
		private const string PreBuilt2 = "Prefabs/Streets/preBuilt2";


		public static string getStreetPath(int street_type)
		{
			switch(street_type)
			{
				case 1 : return PedestrianPathway;
				case 2 : return DirtRoad;
				case 3 : return TwoLaneStreet;
				case 4 : return FourLaneStreet;
				case 5 : return Avenue;
				case 6 : return DensityAvenue;
				case 7 : return ParkWay;
				case 8 : return Freeway;
				case 9 : return Ramp;
				case 10 : return PreBuilt1; // TODO implement method to choose prebuilt
				default : return FourLaneStreet;
			}
		}

		public static string getStreetPath(StreetType street_type)
		{
			return getStreetPath((int)street_type);
		}
	}
}