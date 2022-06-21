//Lisa Fröhlich Gabra, ER, P6, "HEL: The Human Ecosystem Laboratory"

//Trying to figure out how ScriptableObjects work

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ByteReference
{
    public bool UseConstant = true;
    public byte ConstantValue;
    public ByteVariable Variable;

    public int Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }
}
