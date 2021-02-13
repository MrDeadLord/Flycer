using UnityEngine;
using Flycer.Controllers;

namespace Flycer
{
    public class BackwardDisabler : MonoBehaviour
    {
        #region ========== Unity-time ========

        private void OnTriggerEnter(Collider coll)
        {
            foreach (var item in coll.GetComponentsInChildren<BaseController>())
            {
                item.Off();
            }
        }

        #endregion ========== Unity-time ========
    }
}