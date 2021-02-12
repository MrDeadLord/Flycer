using UnityEngine;
using UnityEngine.UI;
using Flycer.Helpers;
using System.Collections.Generic;

namespace Flycer.Controllers
{
    public class InputController : MonoBehaviour
    {
        #region ========== Variables ========
        [SerializeField] Canvas _mainCanv;
        [SerializeField] Canvas _pauseCanv;
                        
        [Header("Buttons")]
        [SerializeField] Button _resume;

        /// <summary>
        /// Stuff to stop on pause
        /// </summary>
        public List<BaseController> disablingComp = new List<BaseController>();

        bool _paused = false;
        #endregion ========== Variables ========

        #region ========== Unity-time ========

        private void Start()
        {
            _pauseCanv.enabled = false;

            _resume.onClick.AddListener(Resume);
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
        }

        #endregion ========== Unity-time ========

        public void Pause()
        {
            //Disabeling controls and moving parts
            foreach (var item in disablingComp)
            {
                item.enabled = false;
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
            foreach (var item in disablingComp)
            {
                item.enabled = true;
            }

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            _mainCanv.enabled = true;
            _pauseCanv.enabled = false;

            _paused = false;
        }

        public List<BaseController> DisablingComp { get { return disablingComp; } }
    }
}