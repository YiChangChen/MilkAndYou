using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    public Animator target;
    public GameObject player;
    //PlayerHealth PlayerHealth;

    [System.Serializable]
    public class AttackRange
    {
        [Header("判斷主角是否在攻擊範圍")]
        public bool playertInRange;
    }
    public AttackRange attackRange;

    [Header("視野範圍範圍")]
    public int scanningRange;
    [Header("攻擊範圍")]
    public float offset = 5f;
    /// 移動速度
    //private float transition = 0.0f;


    // Use this for initialization
    void Start()
    {
        scanningRange = 10;

        player = GameObject.FindGameObjectWithTag("Player");
        target = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TarckActor(player.transform.position, transform, scanningRange);
        //使敵人正面朝向主角
        this.target.transform.LookAt(player.transform.position);

        //timer += Time.deltaTime;
        //if (timer > timeBetweenAttack && attackRange.playertInRange)
        //{
        //    Attack();
        //}
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
            return;
        }
        else if(Distance < offset)//玩家在敵人攻擊範圍內
        {
            attackRange.playertInRange = true;
            target.SetBool("walk", false);
        }
        else//玩家在敵人視野範圍內，攻擊範圍外
        {
            target.SetBool("walk", true);
            attackRange.playertInRange = false;
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
}
