using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explode : MonoBehaviour
{
    [SerializeField] private float delay = 5f;
    float countdown;
    bool isStarted = false;

    public GameObject explosionEffect;
    public Animation buttonDown;

    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            countdown -= Time.deltaTime;
            Debug.Log(countdown);
            if (countdown <= 0f && isStarted)
            {
                Explosion();
                isStarted = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isStarted = true;   
        Debug.Log("Countdown Started");
        buttonDown.Play();
        
    }
    
    private void Explosion()
    {
        Debug.Log("Boooom ! TESTE COMPLETO !!! ");
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Invoke("ResetGame", 2f);
               
    }

    private void ResetGame()
    {
        Debug.Log("Reset");
        SceneManager.LoadScene("Retry");
    }
}
