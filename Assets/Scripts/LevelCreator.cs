using System.Collections.Generic;
using UnityEngine;

namespace Flycer
{
    public class LevelCreator : MonoBehaviour
    {
        #region ========== Variables ========

        [SerializeField] [Tooltip("Levels prefabs(plates/terrains)")] List<GameObject> _levelParts = new List<GameObject>();
        [Space(10)]
        [SerializeField] [Tooltip("Level's lenght for placing them correctly")] int _lenght = 240;

        List<int> _existings = new List<int>();  //Existing plate's ids
        int n;  //id of random plate

        #endregion ========== Variables ========

        public void Create(int count)
        {
            n = Random.Range(0, _levelParts.Count); //Generating first

            for (int i = 0; i < count; i++)
            {
                //Continue generating n if it's exists
                while (_existings.Contains(n))
                    n = Random.Range(0, _levelParts.Count);

                _existings.Add(n);

                Instantiate(_levelParts[i], new Vector3(0, 0, _lenght * i), Quaternion.identity);
            }
        }
    }
}