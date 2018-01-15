using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    public int scanningRange;
    public GameObject player;
    PlayerHealth PlayerHealth;

    /// 調整可攻擊到範圍
    public float offset = 5f;
    /// 移動速度
    //private float transition = 0.0f;

    //敵人動畫
    public Animator target;

    //判斷玩家是否在敵人的攻擊範圍
    public bool playertInRange;

    //敵人攻擊動作計時器
    public float timer;

    //敵人攻擊動作的時間
    public float timeBetweenAttack = 0.5f;

    //敵人攻擊傷害
    public int attackDamage = 10;

    // Use this for initialization
    void Start()
    {
        scanningRange = 10;

        player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = player.GetComponent<PlayerHealth>();
        target = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TarckActor(player.transform.position, transform, scanningRange);
        //使敵人正面朝向主角
        this.target.transform.LookAt(player.transform.position);

        timer += Time.deltaTime;
        if (timer > timeBetweenAttack && playertInRange)
        {
            Attack();
        }
    }
    float GetRadius(Vector3 v1, Vector3 v2)
    {
        //float Result = Mathf.Pow((v1.x - v2.x),2) + Mathf.Pow((v1.y - v2.y),2) + Mathf.Pow((v1.z - v2.z),2);
        float Result = Mathf.Pow((v1.x - v2.x), 2) + Mathf.Pow((v1.z - v2.z), 2);
        return Mathf.Sqrt(Result);
    }
    void TarckActor(Vector3 actor, Transform enemy, float Range)
    {
        float Distance = GetRadius(actor, transform.position);

        if (Distance > Range)//玩家在敵人視野範圍外
        {
            //Debug.Log("Do notthing");
            target.SetBool("walk", false);
            target.SetBool("attack", false);
            return;
        }
        else if(Distance < offset)//玩家在敵人攻擊範圍內
        {
            playertInRange = true;
            target.SetBool("walk", false);
            target.SetBool("attack", true);
        }
        else//玩家在敵人視野範圍內，攻擊範圍外
        {
            target.SetBool("walk", true);
            target.SetBool("attack", false);
            playertInRange = false;
            //Debug.Log("Tracking");

            float x = enemy.position.x;
            float z = enemy.position.z;
            float trackingSpeed = 5f;
            float tx = x + (actor.x - x) * trackingSpeed * Time.deltaTime / Distance;
            float tz = z + (actor.z - z) * trackingSpeed * Time.deltaTime / Distance;
            Vector3 moveVector = new Vector3(tx, enemy.position.y, tz);
            enemy.position = moveVector;
            //enemy.position = Vector3.Lerp(actor, enemy.position, transition);
            //transition += 1 * Time.deltaTime/ trackingSpeed;
        }
    }

    void Attack()
    {
        timer = 0.0f;
        if (PlayerHealth.currentHealth > 0)
        {
            PlayerHealth.TakeDamage(attackDamage);
        }
    }
}
