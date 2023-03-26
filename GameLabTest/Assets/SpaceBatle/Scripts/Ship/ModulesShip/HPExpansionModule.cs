using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    /// <summary>
    /// ���������� ����� �������
    /// </summary>
    public class HPExpandModule : AModule
    {
        /// <summary>
        /// ����������� ����� ������� �� ��������� ��������
        /// </summary>
        public float BusterHPValue;

        public override ItemTypes type => ItemTypes.Modules;

        public override void UpdateBonuses(ref ShipInfo info)
        {
            info.MaxHP += BusterHPValue;
            info.HP = info.MaxHP;
        }
    }
}