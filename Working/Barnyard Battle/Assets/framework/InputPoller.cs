using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPoller : MonoBehaviour {

    protected static InputPoller Self;

    void Awake()
    {
        Self = this; 
    }

    public static InputPoller GetReference()
    {
        return Self; 
    }

    public virtual InputState GetPlayerInput(int PlayerNumber)
    {
        if (PlayerNumber == 0) { return GetPlayer1Input(); }
        if (PlayerNumber == 1) { return GetPlayer2Input(); }
        if (PlayerNumber == 2) { return GetPlayer3Input(); }
        if (PlayerNumber == 3) { return GetPlayer4Input(); }


        // Error Check... What the heck player did you give me?

        return new InputState();
    }

    public virtual InputState GetPlayer1Input()
    {
        InputState IS = InputState.GetBlankState();
        IS.AddAxis("Horizontal", Input.GetAxis("Horizontal"));
        IS.AddAxis("Vertical", Input.GetAxis("Vertical"));
        IS.AddButton("Fire1", Input.GetButton("Fire1"));
        IS.AddButton("Fire2", Input.GetButton("Fire2"));
        IS.AddButton("Fire3", Input.GetButton("Fire3"));
        IS.AddButton("Fire4", Input.GetButton("Fire4"));
        return IS;
    }

    public virtual InputState GetPlayer2Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    public virtual InputState GetPlayer3Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }

    public virtual InputState GetPlayer4Input()
    {
        InputState IS = InputState.GetBlankState();

        return IS;
    }
}
