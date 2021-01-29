using UnityEngine;

namespace Flycer.Interface
{
    /// <summary>
    /// Нанесение урона
    /// </summary>
    public interface ISetDamage
    {
        /// <summary>
        /// Apply damage
        /// </summary>
        /// <param name="damage">How much</param>      
        void ApplyDamage(int damage);
    }
}