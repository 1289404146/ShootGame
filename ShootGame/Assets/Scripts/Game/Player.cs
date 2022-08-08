using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家动画状态
/// </summary>
public class PlayerAnimState
{
    public const string AnimState = "AnimState";
    public const int Idel = 0;
    public const int Move = 1;
    public const int Death = 2;
};
public class Player : YLBaseMono
{
    private int SpeedValue;
    private int BloodValue;
    private Transform gunBarreEnd;
    private Animator anim;
    private Light gunlight;
    private LineRenderer gunLineRenderer;
    private Rigidbody rig;
    /// <summary>
    /// 最大血量
    /// </summary>
    private int maxHp = 500;
    /// <summary>
    /// 当前血量
    /// </summary>
    private int currentHp;
    public int GetCurrentHp()
    {
        return currentHp;
    }
     public int Coin { get;private set; }
    private float speed=8;
    private Ray shootRay = new Ray();
    private float shootRange = 100;
    /// <summary>
    /// 发射速率
    /// </summary>
    private float shootRate = 0.15f;
    /// <summary>
    /// 光纤占这个速率的比例
    /// </summary>
    private float delayTime = 0.2f;
    private int attackValue = 10;
    private float timer = 0;
    private AudioSource audioSource;
    private void Awake()
    {
        gunBarreEnd = transform.Find("GunBarrelEnd");
        gunlight = gunBarreEnd.GetComponent<Light>();
        gunLineRenderer = gunBarreEnd.GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        currentHp = maxHp;
        YLUIManager.Instance.GetPanel<GamePanel>().UpdateHp(currentHp, maxHp);
    }
    private void Update()
    {
        if (GameManager.Instance.isGameOver == true)
        {
            return;
        }
        timer += Time.deltaTime;
        Move();
        Turn();
        Shoot();
    }
    public void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 step = new Vector3(h, 0, v);
        step = step.normalized * speed * Time.deltaTime;
        rig.MovePosition(transform.position +step);
        AnimatorState(h,v);
    }
    private void AnimatorState(float horizontal, float vertical)
    {
        if (currentHp <= 0)
        {
            anim.SetInteger(PlayerAnimState.AnimState, PlayerAnimState.Death);
        }
        else if (horizontal != 0f || vertical != 0f)
        {
            anim.SetInteger(PlayerAnimState.AnimState, PlayerAnimState.Move);
        }
        else
        {
            anim.SetInteger(PlayerAnimState.AnimState, PlayerAnimState.Idel);
        }
    }
    private void Turn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, 1 << LayerMask.NameToLayer("Ground")))
        {
            transform.forward = (new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position).normalized;
        }
    }
    private void Shoot()
    {
        if(Input.GetMouseButton(0)&&timer>shootRate)
        {
            timer = 0;
            gunlight.enabled = true;
            gunLineRenderer.enabled = true;shootRay.origin = gunBarreEnd.position;
            shootRay.direction = gunBarreEnd.forward;
            gunLineRenderer.SetPosition(0, gunBarreEnd.position);
            RaycastHit hit;
            if (Physics.Raycast(shootRay, out hit))
            {
                gunLineRenderer.SetPosition(1, hit.point);
                //攻击敌人
                Enemy enemy= hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.Hurd(attackValue);
                }
                //音效
                YLAudioSourceManager.Instance.Play(audioSource, gameObject.name + "GunShot");

            }
            else
            {
                gunLineRenderer.SetPosition(1, shootRay.origin + shootRay.direction * shootRange);
            }
        }
        if (timer > delayTime * shootRate)
        {
            gunLineRenderer.enabled = false;
            gunlight.enabled = false;
        }
    }
    public void Hurd(int value)
    {
        currentHp -= value;
        if (currentHp <= 0)
        {
            //角色播放死亡音效
            YLAudioSourceManager.Instance.Play(audioSource, gameObject.name + "Death");
            //更新UI上的血量
            YLUIManager.Instance.GetPanel<GamePanel>().UpdateHp(currentHp, maxHp);
            currentHp = 0;
            GameManager.Instance.isGameOver = true;

            int ret= YLDataManager.Instance.CaculateReward(Coin);
            YLUIManager.Instance.OpenPanel<OverPanel>().SetRewardText(ret);
            return;
        }
        YLUIManager.Instance.GetPanel<GamePanel>().UpdateHp(currentHp, maxHp);
        //更新血量值
        //播放受伤音效
        YLAudioSourceManager.Instance.Play(audioSource, gameObject.name + "Hurt");
    }
    /// <summary>
    /// 增加金币
    /// </summary>
    /// <param name="value"></param>
    public void AddCoin(int value)
    {
        Coin += value;
        YLUIManager.Instance.GetPanel<GamePanel>().UpdateCoin(Coin);
    }
    public void AddEquip(Equip equip)
    {
        SpeedValue = equip.SpeedValue;
        BloodValue = equip.BloodValue;
        speed += SpeedValue;
        currentHp+=BloodValue;
        if (currentHp >= maxHp)
        {
            currentHp = maxHp;
        }
    }
}
