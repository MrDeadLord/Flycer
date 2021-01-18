using UnityEngine;

namespace Flycer
{
    /// <summary>
    /// Tower & barrels rotation
    /// </summary>
    public class Tower_SkeletControl : MonoBehaviour
    {
        #region ==========Variables========
        enum axis { x, y, z };

        [SerializeField] axis _rotateAxis;
        [SerializeField] [Range(0, 1)] float _rotateSpeed = 0.5f;
        [SerializeField] Transform _barrels;

        int _barSpeed = 2;  //Speed of barrels rotation
        #endregion ==========Variables========

        private void OnTriggerStay(Collider target)
        {
            if (target.CompareTag("Player"))
            {
                Vector3 dir = target.transform.position - transform.position;   //direction where to look
                Quaternion lookRot = Quaternion.LookRotation(dir);  //Vector3 => Quaternion
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRot, _rotateSpeed * Time.deltaTime).eulerAngles; //Smooth rotate speed. Final result

                Vector3 rotationBars = Quaternion.Lerp(_barrels.rotation, lookRot, _barSpeed * Time.deltaTime).eulerAngles;  //Barrels rotation
                                                
                //rotate by choosen axis
                switch (_rotateAxis)
                {
                    case axis.x:
                        transform.rotation = Quaternion.Euler(rotation.x, 0, 0);
                        break;
                    case axis.y:                        
                        transform.rotation = Quaternion.Euler(0, rotation.y, 0);
                        _barrels.rotation = Quaternion.Euler(rotationBars.x, rotation.y, 0);
                        break;
                    case axis.z:
                        transform.rotation = Quaternion.Euler(0, 0, rotation.z);
                        break;
                }
            }
        }
    }
}