using UnityEngine;
using CityFuture.Buildings;
using CityFuture.General.Exceptions;
using CityFuture.General.Enums;

namespace CityFuture.Agents{
	public class Citizen : IAgent
	{
		private string name;
		private byte age;
		private int id;
		private Building home;
		private bool isHomeless;
		private float income;
		private SocialStatus socialStatus;



		#region IAgent implementation
		public bool showAgent ()
		{
			throw new System.NotImplementedException ();
		}
		public bool hideAgent ()
		{
			throw new System.NotImplementedException ();
		}
		public int getID ()
		{
			return this.id;
		}
		public void setID (int id)
		{
			this.id = id;
		}
		public bool moveAgent (CityFuture.Buildings.Building origin, CityFuture.Buildings.Building dest)
		{
			throw new System.NotImplementedException ();
		}
		public void moveAgent (Transform origin, Transform dest)
		{
			throw new System.NotImplementedException ();
		}
		#endregion


		#region Citizen setter/getter methods

		// get name
		public string getName()
		{
			return this.name;
		}

		// set name
		public void setName(string name)
		{
			if(name.Length >= 2)
				this.name = name;
			else
				throw new StringTooShortException("The name needs to be at least 2 characters in length");
		}

		// get age
		public byte getAge()
		{
			return this.age;
		}

		// set age
		public void setAge(byte age)
		{
			if(age >= 0 && age <= 120)
				this.age = age;
			else
				throw new NotAProperNumberException("Age must be from 0 to 120");
		}

		// get home
		public Building getHome()
		{
			return this.home;
		}

		// set home
		public void setHome(Building home)
		{
			if(home is Residential)
				this.home = home;

			// homeless
			else if(home is Park)
			{
				this.home = home;
				this.isHomeless = true;
			}
			else
				throw new BuildingNotCompatibleException("A home must be an instance of Residential or Park");
		}

		// get is homeless
		public bool getIsHomeless()
		{
			return this.isHomeless;
		}

		// set is homeless
		public void setIsHomeless(bool isHomeless)
		{
			this.isHomeless = isHomeless;
		}

		// get income
		public float getIncome()
		{
			return this.income;
		}

		// set income
		public void setIncome(float income)
		{
			this.income = income;
		}

		// get social status of citizen (low middle upper clas)
		public SocialStatus getSocialStatus()
		{
			return this.socialStatus;
		}
		#endregion

	}
}