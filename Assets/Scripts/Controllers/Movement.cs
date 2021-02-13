using UnityEngine;
using Flycer.Helpers;

namespace Flycer.Controllers
{
    public class Movement : BaseController
    {
        #region ========== Variables ========

        [SerializeField] [Tooltip("Forward moving speed")] [Range(0, 0.5f)] float _forSpeed = 0.1f;
        [Space(5)]
        [SerializeField] [Tooltip("Max slide Left/right distance")] float _maxSlideX = 10;
        [SerializeField] [Tooltip("Max forward slide distance")] float _maxSlideZ = 10;
        [SerializeField] [Tooltip("Min backward slide distance")] float _minSlideZ = 0;
        [Header("Hight level setup")]
        [SerializeField] [Tooltip("Up and down Y heights")] int _heightStep = 20;
        [SerializeField] [Tooltip("How many hight levels we have")] [Range(1, 4)] int _hightsCount = 2;

        public float speed { get; set; }

        Transform _cam; //Main camera
        Vector3 _curPos;
        float _slideX = 0;
        float _slideZ = 0;
        int i = 0;  //Counter for heights

        #endregion ========== Variables ========

        #region ========== Unity-time ========

        private void Start()
        {
            base.OnPause();
            base.On();
            _curPos = transform.position;

            _cam = Camera.main.transform;

            //Debugging
            if (speed == 0)
                Debug.LogError("Speed is zero!");
        }

        private void Update()
        {
            if (!Enabled)
                return;

            Moving();
        }

        #endregion ========== Unity-time ========

        #region ========== Methods ========

        void Moving()
        {
            _slideX = Input.GetAxis("Horizontal") * speed;
            _slideZ = Input.GetAxis("Vertical") * speed;

            _curPos.x += _slideX * Time.deltaTime;
            _curPos.z += _slideZ * Time.deltaTime;

            //Moving forward
            _forSpeed += 0.01f * Time.deltaTime;

            _minSlideZ += _forSpeed;
            _maxSlideZ += _forSpeed;

            //Applying movement to _curPos
            _curPos.x = Mathf.Clamp(_curPos.x, -_maxSlideX, _maxSlideX);
            _curPos.z = Mathf.Clamp(_curPos.z, _minSlideZ, _maxSlideZ);

            //Moving camera
            _cam.transform.position += new Vector3(0, 0, _forSpeed);

            //Change the height
            if (Input.GetButtonDown(Controls.ChangePosition.ToString()))
            {
                _curPos += new Vector3(0, _heightStep, 0);
                _cam.position += new Vector3(0, _heightStep, 0);

                i++;

                if (i == _hightsCount - 1)
                {
                    i = 0;
                    _heightStep = -_heightStep;
                }
            }

            //Applyig all movement to an object
            transform.position = _curPos;
        }

        #endregion ========== Methods ========
    }
}