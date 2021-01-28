using UnityEngine;
using Flycer.Interface;

namespace Flycer.Controllers
{
    public class Tower_Fire : BaseController
    {
        #region ==========Variables========
        enum ShellType { bullets, rockets };

        [Header("Shooting")]
        [SerializeField] ShellType _type;
        [SerializeField] [Tooltip("Rate of fire")] float _reloadTime = 1;
        [SerializeField] int _dmg = 5;
        [SerializeField] int _range = 20;

        [Space(10)]
        [Header("Render part")]
        [SerializeField] ParticleSystem[] _muzzleFlash;
        
        [Space(5)]
        [SerializeField] [Tooltip("Rocket model if it's rocket type")] Rigidbody _rocket;
        [SerializeField] AudioSource _shootSound;

        //private variables
        float _reloadTimer;
        Transform[] _spawnPoints;

        #endregion ==========Variables========

        #region ==========Unity-time==========
        void Start()
        {
            _reloadTimer = _reloadTime;
            _dmg *= GetComponentInParent<Stats>().GetDMGBoost;

            _spawnPoints = new Transform[_muzzleFlash.Length];

            for (int i = 0; i < _muzzleFlash.Length; i++)
            {
                _spawnPoints[i] = _muzzleFlash[i].transform;
            }

            base.On();  //ВРЕМЕННО
        }

        private void FixedUpdate()
        {
            if (_reloadTimer <= _reloadTime)
                _reloadTimer += Time.deltaTime;
        }

        private void OnTriggerStay(Collider other)
        {
            if (!Enabled)
                return;

            if (other.CompareTag("Player"))
            {
                FireUp();
            }
        }

        #endregion ==========Unity-time==========

        private void FireUp()
        {
            if (_reloadTimer > _reloadTime)
            {
                //Spawning muzzle flash
                for (int i = 0; i < _spawnPoints.Length; i++)
                {
                    _muzzleFlash[i].Play();
                }

                //shootSound.Play();    //Sound

                _reloadTimer = 0;   //FireRate control

                if (_type == ShellType.rockets)
                {
                    foreach (var hole in _spawnPoints)
                    {
                        Rigidbody bulletClone = Instantiate(_rocket, hole.position, transform.rotation);
                    }
                }
            }
        }
    }
}