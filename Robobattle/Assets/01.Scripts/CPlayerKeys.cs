using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys
{
    public KeyCode LeftWhealUpKey;
    public KeyCode LeftWhealDownKey;
    public KeyCode RightWhealUpKey;
    public KeyCode RightWhealDownKey;
    public KeyCode AttackKey;
}

public class CPlayerKeys : MonoBehaviour
{
    public static PlayerKeys Player1=new PlayerKeys();
    public static PlayerKeys Player2=new PlayerKeys();

    private void Awake()
    {
        Player1.LeftWhealUpKey = KeyCode.A;
        Player1.LeftWhealDownKey = KeyCode.Z;
        Player1.RightWhealUpKey = KeyCode.S;
        Player1.RightWhealDownKey = KeyCode.X;
        Player1.AttackKey = KeyCode.C;

        Player2.LeftWhealUpKey = KeyCode.J;
        Player2.LeftWhealDownKey = KeyCode.M;
        Player2.RightWhealUpKey = KeyCode.K;
        Player2.RightWhealDownKey = KeyCode.Comma;
        Player2.AttackKey = KeyCode.Period;
    }

}
