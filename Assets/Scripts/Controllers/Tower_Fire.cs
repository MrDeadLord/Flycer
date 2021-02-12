using UnityEngine;
using Flycer.Helpers;

namespace Flycer.Controllers
{
    public class Tower_Fire : BaseController
    {
        #region ========== Variables ========

        [Header("Shooting")]
        [SerializeField] [Tooltip("Rate of fire")] float _reloadTime = 1;
        [SerializeField] int _dmg = 5;
        [SerializeField] int _range = 20;
        [SerializeField] Transform[] _spawnPoints;

        [Space(10)]
        [Header("Render part")]
        [SerializeField] Bullet _shell;
        [SerializeField] AudioSource _shootSound;

        //private variables
        float _reloadTimer;

        #endregion ========== Variables ========

        #region ========== Unity-time ==========

        void Start()
        {
            _reloadTimer = _reloadTime;
            _dmg *= Main.Instance.Difficulty;

            base.On();  //ВРЕМЕННО
        }

        private void Update()
        {
            if (Input.GetButtonDown(Controls.Pause.ToString()))
                Switch();
        }

        private void FixedUpdate()
        {
            if (!Enabled)
                return;

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

        #endregion ========== Unity-time ==========

        private void FireUp()
        {
            if (_reloadTimer > _reloadTime)
            {
                //shootSound.Play();    //Sound

                _reloadTimer = 0;   //FireRate control

                foreach (var hole in _spawnPoints)
                {
                    Bullet bulletClone = Instantiate(_shell, hole.position, hole.rotation);

                    bulletClone.Damage = _dmg;
                }
            }
        }

        void Switch()
        {
            if (Enabled)
                Off();
            else
                On();
        }

        public override void Off()
        {
            base.Off();

            GetComponent<Collider>().enabled = false;
        }

        public override void On()
        {
            base.On();

            GetComponent<Collider>().enabled = true;
        }
    }
}