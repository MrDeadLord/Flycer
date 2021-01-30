using UnityEngine;
using Flycer.Helpers;

namespace Flycer.Controllers
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : BaseController
    {
        #region ==========Variables========        
        [SerializeField] [Tooltip("Normal speed")] float _speed = 10;

        [Space(10)]
        [SerializeField] [Tooltip("Main camera")] Transform _cam;   //need to change hight of the camera. ВРЕМЕННО
        [SerializeField] [Tooltip("Up and down Y heights")] int _heightStep = 10;
        [SerializeField] [Tooltip("How many hight levels we have")] [Range(1, 4)] int _hightsCount = 2;

        Rigidbody _rigBody;
        int i = 0;  //Counter for heights
        #endregion ==========Variables========

        #region ==========Unity-time========
        private void Start()
        {
            _rigBody = GetComponent<Rigidbody>();
            base.On();  //ВРЕМЕННО

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (!Enabled)
                return;

            Moving();
        }
        #endregion ==========Unity-time========

        void Moving()
        {
            float x = Input.GetAxis(Controls.Horizontal.ToString());
            float z = Input.GetAxis(Controls.Vertical.ToString());

            Vector3 velocity = new Vector3(x, 0, z);
            
            _rigBody.MovePosition(_rigBody.position + velocity * _speed * Time.deltaTime);

            if (Input.GetButtonDown(Controls.ChangePosition.ToString()))
            {
                transform.position = transform.position + new Vector3(0, _heightStep, 0);
                _cam.position = _cam.position + new Vector3(0, _heightStep, 0);
                
                i++;

                if (i == _hightsCount - 1)
                {
                    i = 0;
                    _heightStep = -_heightStep;
                }                    
            }
        }
    }
}