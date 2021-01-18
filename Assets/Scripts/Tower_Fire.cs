using UnityEngine;
using Flycer.Interface;

namespace Flycer
{
    public class Tower_Fire : MonoBehaviour
    {
        #region ==========Variables========
        enum ShellType { bullets, rockets };

        [Header("Shooting")]
        [SerializeField] ShellType _type;
        [SerializeField] float _force = 20;
        [SerializeField] float _reloadTime = 1;
        [SerializeField] int _bulletDmg = 5;

        [Space(10)]
        [Header("Render part")]
        [SerializeField] Bullet _bullet;
        [SerializeField] Transform[] _bulletSpawnPoints;
        [Space(5)]
        [SerializeField] Rigidbody _rocket;
        [SerializeField] ParticleSystem[] _fireEffectRocket;
        [SerializeField] AudioSource _shootSound;
        [SerializeField] GameObject _bulletHitEffectBullet;

        //private variables
        float _reloadTimer;
        int _dmgBoost;

        #endregion ==========Variables========

        #region ==========Unity-time==========
        void Start()
        {
            _reloadTimer = _reloadTime;
            _dmgBoost = GetComponentInParent<Stats>().GetDMGBoost;
        }

        private void FixedUpdate()
        {
            if (_reloadTimer <= _reloadTime)
                _reloadTimer += Time.deltaTime;
        }

        private void OnTriggerStay(Collider other)
        {
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
                if (_type == ShellType.rockets)
                {
                    for (int i = 0; i < _bulletSpawnPoints.Length; i++)
                    {
                        Rigidbody bulletClone = Instantiate(_rocket, _bulletSpawnPoints[i].position, transform.rotation);

                        bulletClone.velocity = transform.forward * _force;

                        _fireEffectRocket[i].Play();
                    }
                }
                else if (_type == ShellType.bullets)
                {
                    foreach (var hole in _bulletSpawnPoints)
                    {
                        var tempBull = Instantiate(_bullet, hole.position, hole.rotation);
                        tempBull.Damage *= _dmgBoost;
                        tempBull.Play();
                    }
                }

                //shootSound.Play();

                _reloadTimer = 0;
            }
        }
    }
}