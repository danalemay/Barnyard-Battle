using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWInputPoller : InputPoller {

    public override InputState GetPlayer1Input()
    {
        InputState IS = InputState.GetBlankState();
        IS.AddAxis("Horizontal", Input.GetAxis("Horizontal"));
        IS.AddAxis("Vertical", Input.GetAxis("Vertical"));
        IS.AddButton("Fire1", Input.GetButtonDown("Fire1"));
        IS.AddButton("Fire2", Input.GetButtonDown("Fire2"));
        IS.AddButton("Fire3", Input.GetButtonDown("Fire3"));
        IS.AddButton("Fire4", Input.GetButtonDown("Fire4"));
        return IS;
    }

    public override InputState GetPlayer2Input()
    {
        InputState IS = InputState.GetBlankState();
        IS.AddAxis("Horizontal", Input.GetAxis("P2Horizontal"));
        IS.AddAxis("Vertical", Input.GetAxis("P2Vertical"));
        IS.AddButton("Fire1", Input.GetButtonDown("P2Fire1"));
        IS.AddButton("Fire2", Input.GetButtonDown("P2Fire2"));
        IS.AddButton("Fire3", Input.GetButtonDown("P2Fire3"));
        IS.AddButton("Fire4", Input.GetButtonDown("P2Fire4"));
        return IS;
    }
}
