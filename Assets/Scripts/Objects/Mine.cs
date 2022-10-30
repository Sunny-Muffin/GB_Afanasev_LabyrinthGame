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

        [SerializeField, Range(0, 1)] private float cameraShakeTime = .4f;
        [SerializeField, Range(0, 2)] private float cameraShakeMagnitude = 1f;

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
