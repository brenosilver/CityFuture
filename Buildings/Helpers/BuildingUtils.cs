using CityFuture.Buildings.Enums;

namespace CityFuture.Buildings.Helpers{
	public static class BuildingUtils
	{
		// Residential resource Paths
		private const string resource_resi_shack_path = "Prefabs/Buildings/Residential/residential_shack";
		private const string resource_resi_townHouse_path = "";
		private const string resource_resi_smallApt_path = "";
		private const string resource_resi_apt_path = "Prefabs/Buildings/Residential/residential_apartment";
		private const string resource_resi_skyscraper_path = "";

		// Commercial resource Paths
		private const string resource_comm_small_path = "Prefabs/Buildings/Commercial/commercial_small";
		private const string resource_comm_medium_path = "";
		private const string resource_comm_big_path = "";

		// Industrial resource Paths
		private const string resource_ind_small_path = "Prefabs/Buildings/Industrial/industrial_small";
		private const string resource_ind_medium_path = "";
		private const string resource_ind_big_path = "";


		// Return the path of residential building by size
		public static string getResidentialPath(int size)
		{
			switch(size)
			{
				case 1: return resource_resi_shack_path;
				case 2: return resource_resi_townHouse_path;
				case 3: return resource_resi_smallApt_path;
				case 4: return resource_resi_apt_path;
				case 5: return resource_resi_skyscraper_path;
				default: return resource_resi_shack_path;
			}
		}

		// Overloaded Residential
		public static string getResidentialPath(ResidentialSize size)
		{
			return getResidentialPath((int)size);
		}

		// Return the path of commercial building by size
		public static string getCommercialPath(int size)
		{
			switch(size)
			{
				case 1: return resource_comm_small_path;
				case 2: return resource_comm_medium_path;
				case 3: return resource_comm_big_path;
				default: return resource_comm_small_path;
			}
		}

		// Overloaded Commercial
		public static string getCommercialPath(CommercialSize size)
		{
			return getCommercialPath((int)size);
		}

		// Return the path of industrial building by size
		public static string getIndustrialPath(int size)
		{
			switch(size)
			{
				case 1: return resource_ind_small_path;
				case 2: return resource_ind_medium_path;
				case 3: return resource_ind_big_path;
				default: return resource_ind_small_path;
			}
		}

		// Overloaded Industrial
		public static string getIndustrialPath(IndustrialSize size)
		{
			return getIndustrialPath((int)size);
		}

	}
}
