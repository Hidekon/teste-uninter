using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public enum KeyType
    {
        Yellow,
        Blue
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
