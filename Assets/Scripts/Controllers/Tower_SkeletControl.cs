using UnityEngine;

namespace Flycer.Controllers
{
    /// <summary>
    /// Tower & barrels rotation
    /// </summary>
    public class Tower_SkeletControl : BaseController
    {
        #region ========== Variables ========
        enum axis { x, y, z };

        [SerializeField] axis _rotateAxis = axis.y;
        [SerializeField] [Range(0, 1)] float _rotateSpeed = 0.5f;
        [SerializeField] Transform _barrels;

        int _barSpeed = 2;  //Speed of barrels rotation
        Vector3 rotationBars = Vector3.zero;
        #endregion ========== Variables ========

        #region ========== Unity-time ========

        private void Start()
        {
            base.OnPause();
            base.On();
        }

        private void OnTriggerStay(Collider target)
        {
            if (target.CompareTag("Player"))
            {
                Vector3 dir = target.transform.position - transform.position;   // Direction where to look
                Quaternion lookRot = Quaternion.LookRotation(dir);  // Vector3 => Quaternion                
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRot, _rotateSpeed * Time.deltaTime).eulerAngles; //Smooth rotate speed. Final result
                
                if (_barrels != null)
                    rotationBars = Quaternion.Lerp(_barrels.rotation, lookRot, _barSpeed * Time.deltaTime).eulerAngles;  // Barrels rotation

                //rotate by choosen axis
                switch (_rotateAxis)
                {
                    case axis.x:
                        transform.rotation = Quaternion.Euler(rotation.x, 0, 0);
                        break;
                    case axis.y:
                        transform.rotation = Quaternion.Euler(0, rotation.y, 0);
                        if (_barrels != null)
                            _barrels.rotation = Quaternion.Euler(rotationBars.x, rotation.y, 0);
                        break;
                    case axis.z:
                        transform.rotation = Quaternion.Euler(0, 0, rotation.z);
                        break;
                }
            }
        }
        #endregion ========== Unity-time ========

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