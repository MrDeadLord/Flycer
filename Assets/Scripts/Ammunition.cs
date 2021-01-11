using System.Collections.Generic;
using UnityEngine;
using Flycer.Interface;

namespace Flycer
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Ammunition : MonoBehaviour
    {
        #region ==========Variables========

        [SerializeField] int _force = 10;
        [SerializeField] int _dmg = 5;
        [Space(5)]
        [SerializeField] int _dieTime = 5;
        [Space(5)]
        [SerializeField] List<string> _ignoreTags = new List<string>();

        Rigidbody _rigBody;

        #endregion ==========Variables========

        private void Awake()
        {
            _rigBody = GetComponent<Rigidbody>();

            Destroy(gameObject, _dieTime);
        }

        private void OnTriggerEnter(Collider coll)
        {
            if (_ignoreTags.Contains(coll.transform.tag))
                return;

            SetDamage(coll.GetComponent<ISetDamage>());
            
            Destroy(gameObject);
        }

        /// <summary>
        /// Pushing the rigBody object forward
        /// </summary>
        public void Push()
        {
            _rigBody.AddForce(Vector3.forward * _force, ForceMode.Impulse);
        }

        private void SetDamage(ISetDamage obj)
        {
            if (obj != null)
            {
                obj.ApplyDamage(_dmg);
            }
        }

        /// <summary>
        /// Значение урона
        /// </summary>
        public int GetDamage
        {
            get { return _dmg; }
            set { _dmg = value; }
        }
    }
}