using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputError : MonoBehaviour
{
    private PlayerInput Input;

    private void Start()
    {
        Input = GetComponent<PlayerInput>();
    }

    private void OnDisable()
    {
        Input.actions = null;
    }
}
