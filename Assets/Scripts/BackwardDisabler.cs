using UnityEngine;

namespace Flycer
{
    public class BackwardDisabler : MonoBehaviour
    {
        #region ========== Unity-time ========

        private void OnTriggerEnter(Collider coll)
        {
            if (coll.tag == "Enemy")
                Destroy(coll.gameObject);
        }

        #endregion ========== Unity-time ========
    }
}