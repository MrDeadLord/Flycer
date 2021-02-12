using UnityEngine;
using Flycer.Controllers
    ;

namespace Flycer
{
    public class Main : MonoBehaviour
    {
        #region ========== Variables ========

        [SerializeField] [Tooltip("Level lenght")] int _platesCount = 5;
        [SerializeField] [Tooltip("Difficulty")] [Range(1, 5)] int _difLvl = 1;

        [Header("Spawning")]
        [SerializeField] [Tooltip("Player's prefab to spawn")] GameObject _player;
        [SerializeField] Transform _spawnPoint;

        public static Main Instance { get; private set; }

        LevelCreator _lc;
        InputController _ic;

        #endregion ========== Variables ========

        #region ========== Unity-time ========

        private void Awake()
        {
            Instance = this;

            _lc = GetComponent<LevelCreator>();
            _ic = GetComponent<InputController>();

            NewLevel();

            Instantiate(_player, _spawnPoint.position, _spawnPoint.rotation);            
        }

        #endregion ========== Unity-time ========

        #region ========== Methods ========
        public void NewLevel()
        {
            _lc.Create(_platesCount);
        }
        #endregion ========== Methods ========

        #region ========== Publics ========
        public int Difficulty { get { return _difLvl; } }
        public InputController InpContr { get { return _ic; } }
        #endregion ========== Publics ========
    }
}