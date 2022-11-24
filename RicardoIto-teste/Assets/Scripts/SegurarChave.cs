using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegurarChave : MonoBehaviour
{
    public GameObject keyObject;
    private List<Chave.KeyType> keyList;
    public Vector3 transformOffset;
    

    private void Awake()
    {
        keyList = new List<Chave.KeyType>();
    }

    public void AddKey(Chave.KeyType keyType)
    {
        Debug.Log("Voce pegou a chave : " + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Chave.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Chave.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter(Collider other)
    {
        Chave key = other.GetComponent<Chave>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            
        }  
        
    }

   
}
