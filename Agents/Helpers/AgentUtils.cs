using CityFuture.Agents.Enums;

namespace CityFuture.Agents.Helpers
{
	public static class AgentUtils
	{
		private const string resource_kid_path = "Prefabs/Agents/Citizen/kid";
		private const string resource_adult_path = "Prefabs/Agents/Citizen/adult";
		private const string resource_elder_path = "Prefabs/Agents/Citizen/elder";

		private const string resource_car_cheap_path = "Prefabs/Agents/Vehicle/cheapCar";
		private const string resource_car_popular_path = "Prefabs/Agents/Vehicle/popularCar";
		private const string resource_car_intermediate_path = "Prefabs/Agents/Vehicle/intermediateCar";
		private const string resource_car_expensive_path = "Prefabs/Agents/Vehicle/expensiveCar";
		private const string resource_car_veryExpensive_path = "Prefabs/Agents/Vehicle/veryExpensiveCar";
		private const string resource_car_truck_path = "Prefabs/Agents/Vehicle/truckCar";

		private const string resource_boat_motorBoat_path = "Prefabs/Agents/Vehicle/motorBoat";
		private const string resource_boat_sailBoat_path = "Prefabs/Agents/Vehicle/sailBoat";
		private const string resource_boat_speedBoat_path = "Prefabs/Agents/Vehicle/speedBoat";
		private const string resource_boat_ship_path = "Prefabs/Agents/Vehicle/ship";

		private const string resource_airplane_singleEngine_path = "Prefabs/Agents/Vehicle/singleEngineAirplane";
		private const string resource_airplane_twinEngine_path = "Prefabs/Agents/Vehicle/twinEngineAirplane";
		private const string resource_airplane_cargoPlane_path = "Prefabs/Agents/Vehicle/speedBoat";
		private const string resource_airplane_businessJet_path = "Prefabs/Agents/Vehicle/businessJet";
		private const string resource_airplane_airliner_path = "Prefabs/Agents/Vehicle/airliner";

		// TODO FINISH THIS

		// Return the path of Citizen by type
		public static string getCitizenPath(int size)
		{
			switch(size)
			{
			case 1: return resource_kid_path;
			case 2: return resource_adult_path;
			case 3: return resource_elder_path;
			default: return resource_adult_path;
			}
		}

		// Overloaded Citizen
		public static string getCitizenPath(AgentClass size)
		{
			return getCitizenPath((int)size);
		}

		// Return the path of Car by type
		public static string getCarPath(int size)
		{
			switch(size)
			{
			case 1: return resource_car_cheap_path;
			case 2: return resource_car_popular_path;
			case 3: return resource_car_intermediate_path;
			case 4: return resource_car_expensive_path;
			case 5: return resource_car_veryExpensive_path;
			case 6: return resource_car_truck_path;
			default: return resource_car_cheap_path;
			}
		}
		
		// Overloaded Car
		public static string getCarPath(CarType size)
		{
			return getCarPath((int)size);
		}

		// Return the path of boats by size
		public static string getBoatPath(int size)
		{
			switch(size)
			{
			case 1: return resource_boat_motorBoat_path;
			case 2: return resource_boat_sailBoat_path;
			case 3: return resource_boat_speedBoat_path;
			case 4: return resource_boat_ship_path;
			default: return resource_boat_ship_path;
			}
		}

		// Overloaded Boat
		public static string getBoatPath(BoatType size)
		{
			return getBoatPath((int)size);
		}

		// Return the path of Airplanes by size
		public static string getAirplanePath(int size)
		{
			switch(size)
			{
			case 1: return resource_airplane_singleEngine_path;
			case 2: return resource_airplane_twinEngine_path;
			case 3: return resource_airplane_cargoPlane_path;
			case 4: return resource_airplane_businessJet_path;
			case 5: return resource_airplane_airliner_path;
			default: return resource_airplane_airliner_path;
			}
		}

		// Overloaded Airplanes
		public static string getAirplanePath(AirplaneType size)
		{
			return getAirplanePath((int)size);
		}
	}
}