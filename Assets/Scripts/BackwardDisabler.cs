using UnityEngine;

namespace Flycer
{
    public class BackwardDisabler : MonoBehaviour
    {
        #region ========== Unity-time ========

        private void OnTriggerEnter(Collider coll)
        {
            Debug.Log("Colided with " + coll.name);
            if (coll.tag == "Enemy")
                Destroy(coll.gameObject);
        }

        #endregion ========== Unity-time ========
    }
}