
namespace CityFuture.Streets.Enums
{
	public enum StreetType
	{
		PedestrianPathway = 1,	// 1 lane + only pedestrians
		DirtRoad = 2,			// 1 lane
		TwoLaneStreet = 3,		// 2 lanes
		FourLaneStreet = 3,		// 4 lanes
		Avenue = 4,				// 4 lanes + trees
		DensityAvenue = 5,		// 4 lanes
		AvenuePlusTrain = 6,	// 4 lanes + train lane
		ParkWay = 7,			// 4 lanes + trees + no trucks allowed
		Freeway = 8,			// 4 lanes + no crossing
		Ramp = 9,				// 1 lane + connects to freeway
		PreBuilt = 10			// pre built intersections
	}

	public enum StreetDirection
	{
		OneWay = 1,
		TwoWay = 2,
	}
}