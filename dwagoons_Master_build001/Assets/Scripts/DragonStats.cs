using UnityEngine;
using System.Collections;
using InControl;
using System.Collections.Generic;

using Image = UnityEngine.UI.Image;

public class DragonStats : MonoBehaviour {

    int playerIndex;

    [Header("Health")]
    public float maxHealth = 200;
    public float currentHealth;
    public float healthBarSize = 500;
    public float healthSpeed = 0.2f;
    public Vector3 outterStartingPoint;
    public Vector3 innerStartingPoint;
    public bool reverse;
    public Material healthBarMaterial;
    GameObject healthBar;

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

    Transform enemyDragon;
    DragonStats enemyStats;
    InputDevice device;

    // Use this for initialization
    void Start ()
    {
        CreateHealthBar();
        
        currentHealth = maxHealth;

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
        DrawHealthBar();
        if (Input.GetKeyDown("k"))
            currentHealth -= 2;
        if (Input.GetKeyDown("l"))
            currentHealth -= 20;

        if (ballCooldown > 0) ballCooldown -= Time.deltaTime;
        ballAttackSprites.ManageIcons(ballCooldown, ballCooldownLength);

        if (currentHealth < 0) currentHealth = 0;

        CastFlameBreath();
        CastFireBall();

        

    }

    void CastFlameBreath()
    {
        if (device.Action1.IsPressed)
        {
            Vector3 posD = transform.position;
            Vector3 posT = enemyDragon.position;
            Vector3 dir = transform.forward;
            float x = Vector3.Dot(dir, posT - posD);
            float y = Mathf.Sqrt(Vector3.SqrMagnitude(posT - posD) - (x * x));

            if (x > 0 && x < range && y < (x * angle))
                enemyStats.currentHealth -= breathDamage * Time.deltaTime;
        }
    }

    void CastFireBall()
    {
        //Fireball attack
        if (CanFireball() && device.Action2.IsPressed)
        {
            GameObject fire = Instantiate(Resources.Load("fireBall") as GameObject,
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

    void CreateHealthBar()
    {
        //Create health bar object
        healthBar = Instantiate(new GameObject());
        healthBar.layer = 8;
        healthBar.name = "Health Bar Player " + playerIndex;

        // Set up game object with mesh;
        healthBar.AddComponent(typeof(MeshRenderer));
        healthBar.GetComponent<MeshRenderer>().material = healthBarMaterial;
        MeshFilter filter = healthBar.AddComponent(typeof(MeshFilter)) as MeshFilter;
    }

    void DrawHealthBar()
    {
        int size = Mathf.FloorToInt(healthBarSize /  (maxHealth / currentHealth));
        Vector2[] vertices2D = new Vector2[size];
;
        vertices2D[0] = outterStartingPoint;
        float degrees = 0.01f;
        if (reverse) degrees = -degrees;

        //Set points for outer part of circle
        for (int i = 1; i < size / 2; i++)
        {
            float x = vertices2D[i - 1].x * Mathf.Cos(degrees) - vertices2D[i - 1].y * Mathf.Sin(degrees);
            float y = vertices2D[i - 1].x * Mathf.Sin(degrees) + vertices2D[i - 1].y * Mathf.Cos(degrees);
            vertices2D[i] = new Vector2(x, y);
        }

        //Set points for inner part of circle
        vertices2D[size - 1] = innerStartingPoint;
        for (int i = size - 2; i >= size / 2; i--)
        {
            float x = vertices2D[i + 1].x * Mathf.Cos(degrees) - vertices2D[i + 1].y * Mathf.Sin(degrees);
            float y = vertices2D[i + 1].x * Mathf.Sin(degrees) + vertices2D[i + 1].y * Mathf.Cos(degrees);
            vertices2D[i] = new Vector2(x, y);
        }

        // Use the triangulator to get indices for creating triangles
        Triangulator tr = new Triangulator(vertices2D);
        int[] indices = tr.Triangulate();

        // Create the Vector3 vertices
        Vector3[] vertices = new Vector3[vertices2D.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, 0);
        }

        // Create the mesh
        Mesh msh = new Mesh();
        msh.vertices = vertices;
        msh.triangles = indices;
        msh.RecalculateNormals();
        msh.RecalculateBounds();

        // Set up game object with mesh;
        MeshFilter filter = healthBar.GetComponent<MeshFilter>();
        filter.mesh = msh;
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
            if (rect != null) maxScale = rect.localScale.y;
            x = xIcon.GetComponent<GameObject>();
        }

        public void ManageIcons(float cooldown, float length)
        {
            if (rect != null) rect.localScale = new Vector3(rect.localScale.x, maxScale / (length / cooldown));
            else Debug.Log("Attack sprites not assigned");
        }
    }

    

}


//Required for drawing the curved health bars
public class Triangulator
{
    private List<Vector2> m_points = new List<Vector2>();

    public Triangulator(Vector2[] points)
    {
        m_points = new List<Vector2>(points);
    }

    public int[] Triangulate()
    {
        List<int> indices = new List<int>();

        int n = m_points.Count;
        if (n < 3)
            return indices.ToArray();

        int[] V = new int[n];
        if (Area() > 0)
        {
            for (int v = 0; v < n; v++)
                V[v] = v;
        }
        else
        {
            for (int v = 0; v < n; v++)
                V[v] = (n - 1) - v;
        }

        int nv = n;
        int count = 2 * nv;
        for (int m = 0, v = nv - 1; nv > 2;)
        {
            if ((count--) <= 0)
                return indices.ToArray();

            int u = v;
            if (nv <= u)
                u = 0;
            v = u + 1;
            if (nv <= v)
                v = 0;
            int w = v + 1;
            if (nv <= w)
                w = 0;

            if (Snip(u, v, w, nv, V))
            {
                int a, b, c, s, t;
                a = V[u];
                b = V[v];
                c = V[w];
                indices.Add(a);
                indices.Add(b);
                indices.Add(c);
                m++;
                for (s = v, t = v + 1; t < nv; s++, t++)
                    V[s] = V[t];
                nv--;
                count = 2 * nv;
            }
        }

        indices.Reverse();
        return indices.ToArray();
    }

    private float Area()
    {
        int n = m_points.Count;
        float A = 0.0f;
        for (int p = n - 1, q = 0; q < n; p = q++)
        {
            Vector2 pval = m_points[p];
            Vector2 qval = m_points[q];
            A += pval.x * qval.y - qval.x * pval.y;
        }
        return (A * 0.5f);
    }

    private bool Snip(int u, int v, int w, int n, int[] V)
    {
        int p;
        Vector2 A = m_points[V[u]];
        Vector2 B = m_points[V[v]];
        Vector2 C = m_points[V[w]];
        if (Mathf.Epsilon > (((B.x - A.x) * (C.y - A.y)) - ((B.y - A.y) * (C.x - A.x))))
            return false;
        for (p = 0; p < n; p++)
        {
            if ((p == u) || (p == v) || (p == w))
                continue;
            Vector2 P = m_points[V[p]];
            if (InsideTriangle(A, B, C, P))
                return false;
        }
        return true;
    }

    private bool InsideTriangle(Vector2 A, Vector2 B, Vector2 C, Vector2 P)
    {
        float ax, ay, bx, by, cx, cy, apx, apy, bpx, bpy, cpx, cpy;
        float cCROSSap, bCROSScp, aCROSSbp;

        ax = C.x - B.x; ay = C.y - B.y;
        bx = A.x - C.x; by = A.y - C.y;
        cx = B.x - A.x; cy = B.y - A.y;
        apx = P.x - A.x; apy = P.y - A.y;
        bpx = P.x - B.x; bpy = P.y - B.y;
        cpx = P.x - C.x; cpy = P.y - C.y;

        aCROSSbp = ax * bpy - ay * bpx;
        cCROSSap = cx * apy - cy * apx;
        bCROSScp = bx * cpy - by * cpx;

        return ((aCROSSbp >= 0.0f) && (bCROSScp >= 0.0f) && (cCROSSap >= 0.0f));
    }
}