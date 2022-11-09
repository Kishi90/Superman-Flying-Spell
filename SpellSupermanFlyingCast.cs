using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using ThunderRoad;
using HarmonyLib;
using Newtonsoft;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using Action = System.Action;
using Object = System.Object;
using Random = UnityEngine.Random;
using Extensions;

namespace Superman
{
    public class SupermanFlyingCast : SpellCastCharge
    {
		public float FlightForceMultiplier;
		public float FlightTorqueMultiplier;

		public override void UpdateCaster()
		{
			base.UpdateCaster();
			if (PlayerControl.handLeft.castPressed || PlayerControl.handRight.castPressed)
			{
				// Force
				Player.currentCreature.handLeft.rb.AddForce(Player.currentCreature.handLeft.transform.up * FlightForceMultiplier, ForceMode.VelocityChange);
				Player.currentCreature.handRight.rb.AddForce(Player.currentCreature.handRight.transform.up * FlightForceMultiplier, ForceMode.VelocityChange);

				// Torque
				Player.currentCreature.handLeft.rb.AddTorque(Player.currentCreature.handLeft.transform.up * FlightTorqueMultiplier, ForceMode.VelocityChange);
				Player.currentCreature.handRight.rb.AddTorque(Player.currentCreature.handRight.transform.up * FlightTorqueMultiplier, ForceMode.VelocityChange);

				// Miscellaneous
				Player.fallDamage = false;
			}
		}
	}
}
