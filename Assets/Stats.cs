using System;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	[Serializable]
	public class Stats
	{
		private Dictionary<String, int> stats;

		
		public Stats() {

			stats = new Dictionary<String, int> ();
		}
		public Stats(Dictionary<String, int> stats) {

			this.stats = stats;
		}
		
		/**
		 * adds the specified stat to the instance
		 * returns true if successful; returns false if id already in use
		 */
		public bool addType(String name, int value) {
			
			if (stats.ContainsKey (name))
				return false;
			
			stats.Add(name, value);
			return true;
		}
		
		public int getValue(String name) {

			return stats.ContainsKey(name)? stats[name]: -1;
		}

		/**
		 * sets the specified stat to the value
		 * returns false if the stat does not exist
		 */
		public bool setValue(String name, int value) {

			if (!stats.ContainsKey (name))
				return false;

			stats [name] = value;
			return true;
		}
		
		public bool deleteType(String name) {

			if (stats.ContainsKey(name)) {
				
				stats.Remove(name);
				return true;
			}
			return false;
		}
	}
}
