using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceBatle
{
    /// <summary>
    /// �������� ����������� ������� ����������
    /// </summary>
    public class WeaponReloadModule : AModule
    {
        /// <summary>
        /// ���������� ����������� ������ (�������� ����� �������� ����������� �� 20% - ��������� ��������� �������� 0.8f)
        /// </summary>
        public float ReloadKoefficient;

        public override ItemTypes type => ItemTypes.Modules;

        public override void UpdateBonuses(ref ShipInfo info)
        {
            info.WeaponReloadKoefficient *= ReloadKoefficient;
        }
    }
}