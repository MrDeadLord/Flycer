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

        #endregion ========== Variables ========

        #region ========== Unity-time ========
        private void Awake()
        {
            Spawn(Random.Range(3, _spawnPoints.Count));
        }
        #endregion ========== Unity-time ========

        public void Spawn(int count)
        {
            //Allways spawn all buildIn towers
            int n = Random.Range(0, _towersBuindIn.Count);

            foreach (var place in _spawnPointsBuildIn)
            {
                Instantiate(_towersBuindIn[n], place.position, place.rotation);
            }

            //Spawning regular towers            
            List<Transform> exTowers = new List<Transform>();   //List of existing towers

            for (int i = 0; i < count; i++)
            {

                int rt = Random.Range(0, _towers.Count);    //Select random tower
                int rp = Random.Range(0, _spawnPoints.Count);   //Select random place

                //Searching for NEW position
                while (exTowers.Contains(_spawnPoints[rp]))
                {
                    rp = Random.Range(0, _spawnPoints.Count);
                }                    

                GameObject newTower = Instantiate(_towers[rt], _spawnPoints[rp].position, Quaternion.identity);

                exTowers.Add(newTower.transform);
            }
        }
    }
}