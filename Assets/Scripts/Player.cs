using UnityEngine;
using Unity.Netcode;
public class Player : NetworkBehaviour
{

    public float speed = 5f;

    void Update()
    {
        if (!IsOwner) return;
        // Get input from arrow keys or WASD
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

        // Move the object
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
