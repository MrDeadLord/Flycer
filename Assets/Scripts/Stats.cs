using UnityEngine;
using Flycer.Interface;
using Flycer.Helpers;
using Flycer.Controllers;

namespace Flycer
{
    /// <summary>
    /// HP, difficulty boost & die stuff
    /// </summary>
    public class Stats : MonoBehaviour, ISetDamage
    {
        #region ========== Variables ========

        [SerializeField] int _maxHP = 100;
        [SerializeField] int _hpRegeneration = 0;
        [Space(5)]
        [SerializeField] Matter _matter;
        [SerializeField] AudioSource _dieSound;
        [SerializeField] GameObject _dieEffect;
        [SerializeField] GameObject _deadBody;

        //private var-s
        /// <summary>
        /// Current HP
        /// </summary>
        int _curHP;
        #endregion ========== Variables ========

        #region ========= Unity-time =========

        private void Start()
        {
            _curHP = _maxHP;

            /*foreach (var item in GetComponents<BaseController>())
            {
                Main.Instance.InpContr.DisablingComp.Add(item);
            }*/
        }

        private void FixedUpdate()
        {
            if (_hpRegeneration != 0)
                _curHP += _hpRegeneration;

            if (_curHP <= 0)
                Death();
        }

        #endregion ========= Unity-time =========

        void Death()
        {
            //_dieSound.Play();
            //Instantiate(_dieEffect, transform.position, Quaternion.identity);
            Instantiate(_deadBody, transform.position, transform.rotation, null);

            Destroy(gameObject);

            //Removing object from pause list
            foreach (var item in GetComponentsInChildren<BaseController>())
            {
                if (Main.Instance.InpContr.DisablingComp.Contains(item))
                    Main.Instance.InpContr.DisablingComp.Remove(item);
            }            
        }

        public void ApplyDamage(int damage)
        {
            _curHP -= damage;
        }

        #region ======== Public gets ========
        public Matter GetMatter { get { return _matter; } }

        #endregion ======== Public gets ========
    }
}