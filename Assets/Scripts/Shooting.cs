using UnityEngine;
using Flycer.Helpers;

namespace Flycer
{
    public class Shooting : MonoBehaviour
    {
        #region =====Variables=====
        [SerializeField] Ammunition _ammoMain;
        [SerializeField] Ammunition _ammoSec;
        [Space(5)]
        [SerializeField] Transform[] _barrelsMain;
        [SerializeField] Transform[] _barrelsSec;

        [SerializeField] [Range(0, 0.5f)] float _fireRateMain = 0.5f;
        [SerializeField] [Range(0.5f, 3)]float _fireRateSec = 3;

        bool _canShootMain = true;
        bool _canShootSec = false;
        #endregion =====Variables=====

        private void Update()
        {
            if (Input.GetButton(Controls.Fire1.ToString()) && _canShootMain)
                Shoot(Controls.Fire1);
            else if (Input.GetButtonDown(Controls.Fire2.ToString()) && _canShootSec)
                Shoot(Controls.Fire2);
            
        }

        void Shoot(Controls type)
        {
            if(type == Controls.Fire1)
            {
                foreach (var barrel in _barrelsMain)
                {
                    Instantiate(_ammoMain, barrel.position, Quaternion.identity).Push();

                    _canShootMain = false;
                }

                Invoke("CanMain", _fireRateMain);
            }
            else if(type == Controls.Fire2)
            {
                foreach (var barrel in _barrelsSec)
                {
                    Instantiate(_ammoSec, barrel.position, Quaternion.identity);

                    _canShootSec = false;
                }

                Invoke("CanSec", _fireRateSec);
            }
        }

        void CanMain() { _canShootMain = !_canShootMain; }
        void CanSec() { _canShootSec = !_canShootSec; }
    }
}