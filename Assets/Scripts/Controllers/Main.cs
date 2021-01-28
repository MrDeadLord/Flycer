using UnityEngine;
using Flycer.Helpers;

namespace Flycer.Controllers
{
    public class Main : MonoBehaviour
    {
        private void Awake()
        {
            //Disabeling collide shells with game controllers
            Physics.IgnoreLayerCollision(Layers.Shells.GetHashCode(), Layers.GameController.GetHashCode());
        }
    }
}