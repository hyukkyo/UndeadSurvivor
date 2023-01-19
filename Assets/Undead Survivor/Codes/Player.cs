using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

    private int DAMAGE = 0;
    private int HEAL = 1;

    public Vector2 inputVec;
    public float speed;
    public float curHp = 100;
    public float maxHp = 100;

    Rigidbody2D rigid;
    public SpriteRenderer spriter;
    Animator anim;
    public Slider hpBar;

    public GameObject bulletObj0;
    public GameObject bulletObj3;
    public int[] WeaponLevel= { 0, 0, 0, 1, 0, 0 };
    public float[] WeaponTimer = { 0, 0, 0, 0, 0, 0 };

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        UpdateHpBar(0, 0);
        if(WeaponLevel[3]!=0)
            Fire3();
    }

    void FixedUpdate() {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }

    void UpdateHpBar(int type, int value_)
    {
        hpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -0.8f, 0));
        if (type == DAMAGE) {
            curHp -= value_;
            hpBar.value = curHp / maxHp;
        }
        else if (type == HEAL) {
            curHp += value_;
            hpBar.value = curHp / maxHp;
        }
    }

    void OnCollisionEnter(Collider other) {
        UpdateHpBar(DAMAGE, 3);
    }

    void LateUpdate() {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0;
        }
    }
    Vector3 nearestEnemyDirection()
    {
        float nearestEnemyDistance=Mathf.Infinity;
        Vector3 nearestEnemyDirection=Vector3.up;
        for (int i=0; i<3;i++)  //enemy => index 0~2 bullet => index 3
        {
            for (int j = 0; j < GameManager.instance.pool.pools[i].Count; j++)
            {
                if (GameManager.instance.pool.pools[i][j].activeSelf == true)
                {
                    float playerToEnemy = Vector3.Distance(transform.position, GameManager.instance.pool.pools[i][j].transform.position);
                    if (nearestEnemyDistance > playerToEnemy)
                    {
                        nearestEnemyDistance = playerToEnemy;
                        nearestEnemyDirection = (GameManager.instance.pool.pools[i][j].transform.position - transform.position) / playerToEnemy;
                    }
                }
            }
        }
        return nearestEnemyDirection;
    }
    void Fire3()
    {
        WeaponTimer[3] += Time.deltaTime;

        if (WeaponTimer[3] > 0.3/WeaponLevel[3])
        {
            WeaponTimer[3] = 0;
            Vector3 FireDirection = nearestEnemyDirection();
            GameObject bullet = GameManager.instance.pool.Get(3);
            bullet.transform.position = transform.position;
            if (FireDirection.x >= 0)
            {
                bullet.transform.localEulerAngles = new Vector3(0, 0, -180 * Mathf.Acos(FireDirection.y) / Mathf.PI);
            }
            else
            {
                bullet.transform.localEulerAngles = new Vector3(0, 0, 180 * Mathf.Acos(FireDirection.y) / Mathf.PI);
            }
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(FireDirection * 10, ForceMode2D.Impulse);
        }

    }
    /*
     * In the lecture3, Lecture02(Moving using the Update function) is used
     * instead of the Lecture02+(New input system).
     */
    // void OnMove(InputValue value) {
    //     inputVec = value.Get<Vector2>();
    // }
}
