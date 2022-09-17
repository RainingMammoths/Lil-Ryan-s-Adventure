using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Enemy_type { Slime, Spider};
public class Enemy_manager : MonoBehaviour
{
    /*[SerializeField] Enemy_type enemy_type;
    [SerializeField] float attack_cooldown_max = 3, attack_cooldown = 0,damage=10;
    [SerializeField] float move_cooldown_max = 3, move_cooldown = 0, movement_speed = 20;
    [SerializeField] SpriteRenderer healh_bar;
    [SerializeField] Transform body;
    float health_points, max_health_points = 100;
    bool isAlive = true, isFollowing;
    GameObject player;
    Rigidbody2D rb;
    [SerializeField] Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        health_points = max_health_points;
        isAlive = true;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (player.GetComponent<Player_manager>().isAlive)
            {
                UpdateMovement();
            }
            else
            {
                UpdateRandomMovement();
            }
        }
    }

    private void FixedUpdate()
    {
        if (attack_cooldown > 0)
        {
            attack_cooldown -= Time.fixedDeltaTime;
        }
        if(move_cooldown > 0)
        {
            move_cooldown -= Time.fixedDeltaTime;
        }
    }

    void UpdateMovement()
    {
        Vector3 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        direction = direction.normalized;
        if (move_cooldown<=0)
        {
            switch (enemy_type)
            {
                case Enemy_type.Slime:
                    {

                        if (distance < 1)
                        {
                            if (attack_cooldown <= 0)
                            {
                                attack_cooldown = attack_cooldown_max;
                                player.GetComponent<Player_manager>().ChangeHealth(-damage);
                            }
                        }
                        else
                        {
                            if (animator != null) animator.SetTrigger("Jump");
                            Vector3 move_vector = direction * movement_speed * Time.deltaTime;
                            rb.AddRelativeForce(move_vector * 1000);
                            //rb.MovePosition(rb.transform.position + move_vector);
                            if (move_vector.x < 0)
                            {
                                body.localScale = new Vector3(-1, 1, 1);
                            }
                            else if (move_vector.x > 0)
                            {
                                body.localScale = new Vector3(1, 1, 1);
                            }
                            move_cooldown = move_cooldown_max;
                        }
                        break;
                    }
                case Enemy_type.Spider:
                    {
                        if (distance < 1.5f)
                        {
                            if (attack_cooldown <= 0)
                            {
                                attack_cooldown = attack_cooldown_max;
                                player.GetComponent<Player_manager>().ChangeHealth(-damage);
                            }
                        }
                        else
                        {
                            //Debug.Log("Spider move");
                            Vector3 move_vector = direction * movement_speed * Time.deltaTime;
                            //rb.AddRelativeForce(move_vector * 1000);
                            rb.MovePosition(rb.transform.position + move_vector);
                            if (move_vector.x < 0)
                            {
                                body.localScale = new Vector3(-1, 1, 1);
                            }
                            else if (move_vector.x > 0)
                            {
                                body.localScale = new Vector3(1, 1, 1);
                            }
                            move_cooldown = move_cooldown_max;
                        }
                        break;
                    }
            }
        }
    }

    void UpdateRandomMovement()
    {
        Vector3 direction;
        Vector3 move_vector;
        if (move_cooldown <= 0)
        {
            switch (enemy_type)
            {
                case Enemy_type.Slime:
                    {
                        if(animator!=null) animator.SetTrigger("Jump");
                        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                        direction = direction.normalized;
                        move_vector = direction * movement_speed * Time.deltaTime;
                        rb.AddRelativeForce(move_vector * 1000);
                        //rb.MovePosition(rb.transform.position + move_vector);
                        if (move_vector.x < 0)
                        {
                            body.localScale = new Vector3(-1, 1, 1);
                        }
                        else if (move_vector.x > 0)
                        {
                            body.localScale = new Vector3(1, 1, 1);
                        }
                        move_cooldown = move_cooldown_max;
                        break;
                    }
                case Enemy_type.Spider:
                    {
                        direction = transform.position - player.transform.position;
                        direction = direction.normalized;
                        move_vector = direction * movement_speed * Time.deltaTime;
                        //rb.AddRelativeForce(move_vector * 1000);
                        rb.MovePosition(rb.transform.position + move_vector);
                        if (move_vector.x < 0)
                        {
                            body.localScale = new Vector3(-1, 1, 1);
                        }
                        else if (move_vector.x > 0)
                        {
                            body.localScale = new Vector3(1, 1, 1);
                        }
                        move_cooldown = move_cooldown_max;
                        break;
                    }
            }
        }
    }

    public void ChangeHealth(float _difference)
    {
        health_points += _difference;
        if (health_points <= 0)
        {
            Die();
            health_points = 0;
        }
        if (health_points > max_health_points)
        {
            health_points = max_health_points;
        }
        healh_bar.size = new Vector2(health_points / 100f, healh_bar.size.y);
    }

    void Die()
    {
        isAlive = false;
        Destroy(gameObject, 1);
    }

    */
}
