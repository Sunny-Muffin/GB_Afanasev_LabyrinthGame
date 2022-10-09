using System;
using System.Collections;
using UnityEngine;

namespace Labyrinth
{
    public class Mine : InteractiveObject
    {
        public delegate void CaughtPlayerChange(); // ��� �������, ������� ����� ������ ����� ��������������� � ������� 
        public CaughtPlayerChange CaughtPlayer; // � ��� ��������� ��������

        protected override void Interaction(Player player)
        {
            base.Interaction(player);
            try
            {
                CaughtPlayer?.Invoke(); // � ��� ��� ���������� ��� ����� �������, � ������� � �������� ������� (��� ��� ��������)
                // ���� ������������ ���� "?" �� ����� ��� try catch, �� � ������� ��� �������
            }
            catch (Exception ex)
            {
                Debug.Log("Caught exception: " + ex);
            }
            Destroy(player.gameObject);
        }
    }
}
