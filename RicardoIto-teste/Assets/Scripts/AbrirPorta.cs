using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPorta : MonoBehaviour
{
    public GameObject key;
    public GameObject keyAnimation;

    public Animation openDoor;
    public Animation unlockDoor;
    public PegarController pegarController;

    public float delayTime = 3f;
    
    
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(" Collided ");

        //Check if pressed E and have the key
        if (Input.GetKeyDown(KeyCode.E) && pegarController.isEquipped)
        {
            // Hide for a while the actual key, from de key animation;
            
            key.SetActive(false);
            keyAnimation.SetActive(true);

            //Play animations after delay and show again key
            unlockDoor.Play();
            Invoke("OpenDoor", delayTime);                       
            Invoke("ActivateKey", delayTime);
            Invoke("DisactivateKeyAnimation", delayTime);


            print("PORTA ABERTA "); 


        } 
        else if ( Input.GetKeyDown(KeyCode.E) && !pegarController.isEquipped)
        {
            print("Porta Trancada - Requer Chave");
        }
    }

    void ActivateKey()
    {
        key.SetActive(true);
    }
    void DisactivateKeyAnimation()
    {
        keyAnimation.SetActive(false);
    }
    void OpenDoor()
    {
        openDoor.Play();
    }
}
