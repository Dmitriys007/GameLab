using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    [System.Serializable]
    public struct ShipInfo
    {
        /// <summary>
        /// ������� ���������
        /// </summary>
        public float HP;

        /// <summary>
        /// ������������ ���������
        /// </summary>
        public float MaxHP;

        /// <summary>
        /// ������� ���
        /// </summary>
        public float Shield;

        /// <summary>
        /// ������������ ���
        /// </summary>
        public float MaxShield;

        /// <summary>
        /// ����� ��� ������
        /// </summary>
        public int WeaponSlot;

        /// <summary>
        /// ����� ��� ������
        /// </summary>
        public int ModuleSlot;

        /// <summary>
        /// ����������� ����������� ������
        /// </summary>
        public float WeaponReloadKoefficient;

        /// <summary>
        /// ����������� ����������� ����
        /// </summary>
        public float ShieldReloadKoefficient;
    }
}