using UnityEngine;
using System.Collections;

using Image = UnityEngine.UI.Image;

public class DragonStats : MonoBehaviour {

    public float maxHealth = 100;
    public float currentHealth;
    public float healthBarSize = 100;
    public float healthSpeed = 0.2f;

    public float flameCooldownLength;
    float flameCooldown;
    public AttackIcons fireAttack;

    public Image healthFill;
    public Image damageFill;
    float healthFillScaleX;
    float healthFillScaleY;
    RectTransform healthFillTransform;
    RectTransform damageFillTransform;

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

        flameCooldown = 0;
        fireAttack.SetRect();
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

        if (flameCooldown > 0) flameCooldown -= Time.deltaTime;
        fireAttack.ManageIcons(flameCooldown, flameCooldownLength);

        if (currentHealth < 0) currentHealth = 0;

    }

    public bool CanFlame()
    {
        return (flameCooldown <= 0) ? true : false;
    }

    public void ResetFlameCooldown()
    {
        flameCooldown = flameCooldownLength;
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
