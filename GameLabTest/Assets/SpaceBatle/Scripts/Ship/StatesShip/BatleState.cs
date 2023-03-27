using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    public class BatleState : IState, IFixedUpdateble, IEnterState
    {
        /// <summary>
        /// Корабль которым управляем
        /// </summary>
        private Ship ship;


        void IFixedUpdateble.FixedUpdate()
        {
            WeaponModule[] weapons = ship.weaponsList as WeaponModule[];
            for (var i = 0; i < weapons.Length; i++)
                if (weapons[i] != null)
                    if (weapons[i].Fire(ship.target))
                        ship.PlayFireSound();

        }

        void IEnterState.OnEnter(IStateParent parrent)
        {
            ship = parrent as Ship;
        }
    }
}