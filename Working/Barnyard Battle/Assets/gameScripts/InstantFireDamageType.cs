using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantFireDamageType : BaseDamageType
{

    public InstantFireDamageType()
    {
        verb = "hits";
        CausedByWorld = true;
    }
}