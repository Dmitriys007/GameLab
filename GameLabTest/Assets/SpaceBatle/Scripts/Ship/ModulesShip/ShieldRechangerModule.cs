using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    /// <summary>
    /// ���������� ������� ����
    /// </summary>
    public class ShieldRechangerModule : AModule
    {
        /// <summary>
        /// ���������� �� ������� ���������� ����������� ���� (�������� ���� ��������� ����������� �� 20% - ������� ������� �������� 1.2f)
        /// </summary>
        public float BustKoefficient;

        public override ItemTypes type => ItemTypes.Modules;

        public override void UpdateBonuses(ref ShipInfo info)
        {
            info.ShieldReloadKoefficient *= BustKoefficient;
        }
    }
}