using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
public class PlayerManager : MonoBehaviour
{

    [SerializeField] bool isPC;
    [SerializeField] GameObject mapManager;
    MapManager mapManagerScript;

    [SerializeField] MovementComponent _moveScript; 
    [SerializeField] float _speed = 10;

    [SerializeField] int _score;

    //[SerializeField] private GameplayManager _manager;
    //float health_points, max_health_points = 100;
    //public bool isAlive = true;
    //[SerializeField] SpriteRenderer healh_bar;
    //[SerializeField] Transform body, sword_point;
    //Rigidbody2D rb;
    //float sword_damage = 20;
    //[SerializeField] float attack_cooldown_max = 0.5f, attack_cooldown = 0;
    //[SerializeField] LayerMask enemy_layer;
    //Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        mapManagerScript = mapManager.GetComponent<MapManager>();
        //health_points = max_health_points;
        //isAlive = true;
        //rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    public void Score(int value)
    {
        _score += value;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if (isPC)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
            {
                if (mapManagerScript.GetTileData(transform.position + new Vector3(_speed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime, 0, 0)).isWalkable)
                    _moveScript.Move(new Vector2(_speed * Input.GetAxis("Horizontal"), 0f));     
            }
                
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
               if (mapManagerScript.GetTileData(transform.position + new Vector3(0, _speed * Input.GetAxis("Vertical") * Time.fixedDeltaTime, 0)).isWalkable)
                    _moveScript.Move(new Vector2(0f, _speed * Input.GetAxis("Vertical")));
            }
            
        }
        */
    }

    //private void FixedUpdate()
    //{
        /*if(attack_cooldown>0)
        {
           attack_cooldown -= Time.fixedDeltaTime;
        }*/
    //}

    void UpdateNormalMovement()
    {
        //Vector3 move_vector = new Vector3(Input.GetAxis("Horizontal"),  Input.GetAxis("Vertical"), 0);

        //float horizontal_axis = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.5f ? Input.GetAxis("Horizontal") : 0;
        //float vertical_axis = Mathf.Abs(Input.GetAxis("Vertical")) > 0.5f ? Input.GetAxis("Vertical") : 0;

        /*float horizontal_axis, vertical_axis;
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            vertical_axis = Input.GetAxis("Vertical");
        }
        else
        {
            vertical_axis = 0;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            horizontal_axis = Input.GetAxis("Horizontal");
        }
        else
        {
            horizontal_axis = 0;
        }
        */
        //animator.SetBool("IsRunningVertical", vertical_axis == 0 ? false : true);
        //animator.SetBool("IsRunning", horizontal_axis == 0 ? false : true);


       
        /*if(move_vector.x<0)
        {
            body.localScale = new Vector3(-1, 1, 1);
        }
        else if (move_vector.x > 0)
        {
            body.localScale = new Vector3(1, 1, 1);
        }*/
    }

    /*void UpdateAttack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(attack_cooldown<=0)
            {
                Collider2D[] damage = Physics2D.OverlapCircleAll(sword_point.position, 0.3f, enemy_layer);

                for (int i = 0; i < damage.Length; i++)
                {
                    damage[i].GetComponent<Enemy_manager>().ChangeHealth(-sword_damage);
                    if (_manager._abnormality == 4) damage[i].GetComponent<Enemy_manager>().ChangeHealth(-sword_damage); // Damage again
                }

                //attack
                animator.SetTrigger("Attack");
                attack_cooldown = attack_cooldown_max;
            }
        }
    }

    public void ChangeHealth(float _difference)
    {
        if (_manager._abnormality == 4 && _difference < 0) _difference *= 2;

        health_points += _difference;
        if (health_points<=0)
        {
            Die();
            health_points = 0;
        }
        if(health_points > max_health_points)
        {
            health_points = max_health_points;
        }
        healh_bar.size = new Vector2(health_points / 100f,healh_bar.size.y);
    }

    void Die()
    {
        isAlive = false;
        animator.SetTrigger("Death");
    }*/
}
