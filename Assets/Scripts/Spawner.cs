using System.Collections.Generic;
using UnityEngine;

namespace Flycer
{
    public class Spawner : MonoBehaviour
    {
        #region ========== Variables ========
        [SerializeField] [Tooltip("Regular tower spawn positions")] List<Transform> _spawnPoints = new List<Transform>();
        [Space(5)]
        [SerializeField] [Tooltip("BuildIn towers spawn positions")] List<Transform> _spawnPointsBuildIn = new List<Transform>();
        
        [Space(10)]
        [SerializeField] List<GameObject> _towers = new List<GameObject>();
        [Space(5)]
        [SerializeField] List<GameObject> _towersBuindIn = new List<GameObject>();

        public int difficulty { get; set; }
        #endregion ========== Variables ========

        #region ========== Unity-time ========
        private void Start()
        {
            switch (difficulty)
            {
                case 1:
                    Spawn(1);
                    break;
                case 2:
                    Spawn(2);
                    break;
                case 3:
                    Spawn(3);
                    break;
                default:
                    Debug.LogError("That difficulty didn't set yet :(");
                    break;
            }
        }
        #endregion ========== Unity-time ========

        public void Spawn(int count)
        {
            Debug.Log("Spawning " + count);
        }
    }
}