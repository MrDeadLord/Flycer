using UnityEngine;
using Flycer.Helpers;

namespace Flycer.Controllers
{
    public class Main : MonoBehaviour
    {
        private void Awake()
        {
            Physics.IgnoreLayerCollision(Layers.Enemy.GetHashCode(), Layers.IgnoreRayCast.GetHashCode());
            Physics.IgnoreLayerCollision(Layers.Player.GetHashCode(), Layers.IgnoreRayCast.GetHashCode());
        }
    }
}