using System.Collections.Generic;
using UnityEngine;

namespace Flycer
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] List<Transform> _spawnPoints = new List<Transform>();
        [SerializeField] List<GameObject> _towers = new List<GameObject>();
        
        int _dificulty = 0;

        private void Start()
        {
            Spawn();
        }

        public void Spawn()
        {

        }
    }
}