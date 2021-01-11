using System.Collections.Generic;
using UnityEngine;

namespace Flycer
{
    public class LevelCreator : MonoBehaviour
    {
        [SerializeField] [Tooltip("Levels prefabs(plates/terrains)")] List<GameObject> _levelParts = new List<GameObject>();
        [SerializeField] [Tooltip("Level lenght for placing them correctly")] int _lenght = 240;

        List<int> _existings = new List<int>();  //Existing plate's ids
        int n;  //id of random plate

        public void Create(int count)
        {
            n = Random.Range(0, _levelParts.Count); //Generating first

            for (int i = 0; i < count; i++)
            {
                while (_existings.Contains(n))
                {
                    n = Random.Range(0, _levelParts.Count);
                }

                _existings.Add(n);

                Instantiate(_levelParts[i], new Vector3(0, 0, _lenght*i), Quaternion.identity);
            }
        }
    }
}