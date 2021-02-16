using UnityEngine;
using Flycer.Helpers;
using Flycer.Controllers;

namespace Flycer
{
	public class ShipStats : Stats
	{
		#region ========== Variables ========

		[SerializeField] [Tooltip("Damage of a main gun")] int _dmgMain = 5;
		[SerializeField] [Tooltip("Damage of a secondary gun")] int _dmgSec = 10;
		[Space(5)]
		[SerializeField] [Tooltip("Slide speed")] float _speed = 50;
		[Space(5)]
		[SerializeField] [Tooltip("Type of ability selected")] Ability _adility;
		[SerializeField] [Tooltip("Duration of an ability")] float _abilityTime;

        #endregion ========== Variables ========

        #region ========== Unity-time ========

        private void Awake()
        {
            GetComponent<MovementPhysics>().speed = _speed;

            GetComponent<Shooting>().damageMain = _dmgMain;
            GetComponent<Shooting>().damageSec = _dmgSec;
        }

        #endregion ========== Unity-time ========

        #region ========== Methods ========
        #endregion ========== Methods ========

        #region ========== Publics ========
        #endregion ========== Publics ========
    }
}