﻿using UnityEngine;

namespace Flycer
{
    public class Main : MonoBehaviour
    {
        #region ========== Variables ========
        [SerializeField] [Tooltip("Level lenght")] int _platesCount = 5;
        [SerializeField] [Tooltip("Difficulty")] [Range(1, 5)] int _difLvl = 1;

        LevelCreator _lc;
        #endregion ========== Variables ========

        #region ========== Unity-time ========

        private void Awake()
        {
            _lc = GetComponent<LevelCreator>();

            NewLevel();
        }

        #endregion ========== Unity-time ========

        #region ========== Methods ========
        public void NewLevel()
        {
            _lc.Create(_platesCount, _difLvl);
        }
        #endregion ========== Methods ========

        #region ========== Publics ========
        #endregion ========== Publics ========
    }
}