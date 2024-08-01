using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameElement : MonoBehaviour
{
    [SerializeField] protected GameElementType elementType;
    public GameElementType ElementType
    {
        get => elementType;
    }
    public virtual void CheckConnection()
    {

    }
}
