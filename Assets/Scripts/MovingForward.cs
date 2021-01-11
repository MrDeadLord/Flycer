using Flycer.Controllers;
using UnityEngine;

namespace Flycer
{
    /// <summary>
    /// Move GameObject forward with _speed
    /// </summary>
    public class MovingForward : BaseController
    {
        [SerializeField] [Range(0, 1)] float _speed;

        private void Start()
        {
            //ВРЕМЕННО
            base.On();
        }

        private void FixedUpdate()
        {
            if (!Enabled)
                return;

            transform.position += Vector3.forward * _speed;
        }
    }
}