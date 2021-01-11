using UnityEngine;
using Flycer.Helpers;

namespace Flycer.Controllers
{
    public class CameraControl : MonoBehaviour
    {
        #region =====Variables=====
        [SerializeField] [Tooltip("Max rotation Z of the camera")] int _maxRotZ = 30;
        [SerializeField] [Tooltip("Max rotation X of the camera")] int _maxRotX = 30;
        [SerializeField] [Tooltip("Mouse sensitivity")] float _mouseSens = 1;


        float _mouseX, _mouseY;
        float _rotZ = 0, _rotX = 0;
        #endregion =====Variables=====

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _mouseX = Input.GetAxis(Controls.MouseX.ToString()) * _mouseSens;   //Left & right
            _mouseY = Input.GetAxis(Controls.MouseY.ToString()) * _mouseSens;   //Forward & backward

            _rotZ = Mathf.Clamp(_mouseX, -_maxRotZ, _maxRotZ);
            _rotX = Mathf.Clamp(_mouseY, -_maxRotX, _maxRotX);

            //transform.localRotation = Quaternion.Euler(_rotX, 0, _rotZ);

            while (transform.rotation.z >= -_maxRotZ || transform.rotation.z <= _maxRotZ)
            {
                transform.Rotate(Vector3.forward, _rotZ);
            }
            
            transform.Rotate(Vector3.right, _rotX);
        }
    }
}