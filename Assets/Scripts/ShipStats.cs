using UnityEngine;
using Flycer.Helpers;
using Flycer.Controllers;

namespace Flycer
{
	public class ShipStats : Stats
	{
		#region ========== Variables ========

        [Header("Weapon setup")]
		[SerializeField] [Tooltip("Damage of a main gun")] int _dmgMain = 5;
		[SerializeField] [Tooltip("Damage of a secondary gun")] int _dmgSec = 10;

		[Header("Movement")]
		[SerializeField] [Tooltip("Slide speed")] float _speed = 50;

		[Header("Other")]
		[SerializeField] [Tooltip("Type of ability selected")] Ability _adility;
		[SerializeField] [Tooltip("Duration of an ability")] float _abilityTime;
        
        [Space(5)]
        [SerializeField] [Tooltip("Envoirment damage(by crashing the ground or some)")] int _envDmg;

        float _envDmgTimer = 1;

        #endregion ========== Variables ========

        #region ========== Unity-time ========

        private void Awake()
        {
            GetComponent<MovementPhysics>().speed = _speed;

            GetComponent<Shooting>().damageMain = _dmgMain;
            GetComponent<Shooting>().damageSec = _dmgSec;
        }

        private void FixedUpdate()
        {
            //Giving a chance to redeem yourself after hitting the ground
            if (_envDmgTimer < 1)
                _envDmgTimer += Time.deltaTime;
            else
                return;
        }
                
        private void OnCollisionStay(Collision coll)
        {
            //Taking damage is touching the ground/envoirment
            if (coll.transform.tag == Layer.Envoirment.ToString() && _envDmgTimer >= 1)
            {
                ApplyDamage(_envDmg);
                _envDmgTimer = 0;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Envoirment" || other.tag == "Enemy")
                Death();
        }

        #endregion ========== Unity-time ========

        #region ========== Methods ========

        public override void Death()
        {
            base.Death();

            //Здесь будет пауза и Death Screen
            Main.Instance.InpContr.Pause();
        }

        #endregion ========== Methods ========

        #region ========== Publics ========
        #endregion ========== Publics ========
    }
}