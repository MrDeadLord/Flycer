using UnityEngine;
using Flycer.Interface;
using Flycer.Helpers;
using System.Collections.Generic;

namespace Flycer
{
    [RequireComponent(typeof(ParticleSystem))]
    public class Bullet : MonoBehaviour
    {
        #region ========== Variables ========
        
        [SerializeField] int _curDMG = 5;

        [Header("Hit effects")]
        [SerializeField] ParticleSystem _hitSteel;
        [SerializeField] ParticleSystem _hitWood;
        [SerializeField] ParticleSystem _hitFlesh;
        [SerializeField] ParticleSystem _hitDirt;
        [SerializeField] ParticleSystem _hitStone;

        ParticleSystem _mainParticles;
        List<ParticleCollisionEvent> _collEvent;

        #endregion ========== Variables ========

        #region ========== Unity-time ========

        private void Start()
        {
            _mainParticles = GetComponent<ParticleSystem>();
            _collEvent = new List<ParticleCollisionEvent>();            
        }

        private void Update()
        {
            if (Input.GetButtonDown(Controls.Pause.ToString()))
                Switch();
        }

        private void OnParticleCollision(GameObject other)
        {
            SetDamage(other.GetComponent<ISetDamage>());
            
            //Creating hit effect
            _mainParticles.GetCollisionEvents(other, _collEvent);
            Vector3 pos = _collEvent[0].intersection;   //hit posotion
            Quaternion newRot = Quaternion.Euler(transform.rotation.x, -transform.rotation.y, transform.rotation.z);

            switch (other.GetComponent<Stats>().GetMatter)
            {
                case Matter.Steel:
                    Instantiate(_hitSteel, pos, newRot);
                    break;
                case Matter.Wood:
                    Instantiate(_hitWood, pos, newRot);
                    break;
                case Matter.Flesh:
                    Instantiate(_hitFlesh, pos, newRot);
                    break;
                case Matter.Dirt:
                    Instantiate(_hitDirt, pos, newRot);
                    break;
                case Matter.Stone:
                    Instantiate(_hitStone, pos, newRot);
                    break;
            }
        }

        #endregion ========== Unity-time ========

        void Switch()
        {
            if (!_mainParticles.isPaused)
                _mainParticles.Pause();
            else
                _mainParticles.Play();
            
        }

        void SetDamage(ISetDamage obj)
        {
            if (obj != null)
            {                
                obj.ApplyDamage(_curDMG);
            }
        }

        #region ======== Public gets ========
        public int Damage { get { return _curDMG; } set { _curDMG = value; } }
        #endregion ======== Public gets ========
    }
}