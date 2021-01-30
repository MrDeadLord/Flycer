using UnityEngine;
using Flycer.Helpers;

namespace Flycer.Controllers
{
    public class Shooting : BaseController
    {
        #region =====Variables=====        
        [Header("Fire1")]
        [SerializeField] [Tooltip("Spawn points of main bullets")] Transform[] _barrelsMain;
        [SerializeField] Bullet _mainBull;
        [SerializeField] [Tooltip("Damage of main gun")] int _dmg = 5;

        [Space(10)] [Header("Fire2")]
        [SerializeField] Ammunition _ammoSec;
        [SerializeField] Transform[] _barrelsSec;
        [SerializeField] ParticleSystem[] _fireEffectRocket;

        [SerializeField] [Range(0, 0.5f)] float _fireRateMain = 0.5f;
        [SerializeField] [Range(0.5f, 3)] float _fireRateSec = 3;

        bool _canShootMain = true;
        bool _canShootSec = false;
        #endregion =====Variables=====

        #region ========= Unity-time =========

        private void Start()
        {
            _dmg *= GetComponent<Stats>().diffBoost;
            base.On();  //ВРЕМЕННО
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
                    Bullet tempBull = Instantiate(_mainBull, hole.position, hole.rotation, null);

                    tempBull.Damage = _dmg;
                }

                _canShootMain = false;
                
                Invoke("CanMain", _fireRateMain);
            }
            else if (type == Controls.Fire2)
            {
                for (int i = 0; i < _barrelsSec.Length; i++)
                {
                    _fireEffectRocket[i].Play();

                    var tempBull = Instantiate(_ammoSec, _barrelsSec[i].position, Quaternion.identity);                    
                    tempBull.Push();

                    _canShootSec = false;
                }

                Invoke("CanSec", _fireRateSec);
            }
        }

        void CanMain() { _canShootMain = !_canShootMain; }
        void CanSec() { _canShootSec = !_canShootSec; }
    }
}