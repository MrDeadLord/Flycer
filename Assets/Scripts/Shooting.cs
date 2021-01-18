using UnityEngine;
using Flycer.Helpers;

namespace Flycer
{
    public class Shooting : MonoBehaviour
    {
        #region =====Variables=====        
        [Header("Fire1")]
        [SerializeField] Transform[] _barrelsMain;
        [SerializeField] Bullet _fireEffectBullet;

        [Space(10)] [Header("Fire2")]
        [SerializeField] Ammunition _ammoSec;
        [SerializeField] Transform[] _barrelsSec;
        [SerializeField] ParticleSystem[] _fireEffectRocket;

        [SerializeField] [Range(0, 0.5f)] float _fireRateMain = 0.5f;
        [SerializeField] [Range(0.5f, 3)] float _fireRateSec = 3;

        bool _canShootMain = true;
        bool _canShootSec = false;
        int _dmgBoost;
        #endregion =====Variables=====

        private void Start()
        {
            _dmgBoost = GetComponent<Stats>().GetDMGBoost;
        }

        private void Update()
        {
            if (Input.GetButton(Controls.Fire1.ToString()) && _canShootMain)
                Shoot(Controls.Fire1);
            else if (Input.GetButtonDown(Controls.Fire2.ToString()) && _canShootSec)
                Shoot(Controls.Fire2);

        }

        void Shoot(Controls type)
        {
            if (type == Controls.Fire1)
            {
                for (int i = 0; i < _barrelsMain.Length; i++)
                {
                    var tempBull = Instantiate(_fireEffectBullet, _barrelsMain[i].position, _barrelsMain[i].rotation);
                    tempBull.Damage *= _dmgBoost;
                    tempBull.Play();

                    _canShootMain = false;
                }
                                
                Invoke("CanMain", _fireRateMain);
            }
            else if (type == Controls.Fire2)
            {
                for (int i = 0; i < _barrelsSec.Length; i++)
                {
                    _fireEffectRocket[i].Play();

                    var tempBull = Instantiate(_ammoSec, _barrelsSec[i].position, Quaternion.identity);
                    tempBull.GetDamage *= _dmgBoost;
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