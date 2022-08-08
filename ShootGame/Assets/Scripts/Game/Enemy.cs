using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimState
{
    public const string AnimState = "AnimState";
    public const int Idel = 0;
    public const int Move = 1;
    public const int Death = 2;
};
public class Enemy : YLBaseMono
{
    protected NavMeshAgent meshAgent;
    protected Animator animator;
    protected int maxHp;
    protected int currentHp;
    protected int attackValue;
    protected Transform target;
    protected float attackRote;
    protected float lastAttackTime;
    protected bool live = true;
    protected AudioSource audioSource;
    /// <summary>
    /// 怪物价值
    /// </summary>
    protected int coinValue;

    private void Awake()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        target = GameObject.Find("Player").transform;
    }
    protected virtual void Start()
    {
        lastAttackTime = 0;
    }
    protected virtual void Update()
    {
        if (GameManager.Instance.isGameOver == false)
        {
            Move();
            Attack();
            AnimatorState();
        }
        else
        {
            GameOver();
        }
  
    }
    protected virtual void Move()
    {
        if (target==null||meshAgent.enabled==false)
        {
            return;
        }
        transform.forward = new Vector3(target.position.x - transform.position.x,transform.position.y,target.position.z-transform.position.z).normalized;
        meshAgent.SetDestination(target.position);
    }
    /// <summary>
    /// 攻击
    /// </summary>
    protected virtual void Attack()
    {
        if (Vector3.Distance(transform.position, target.position) <= meshAgent.stoppingDistance && live)
        {
            if (lastAttackTime + attackRote < Time.time)
            {
                Player player = target.GetComponent<Player>();
                if (player == null)
                {
                    return;
                }
                player.Hurd(attackValue);
                lastAttackTime = Time.time;
                Debug.Log("攻击玩家");
            }
        }
    }
    /// <summary>
    /// 怪物受到伤害方法
    /// </summary>
    /// <param name="value"></param>
    public virtual void Hurd(int value)
    {
        if (value > 0)
        {
            currentHp -= value;
            if (currentHp <= 0)
            {
                //怪物死亡
                Death();
            }
        }
        YLAudioSourceManager.Instance.Play(audioSource, gameObject.name + "Hurt");
    }

    protected virtual void  Death()
    {
        live = false;
        YLAudioSourceManager.Instance.Play(audioSource, gameObject.name + "Death");
        meshAgent.enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 3);
        target.GetComponent<Player>().AddCoin(coinValue);
    }
    /// <summary>
    /// 怪物动画
    /// </summary>
    protected virtual void AnimatorState()
    {
        if (target == null || target.GetComponent<Player>().GetCurrentHp() <= 0)
        {
            animator.SetInteger(EnemyAnimState.AnimState, EnemyAnimState.Idel);
        }
        else if (currentHp <= 0)
        {
            animator.SetInteger(EnemyAnimState.AnimState, EnemyAnimState.Death);
        }
        else
        {
            animator.SetInteger(EnemyAnimState.AnimState, EnemyAnimState.Move);
        }
    }
    public virtual void GameOver()
    {
        if (GameManager.Instance.isGameOver)
        {
            meshAgent.enabled = false;
        }
    }


}
