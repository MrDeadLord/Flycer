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

        int rt; // Random tower
        int rp; // Random place

        #endregion ========== Variables ========

        private void Start()
        {
            Spawn(Random.Range(3, _spawnPoints.Count - 1));
        }

        public void Spawn(int count)
        {
            // Allways spawn all buildIn towers
            if (_spawnPointsBuildIn.Count != 0)
            {
                int n = Random.Range(0, _towersBuindIn.Count - 1);

                foreach (var place in _spawnPointsBuildIn)
                {
                    Instantiate(_towersBuindIn[n], place.position, place.rotation);
                }
            }

            // Spawning regular towers            
            List<Transform> exTowers = new List<Transform>();   // List of existing towers

            for (int i = 0; i < count; i++)
            {

                rt = Random.Range(0, _towers.Count - 1);    // Select random tower

                //Searching for NEW position

                do
                    rp = Random.Range(0, _spawnPoints.Count - 1);    // Select random place
                while
                    (exTowers.Contains(_spawnPoints[rp]));

                Instantiate(_towers[rt], _spawnPoints[rp].position, Quaternion.identity);

                exTowers.Add(_spawnPoints[rp]);
            }
        }
    }
}