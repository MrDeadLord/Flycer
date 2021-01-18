using UnityEngine;
using UnityEngine.UI;
using Flycer.Helpers;

namespace Flycer.Controllers
{
    public class InputController : MonoBehaviour
    {
        #region ==========Variables========
        [SerializeField] Canvas _mainCanv;
        [SerializeField] Canvas _pauseCanv;

        [Space(10)]
        [Header("Stuff to stop")]
        [SerializeField] MovingForward _mf;
        [SerializeField] MovingForward _limiters;
        [SerializeField] Movement _movm;
        [SerializeField] Shooting _shot;
        [SerializeField] GameObject _enemys;

        [Space(10)]
        [Header("Buttons")]
        [SerializeField] Button _resume;

        bool _paused = false;
        #endregion ==========Variables========

        #region ==========Unity-time========

        private void Start()
        {
            _pauseCanv.enabled = false;
        }

        private void Update()
        {
            if (!_paused)
            {
                if (Input.GetButtonDown(Controls.Pause.ToString()))
                    Pause();
            }
            else
            {
                if (Input.GetButtonDown(Controls.Pause.ToString()))
                    Resume();
            }

            _resume.onClick.AddListener(Resume);
        }
        #endregion ==========Unity-time========

        public void Pause()
        {
            //Disabeling controls and moving parts
            _mf.Off();
            _limiters.Off();
            _movm.Off();
            _shot.Off();

            foreach(var en in _enemys.GetComponentsInChildren<Tower_Fire>())
            {
                en.Off();
            }

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            _mainCanv.enabled = false;
            _pauseCanv.enabled = true;

            _paused = true;
        }

        void Resume()
        {
            //Enabling controls and moving parts
            _mf.On();
            _limiters.On();
            _movm.On();
            _shot.On();

            foreach (var en in _enemys.GetComponentsInChildren<Tower_Fire>())
            {
                en.On();
            }

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            _mainCanv.enabled = true;
            _pauseCanv.enabled = false;

            _paused = false;
        }
    }
}