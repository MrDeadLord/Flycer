using UnityEngine;
using Flycer.Interface;

namespace Flycer
{
    /// <summary>
    /// Not moving tower build in mountain or some
    /// </summary>
    public class TowerBuildin : MonoBehaviour
    {
        #region ==========Variables========

        [SerializeField] int _dmg = 5;
        [SerializeField] int _fireRate = 2;

        [Space(10)]
        [SerializeField] Transform[] _fireEffects;

        float _reloadTimer;
        Renderer[] _renders;
        float _dissTime = 0.2f; //time to shoot slash dissapear

        #endregion ==========Variables========

        #region =========Unity-time=========
        private void Start()
        {
            _renders = new Renderer[_fireEffects.Length];

            for (int i = 0; i < _fireEffects.Length; i++)
            {
                _renders[i] = _fireEffects[i].GetComponent<Renderer>();
                _renders[i].enabled = false;
            }
        }

        private void FixedUpdate()
        {
            if (_reloadTimer <= _fireRate)
                _reloadTimer += Time.deltaTime;
        }
        #endregion =========Unity-time=========

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                FireUp(other.transform);
            }
        }

        private void FireUp(Transform obj)
        {
            if (_reloadTimer > _fireRate)
            {
                //shootSound.Play();

                int rand = Random.Range(0, _fireEffects.Length);

                _renders[rand].enabled = true;

                RaycastHit hit;
                Ray ray = new Ray(_fireEffects[rand].position, obj.position);
                Physics.Raycast(ray, out hit);

                if (hit.transform.tag == "Player")
                {
                    obj.GetComponent<ISetDamage>().ApplyDamage(_dmg);

                    Debug.DrawLine(_fireEffects[rand].position, obj.position, Color.red, _dissTime);
                }


                Invoke("EffectOff", _dissTime);

                _reloadTimer = 0;
            }
        }

        void EffectOff()
        {
            foreach (Renderer rend in _renders)
                rend.enabled = false;
        }
    }
}