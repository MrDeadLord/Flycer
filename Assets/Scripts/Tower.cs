using UnityEngine;

namespace Flycer
{
    public class Tower : MonoBehaviour
    {
        #region ==========Variables========

        [Header("Shooting")]
        [SerializeField] Rigidbody _bullet;
        [SerializeField] Transform _bulletSpawnPoint;
        [SerializeField] GameObject _fireEffect;
        [SerializeField] AudioSource _shootSound;
        [SerializeField] float _force = 20;
        [SerializeField] float _reloadTime = 1;
        [SerializeField] int _rotateSpeed = 10;

        //private variables
        float reloadTimer;

        #endregion ==========Variables========

        #region ==========Unity-time==========
        void Start()
        {
            reloadTimer = _reloadTime;
        }

        private void FixedUpdate()
        {
            if (reloadTimer <= _reloadTime)
                reloadTimer += Time.deltaTime;            
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Quaternion rotatePlayer = Quaternion.LookRotation(other.transform.position - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotatePlayer, _rotateSpeed * Time.deltaTime);

                FireUp();
            }
        }

        #endregion ==========Unity-time==========

        private void FireUp()
        {            
            if (reloadTimer > _reloadTime)
            {
                //shootSound.Play();
                
                Rigidbody bulletClone = Instantiate(_bullet, _bulletSpawnPoint.position, transform.rotation);

                Instantiate(_fireEffect, _bulletSpawnPoint.position, transform.rotation);

                bulletClone.velocity = transform.forward * _force;

                reloadTimer = 0;
            }
        }
    }
}