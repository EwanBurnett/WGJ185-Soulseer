using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float speed; //The player's current speed
    public float attack; //The player's current attack power
    public float attackRange; //How far away the player can attack.
    public float spirit; //The player's current spirit gauge
    public float spirit_MAX; //The player's maximum spirit gauge
    public LayerMask filter;

    private Rigidbody2D rb;
    private Vector2 velocity;
    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per framess
    void Update()
    {
        velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(velocity);
        //Debug.Log(velocity);

        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }

    void Move(Vector2 dir)
    {
        Vector2 mov = (dir * speed * Time.deltaTime);
        transform.position += new Vector3(mov.x, mov.y);
    }

    void Attack()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(pos, velocity, attackRange, filter);

        //Debug
        //Debug.DrawLine(pos, (pos + velocity * attackRange), Color.green);

        //Debug.Log(hit.transform.gameObject.name);
        if (hit.collider != null)
        {
           

            if (hit.collider.CompareTag("Enemy")) //If an enemy is hit
            {
                hit.collider.gameObject.SetActive(false); //Debug
                //Debug.Log("Enemy Hit!");
            }
        }
        
    }

 


}
