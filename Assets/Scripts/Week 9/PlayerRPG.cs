using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRPG : MonoBehaviour
{
    public float health = 100f;
    public float attackDamage = 10f;
    public float attackInterval = 1f;
    

    private float timer;
    private bool isAttackReady = true;

    public Image attackReadyImage;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackDmgText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttackReady == false)
        {
            timer += Time.deltaTime;

            if (timer >= attackInterval)
            {
                isAttackReady = true;
                attackReadyImage.gameObject.SetActive(isAttackReady);
                timer = 0f;
            }
        }
        

        if(Input.GetMouseButtonDown(0))
        {
            if(isAttackReady == true)
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3f))
                {
                    BaseEnemy enemy = hit.collider.GetComponent<BaseEnemy>();

                    if (enemy != null)
                    {
                        Attack(enemy);
                    }
                }
            }

            healthText.text = health.ToString();
            attackDmgText.text = "AtkDmg: " + attackDamage.ToString();   

        }
    }

    public void Attack(BaseEnemy enemy)
    {
        enemy.TakeDamage(attackDamage);
        isAttackReady = false;
        attackReadyImage.gameObject.SetActive(isAttackReady);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;


        if (health <= 0)
        {
            Debug.Log("YOU DIED");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "VisionCone")
        {
            other.GetComponentInParent<BaseEnemy>().SeePLayer();
        }
    }

}
