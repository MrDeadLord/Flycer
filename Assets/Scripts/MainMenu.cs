using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Flycer
{
	public class MainMenu : MonoBehaviour
	{
		#region ========== Variables ========
		[SerializeField] List<Button> _butts = new List<Button>();
        #endregion ========== Variables ========

        #region ========== Unity-time ========
        private void Start()
        {
            foreach(var butt in _butts)
            {
                switch (butt.name)
                {
                    case "Start":
                        butt.onClick.AddListener(LevelSelect);
                        break;
                    case "Quit":
                        butt.onClick.AddListener(QuitGame);
                        break;
                    case "Back":
                        butt.onClick.AddListener(LevelSelect);
                        break;
                    case "Upgrade":
                        butt.onClick.AddListener(UpgradeMenu);
                        break;
                    case "Settings":
                        butt.onClick.AddListener(Settings);
                        break;
                }
            }
        }
        #endregion ========== Unity-time ========

        #region ========== Methods ========

        void LevelSelect()
        {

        }

        void QuitGame()
        {
            Application.Quit();
        }

        void UpgradeMenu()
        {

        }

        void Settings()
        {

        }

        #endregion ========== Methods ========

        #region ========== Publics ========
        #endregion ========== Publics ========
    }
}