using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float playerSpeed;
    public float minX, maxX, minY, maxY;
    public GameObject swordSwing, swordSwingSpawn;
    public float fireRate = 0.25f;
    public float timer = 0;
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 1;
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement;
        float verticalMovement;
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        Vector2 newVelocity = new Vector2(horizontalMovement, verticalMovement);
        rBody.velocity = newVelocity * playerSpeed;

        Vector2 moveDirection = rBody.velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.x, -moveDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetAxis("Fire1") > 0 && timer > fireRate)
            {
            //GameObject.instantiate();
            GameObject goObj;
            goObj = Instantiate(swordSwing, swordSwingSpawn.transform.position, swordSwingSpawn.transform.rotation);
            goObj.transform.Rotate(new Vector3(0, 0, 90));
            Destroy (goObj, 1);
            timer = 0;
            }
            timer += Time.deltaTime;
        }
        
}

