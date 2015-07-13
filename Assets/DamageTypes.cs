using System;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	[Serializable]
	public class DamageTypes
	{
		private static Dictionary<int, String> damageTypes = new Dictionary<int, string> ();

		/**
		 * adds the specified damage type to the game
		 * returns true if successful; returns false if id already in use
		 */
		public bool addType(int id, String name) {

			if (damageTypes.ContainsKey (id))
				return false;

			damageTypes.Keys [id] = name;
			return true;
		}

		public String getName(int id) {
			return damageTypes.ContainsKey(id)? damageTypes.Keys[id]: null;
		}

		public bool deleteType(int id) {
			if (damageTypes.ContainsKey) {

				damageTypes.Remove(id);
				return true;
			}
			return false;
		}
	}
}
