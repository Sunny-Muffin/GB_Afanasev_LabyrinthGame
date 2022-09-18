using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    private int a = 0;
    private int b = 1;

    private string aa = "null";
    private string bb = "one";

    void Start()
    {
        Print(ref a, ref b);
        Print(ref aa, ref bb);

        SwapInt(ref a, ref b);
        Swap(ref aa, ref bb);

        Print(ref a, ref b);
        Print(ref aa, ref bb);
    }

    // seems like swaping without temporary variable doesn't work, if you use generic variables "T"
    private void Swap<T>(ref T A, ref T B)
    {
        T temp = A;
        A = B;
        B = temp;
    }

    private void SwapInt(ref int A, ref int B)
    {
        A = A - B;
        B = A + B;
        A = -A + B;
    }

    private void Print<T>(ref T A, ref T B)
    {
        Log($"A = {A}, B = {B}");
    }
}
