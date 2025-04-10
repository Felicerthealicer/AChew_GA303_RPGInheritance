using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 3f;
    public float attackDamage = 0f;
    public float attackRange = 10f;

    public float bulletDamage = 5f;

    private float timer = 0f;

    [SerializeField] protected float attackInterval = 1f;

    protected PlayerRPG player;

    protected NavMeshAgent navAgent; 
        
    [SerializeField] protected List<Transform> patrolPoints = new List<Transform>();
    protected int patrolPointIndex = 0;

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
        
        if (Vector3.Distance(this.transform.position, player.transform.position) < attackRange)
        {
            timer += Time.deltaTime;

            if (timer >= attackInterval)
            {
                Attack();
                timer = 0f;
            }
        }
    }

    protected void PatrolPointReset()
    {
        patrolPointIndex++;
    }

    private void OnCollisionEnter(Collision other)
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

        if(health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
