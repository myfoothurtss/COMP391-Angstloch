using Mono.Cecil.Cil;
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

    public Animator anim;
    public float hf = 0.0f;
    public float vf = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 1;
        rBody = GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement;
        float verticalMovement;
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");


        Vector2 newVelocity = new Vector2(horizontalMovement, verticalMovement);
        rBody.velocity = newVelocity * playerSpeed;

        hf = horizontalMovement > 0.01f ? horizontalMovement : horizontalMovement < -0.01f ? 1 : 0;
        vf = verticalMovement > 0.01f ? verticalMovement : verticalMovement < -0.01f ? 1 : 0;
        if (horizontalMovement < -0.01f)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Horizontal", hf);
        anim.SetFloat("Vertical", verticalMovement);
        anim.SetFloat("Movement", vf);
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetAxis("Fire1") > 0 && timer > fireRate)
            {
                anim.SetBool("SwordSwing", true);
                //GameObject.instantiate();
                GameObject goObj;
                goObj = Instantiate(swordSwing, swordSwingSpawn.transform.position, swordSwingSpawn.transform.rotation);
                goObj.transform.Rotate(new Vector3(0, 0, 90));
                Destroy(goObj, 1);
                timer = 0;
            }
            else
            {
                anim.SetBool("SwordSwing", false);
            }
            timer += Time.deltaTime;
        }
}

