using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarController : MonoBehaviour
{
    public Chave keyScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, keyContainer;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;
    public bool isEquipped;
    public static bool slotFull;

    private void Start()
    {
        if (!isEquipped)
        {
            keyScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (isEquipped)
        {
            keyScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }

    }

    private void Update()
    {
        // Check proximity, if already holding something, and if 'E' button is pressed to pick up the Key.
        Vector3 distance = player.position - transform.position;
        if (!isEquipped && distance.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();    
        }

        // To drop the Key
        if (isEquipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }


    }

    private void PickUp()
    {
        isEquipped = true;
        slotFull = true;
        

        // Make key a child of the player and move it to the right position
        transform.SetParent(keyContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
                
        rb.isKinematic = true;
        coll.isTrigger = true;

        keyScript.enabled = true;
    }

    private void Drop()
    {
        isEquipped = false;
        slotFull = false;

        // Take out the parent to null
        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        // Adding some momentum and force to drop the key
     
        rb.AddForce(player.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(player.up * dropUpwardForce, ForceMode.Impulse);

        keyScript.enabled = false;
    }
}
