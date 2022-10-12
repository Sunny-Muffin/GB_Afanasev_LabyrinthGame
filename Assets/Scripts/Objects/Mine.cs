using System;
using System.Collections;
using UnityEngine;

namespace Labyrinth
{
    public class Mine : InteractiveObject
    {
        public delegate void CaughtPlayerChange(); // ��� �������, ������� ����� ������ ����� ��������������� � ������� 
        public CaughtPlayerChange CaughtPlayer; // � ��� ��������� ��������
        public static event ObjectTouched OnTouched; // ��� �������

        [SerializeField] private float cameraShakeTime = .4f;
        [SerializeField] private float cameraShakeMagnitude = 1f;

        protected override void Interaction(Player player)
        {
            base.Interaction(player);
            try
            {
                OnTouched?.Invoke(cameraShakeTime, cameraShakeMagnitude);
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
