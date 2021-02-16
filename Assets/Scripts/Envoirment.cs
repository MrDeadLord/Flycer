using UnityEngine;

namespace Flycer
{
	public class Envoirment : MonoBehaviour
	{
		#region ========== Variables ========

		[SerializeField] Transform _player;

        #endregion ========== Variables ========

        #region ========== Unity-time ========

        private void OnCollisionEnter(Collision coll)
        {
            if(coll.transform.tag == "Player")
            {
                
            }
        }

        #endregion ========== Unity-time ========

        #region ========== Methods ========
        #endregion ========== Methods ========

        #region ========== Publics ========
        #endregion ========== Publics ========
    }
}