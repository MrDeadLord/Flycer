using UnityEngine;
using Flycer.Helpers;

namespace Flycer.Controllers
{
    public class Shooting : BaseController
    {
        #region =====Variables=====        
        [Header("Fire1")]
        [SerializeField] [Tooltip("Spawn points of main bullets")] Transform[] _barrelsMain;
        [SerializeField] Ammunition _ammoMain;
        [SerializeField] [Range(0, 0.5f)] float _fireRateMain = 0.5f;

        [Header("Fire2")]
        [SerializeField] Transform[] _barrelsSec;
        [SerializeField] Ammunition _ammoSec;
        [SerializeField] [Range(0.5f, 3)] float _fireRateSec = 3;

        public int damageMain { get; set; }
        public int damageSec { get; set; }

        bool _canShootMain = true;
        bool _canShootSec = false;
        #endregion =====Variables=====

        #region ========= Unity-time =========

        private void Start()
        {
            base.OnPause();
            base.On();  //ВРЕМЕННО

            #region Debugging            
            if (damageMain == 0)
                Debug.LogError("Main Damage is zero!");

            if (damageSec == 0)
                Debug.LogError("Secondary Damage is zero!");
            #endregion
        }

        private void Update()
        {
            if (!Enabled)
                return;

            if (Input.GetButton(Controls.Fire1.ToString()) && _canShootMain)
                Shoot(Controls.Fire1);
            else if (Input.GetButtonDown(Controls.Fire2.ToString()) && _canShootSec)
                Shoot(Controls.Fire2);

        }

        #endregion ========= Unity-time =========

        void Shoot(Controls type)
        {
            if (type == Controls.Fire1)
            {
                foreach (var hole in _barrelsMain)
                {
                    Ammunition tempBull = Instantiate(_ammoMain, hole.position, hole.rotation, null);

                    tempBull.Damage = damageMain;
                }

                _canShootMain = false;

                Invoke("CanMain", _fireRateMain);
            }
            else if (type == Controls.Fire2)
            {
                foreach (var hole in _barrelsSec)
                {
                    Ammunition tempBull = Instantiate(_ammoSec, hole.position, hole.rotation, null);

                    tempBull.Damage = damageSec;
                }

                _canShootSec = false;

                Invoke("CanSec", _fireRateSec);
            }
        }

        void CanMain() { _canShootMain = !_canShootMain; }
        void CanSec() { _canShootSec = !_canShootSec; }
    }
}