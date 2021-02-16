using UnityEngine;
using Flycer.Helpers;

namespace Flycer.Controllers
{
    public class MovementPhysics : BaseController
    {
        #region ========== Variables ========

        [SerializeField] [Tooltip("Forward moving speed")] [Range(0, 0.5f)] float _forSpeed = 0.1f;
        
        [Header("Slide setup")]
        [SerializeField] [Tooltip("Max slide Left/right distance")] float _maxSlideX = 100;
        [SerializeField] [Tooltip("Max forward slide distance")] float _maxSlideZ = 200;
        [SerializeField] [Tooltip("Min backward slide distance")] float _minSlideZ = 0;

        [Header("Hight level setup")]
        [SerializeField] [Tooltip("Up and down Y heights")] int _heightStep = 20;
        [SerializeField] [Tooltip("How many hight levels we have")] [Range(1, 4)] int _hightsCount = 2;

        /// <summary>
        /// Movement/slide speed
        /// </summary>
        public float speed { get; set; }

        Transform _cam; //Main camera
        Rigidbody _rigBody;
        float _slideX = 0;
        float _slideZ = 0;
        int i = 0;  //Counter for heights

        #endregion ========== Variables ========

        #region ========== Unity-time ========

        private void Start()
        {
            base.OnPause();
            base.On();

            _rigBody = GetComponent<Rigidbody>();

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

            if (Input.GetButtonDown(Controls.ChangePosition.ToString()))
                HeightChange();
        }

        private void OnCollisionExit(Collision collision)
        {
            //Stopping from inertia after hiting any object
            _rigBody.velocity = Vector3.zero;
        }

        #endregion ========== Unity-time ========

        #region ========== Methods ========

        void Moving()
        {
            //Getting input
            _slideX = Input.GetAxis("Horizontal");
            _slideZ = Input.GetAxis("Vertical");

            Vector3 velocity = new Vector3(_slideX, 0, _slideZ);

            //Convert to final position
            Vector3 finalPos = _rigBody.position + velocity * speed * Time.deltaTime;

            //Moving forward
            _minSlideZ += _forSpeed;
            _maxSlideZ += _forSpeed;

            //Moving camera
            _cam.position += new Vector3(0, 0, _forSpeed);

            //Limiting movement
            finalPos.x = Mathf.Clamp(finalPos.x, -_maxSlideX, _maxSlideX);
            finalPos.z = Mathf.Clamp(finalPos.z, _minSlideZ, _maxSlideZ);

            //Move the object
            _rigBody.MovePosition(finalPos);
        }

        void HeightChange()
        {
            transform.position += new Vector3(0, _heightStep, 0);
            _cam.position += new Vector3(0, _heightStep, 0);

            i++;

            if (i == _hightsCount - 1)
            {
                i = 0;
                _heightStep = -_heightStep;
            }
        }

        #endregion ========== Methods ========
    }
}