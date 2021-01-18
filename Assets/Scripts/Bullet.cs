using UnityEngine;
using Flycer.Interface;

namespace Flycer
{
    [RequireComponent(typeof(ParticleSystem))]
    public class Bullet : MonoBehaviour
    {
        #region ==========Variables========

        [SerializeField] int _curDMG = 5;

        #endregion ==========Variables========

        #region ==========Unity-time========

        private void OnParticleCollision(GameObject other)
        {
            SetDamage(other.GetComponent<ISetDamage>());
        }

        #endregion ==========Unity-time========

        private void SetDamage(ISetDamage obj)
        {
            if (obj != null)
            {
                obj.ApplyDamage(_curDMG);
            }
        }

        public void Play()
        {
            GetComponent<ParticleSystem>().Play();
        }

        public int Damage { get { return _curDMG; } set { _curDMG = value; } }
    }
}