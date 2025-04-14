using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 2f;
    public float attackDamage = 0f;
    public float attackRange = 10f;

    public float bulletDamage = 5f;

    private float timer = 0f;

    [SerializeField] protected float attackInterval = 1f;

    protected PlayerRPG player;

    protected NavMeshAgent navAgent; 
        
    [SerializeField] protected List<Transform> patrolPoints = new List<Transform>();
    protected int patrolPointIndex = 0;
    protected float visionRange = 10f; 

    public bool playerSeen = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRPG>();
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(patrolPoints[patrolPointIndex].position);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
        if (playerSeen == true)
        {
            if (navAgent.remainingDistance < 0.5f) //player in LOS and in visionRange 
            {
                if (Vector3.Distance(this.transform.position, player.transform.position) > visionRange)
                {
                    playerSeen = false;
                }
                else
                {
                    if (LineOfSight() == true)
                    {
                        navAgent.SetDestination(player.transform.position);
                        navAgent.isStopped = false;
                    }
                    else
                    {
                        playerSeen = false;
                    }
                }
            }

            if (Vector3.Distance(this.transform.position, player.transform.position) > attackRange) //player in LOS and in atkRange
            {
                if (LineOfSight() == true)
                {
                    navAgent.SetDestination(player.transform.position);
                    navAgent.isStopped = false;
                }
            }
            else
            {
                if (LineOfSight() == true)
                {
                    navAgent.isStopped = true;
                    this.transform.LookAt(player.transform.position);
                    navAgent.stoppingDistance = 5f;

                    timer += Time.deltaTime;

                    if (timer >= attackInterval)
                    {
                        Attack();
                        timer = 0f;
                    }
                }
                else
                {
                    navAgent.isStopped = false;
                }
            }
        }
        else
        {
            PatrolPointCounter();
            navAgent.SetDestination(patrolPoints[patrolPointIndex].position);
        }
       
    }

    public void SeePLayer()
    {
        RaycastHit hit;

        Vector3 dir = player.transform.position - this.transform.position;
        dir.Normalize();

        if (Physics.Raycast(this.transform.position, dir, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                playerSeen = true;
            }
        }
    }

    protected virtual void PatrolPointCounter()
    {
        if (navAgent.remainingDistance < 0.5f)
        {
            patrolPointIndex++;

            if (patrolPointIndex >= patrolPoints.Count)
            {
                patrolPointIndex = 0;
            }
        }
    }

    protected bool LineOfSight()
    {
        //raycast bool for enemy LOS 
        
        RaycastHit hit;

        Vector3 dir = player.transform.position - this.transform.position;
        dir.Normalize();

        if(Physics.Raycast (this.transform.position, dir, out hit))
        {
            if(hit.collider.tag == "Player")
            {
                return true;
            }
        }

        return false;
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(bulletDamage);
        }
    }

    public virtual void Attack()
    {
        player.TakeDamage(attackDamage);
    }

    public virtual void Move()
    {
        
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        this.transform.LookAt(player.transform.position);

        if(health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
