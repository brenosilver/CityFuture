using UnityEngine;
using System.Collections;

namespace CityFuture.Buildings.Helpers{
	public static class BuildingUtils
	{
		// Residential resource Paths
		public const string resource_resi_shack_path = "Prefabs/Buildings/Residential/residential_shack";
		public const string resource_resi_townHouse_path = "";
		public const string resource_resi_smallApt_path = "";
		public const string resource_resi_apt_path = "Prefabs/Buildings/Residential/residential_apartment";
		public const string resource_resi_skyscraper_path = "";

		// Commercial resource Paths
		public const string resource_comm_small_path = "Prefabs/Buildings/Commercial/commercial_small";
		public const string resource_comm_medium_path = "";
		public const string resource_comm_big_path = "";

		// Industrial resource Paths
		public const string resource_ind_small_path = "";
		public const string resource_ind_medium_path = "Prefabs/Buildings/Industrial/industrial_small";
		public const string resource_ind_big_path = "";

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

	}
}
