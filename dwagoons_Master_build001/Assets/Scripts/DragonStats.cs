using UnityEngine;
using System.Collections;
using InControl;

using Image = UnityEngine.UI.Image;

public class DragonStats : MonoBehaviour {

    int playerIndex;

    public float maxHealth = 100;
    public float currentHealth;
    public float healthBarSize = 100;
    public float healthSpeed = 0.2f;
	public Animator animator;
	public Rigidbody rb;
	public bool IsDead = false;

    [Header("Fire Ball")]
    public Rigidbody fireBallPrefab;
    public Vector3 pointOfAttack;
    public float ballCooldownLength;
    float ballCooldown;
    public AttackIcons ballAttackSprites;


    [Header("Flame Breath")]
    public float range = 100;
    [Range(0, 1.0f)]
    public float angle = 21;
    public float breathDamage;

    public Image healthFill;
    public Image damageFill;
    float healthFillScaleX;
    float healthFillScaleY;
    RectTransform healthFillTransform;
    RectTransform damageFillTransform;
    Transform enemyDragon;
    DragonStats enemyStats;
    InputDevice device;

    // Use this for initialization
    void Start ()
    {
        //Set Healthbar
        currentHealth = maxHealth;
        healthFillTransform = healthFill.GetComponent<RectTransform>();
        damageFillTransform = damageFill.GetComponent<RectTransform>();
        healthFillScaleX = healthFillTransform.localScale.x;
        healthFillScaleY = healthFillTransform.localScale.y;
        //Set Healthbar

        ballCooldown = 0;
        ballAttackSprites.SetRect(); 
        playerIndex = GetComponent<DragonManager>().playerIndex;

        //Find enemy dragon
        GameObject[] dragons = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject d in dragons)
        {
            if (d.GetComponent<DragonManager>().playerIndex != playerIndex)
                enemyDragon = d.transform;
        }
        enemyStats = enemyDragon.GetComponent<DragonStats>();
        device = InputManager.Devices[playerIndex];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("k"))
            currentHealth -= 2;
        if (Input.GetKeyDown("l"))
            currentHealth -= 20;

        healthFillTransform.localScale = new Vector3(healthFillScaleX, healthFillScaleY * (1 / (maxHealth / currentHealth)), 1);
        damageFillTransform.localScale = Vector3.Lerp(damageFillTransform.localScale, healthFillTransform.localScale, healthSpeed);

        if (ballCooldown > 0) ballCooldown -= Time.deltaTime;
        ballAttackSprites.ManageIcons(ballCooldown, ballCooldownLength);

        if (currentHealth < 0) currentHealth = 0;
		if (currentHealth > 100) currentHealth = 100;


        CastFlameBreath();
        CastFireBall();


    }
	void FixedUpdate()
	{
		if (currentHealth == 0) 
		{
			animator.SetBool ("IsDead", true);	
			IsDead = true;

			GetComponent<DragonManager> ().enabled = false;
			GetComponent<DragonControllerIdleFly> ().enabled = false;
			GetComponent<DragonControllerFly> ().enabled = false;
			rb.useGravity = true;
		}
	}

    // debugging, remove later
    public float coneX;
    public float coneY;

    void CastFlameBreath()
    {
        if (device.Action1.IsPressed && !IsDead)
        {
            Vector3 posD = transform.position;
            Vector3 posT = enemyDragon.position;
            Vector3 dir = transform.forward;
            float x = Vector3.Dot(dir, posT - posD);
            float y = Mathf.Sqrt(Vector3.SqrMagnitude(posT - posD) - (x * x));

            coneX = x;
            coneY = y;

            if (x > 0 && x < range && y < (x * angle))
                enemyStats.currentHealth -= breathDamage * Time.deltaTime;
        }
    }

    void CastFireBall()
    {
        //Fireball attack
		if (CanFireball() && device.Action2.IsPressed && !IsDead)
        {
            GameObject fire = Instantiate(Resources.Load("FireBall 1") as GameObject,
                transform.position + (transform.localRotation * pointOfAttack),
                transform.rotation) as GameObject;
			 
            ResetBallCooldown();
            fire.GetComponent<FireBall>().playerIndex = playerIndex;

        }
    }

    public bool CanFireball()
    {
        return (ballCooldown <= 0) ? true : false;
    }

    public void ResetBallCooldown()
    {
        ballCooldown = ballCooldownLength;
    }

    [System.Serializable]
    public class AttackIcons
    {
        public Image attackIcon;
        public Image cooldownIcon;
        public Image xIcon;
        RectTransform rect;
        float maxScale;
        GameObject x;

        public void SetRect()
        {
            rect = cooldownIcon.GetComponent<RectTransform>();
            maxScale = rect.localScale.y;
            x = xIcon.GetComponent<GameObject>();
        }

        public void ManageIcons(float cooldown, float length)
        {
            rect.localScale = new Vector3(rect.localScale.x, maxScale / (length / cooldown));
        }
    }

    

}
