using UnityEngine;
using System;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	public class Entity : MonoBehaviour
	{
		//the ID. of the entity
		private int id;
		//says it all, really
		private Stats stats;
		//multipliers for different types of damage e.g. bullets
		private Dictionary<int, float> damageMuls;
		//messages e.g. details of attacks
		private Message[] messages;
		//unread messages
		private int message;

		public Entity (int id) {

			this.id = id;
			damageMuls = new Dictionary<int, float> ();
			messages = new Message[0];
			message = 0;
			stats = new Stats ();
			stats.addType ("health", 1);
			stats.addType ("defense", 1);
			stats.addType ("offense", 1);
		}

		public int getID () {

			return id;
		}

		public void sendMessage (Message message) {

			int length = messages.Length;
			Message[] buffer = messages;
			messages = new Message[length];
			for (int i = 0; i < length; i++) {

				messages[i] = buffer[i];
			}
			messages [length] = message;
			this.message++;
		}

		public void attack (int damage, int damageID, Entity victim, byte[] data) {

			float dam = damage;
			dam += stats.getValue ("offense") / dam;
			damage = (int) dam;
			victim.attacked (damage, damageID, this, data);
		}

		public bool attacked (int damage, int damageID, Entity attacker, byte[] data) {
		
			float dam = damage;
			dam *= getDamageMul (damageID);
			dam -= stats.getValue("defense") / dam;
			if (dam < 0)
				dam = 0;
			damage = (int) dam;
			stats.setValue ("health", stats.getValue ("health") - damage);

			string sdata = "[";
			sdata += data [0].ToString();
			for (int i = 1; i < data.Length; i++) {

				sdata += "," + data [i].ToString();
			}
			sdata += "]";
			attacker.sendMessage (new Message ("data attacker " + sdata, this));
		
			return damage > 0;
		}

		public float getDamageMul (int damageID) {

			float damageMul;
			bool success = damageMuls.TryGetValue (damageID, out damageMul);
			if (success)
				return damageMul;
			else
				return 1.0f;
		}

		/**
		 * sets the multiplier for a type of damage
		 * returns false if multiplier already exists for damage (though it still overwrites it)
		 */
		public bool setDamageMul (int damageID, float mul) {

			if (!damageMuls.ContainsKey (damageID)) {

				damageMuls [damageID] = mul;
				return false;
			}
			else {

				damageMuls.Add(damageID, mul);
				return true;
			}
		}

		public Stats getStats () {

			return stats;
		}

		public override string ToString ()
		{
			return id.ToString ();
		}

		// Use this for initialization
		void Start () {

			this ();
		}
		
		// Update is called once per frame
		void Update () {

			if(health <= 0)
				this.sendMessage("data die")
		}
	}
}
