using UnityEngine;
using Flycer.Interface;

namespace Flycer
{
    /// <summary>
    /// HP, difficulty boost & die stuff
    /// </summary>
    public class Stats : MonoBehaviour, ISetDamage
    {
        #region ==========Variables========

        [SerializeField] int _maxHP = 100;
        [SerializeField] int _dmgBoost = 1;
        [SerializeField] int _hpRegeneration;
        [SerializeField] ParticleSystem _hitEffect;
        [SerializeField] AudioSource _dieSound;
        [SerializeField] GameObject _dieEffect;
        [SerializeField] GameObject _deadBody;

        //private var-s
        /// <summary>
        /// Current HP
        /// </summary>
        int _curHP;

        #endregion ==========Variables========

        #region =========Unity-time=========

        private void Start()
        {
            _curHP = _maxHP;
        }

        private void FixedUpdate()
        {
            if (_hpRegeneration != 0)
                _curHP += _hpRegeneration;

            if (_curHP <= 0)
                Death();
        }

        #endregion =========Unity-time=========

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == "Bullet")
            {
                ContactPoint cont = collision.contacts[0];
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, cont.normal);

                Instantiate(_hitEffect, cont.point, rot);
            }
        }

        void Death()
        {
            //_dieSound.Play();
            //Instantiate(_dieEffect, transform.position, Quaternion.identity);
            Instantiate(_deadBody, transform.position, transform.rotation, null);

            Destroy(gameObject);
        }

        public void ApplyDamage(int damage)
        {
            _curHP -= damage;
        }

        public int GetDMGBoost { get { return _dmgBoost; } }
    }
}