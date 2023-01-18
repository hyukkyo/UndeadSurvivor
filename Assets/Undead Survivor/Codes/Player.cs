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
    SpriteRenderer spriter;
    Animator anim;
    public Slider hpBar;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        UpdateHpBar(0, 0);
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

    /*
     * In the lecture3, Lecture02(Moving using the Update function) is used
     * instead of the Lecture02+(New input system).
     */
    // void OnMove(InputValue value) {
    //     inputVec = value.Get<Vector2>();
    // }
}
