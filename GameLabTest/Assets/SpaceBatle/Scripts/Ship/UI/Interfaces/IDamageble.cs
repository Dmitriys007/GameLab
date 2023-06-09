using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    /// <summary>
    /// Объект может получать урон
    /// </summary>
    public interface IDamageble
    {
        /// <summary>
        /// Нанести урон объекту
        /// </summary>
        /// <param name="damag"></param>
        public void SetDamage(float damag);
    }
}