using UnityEngine;

public class BeamAim : MonoBehaviour
{
    public GameObject bullet;
    Vector2 fireDir;
    public Transform FirePoint;
    Transform firePoint;

    [Header("Beam (Tranfer data)")]
    public float fireRate;
    public float damage;
    public MagicTypes.Magictype magictype;
    public MagicTypes.magicEffects magicEffect;
    public float ManaCost;
    public float pushForce;
    private Transform Center;
    public float EffectTime;

    void Start()
    {
        Center = transform;
        GetComponentInChildren<BeamAttacksSpell>().fireRate = fireRate;
        GetComponentInChildren<BeamAttacksSpell>().damage = damage;
        GetComponentInChildren<BeamAttacksSpell>().magicType = magictype;
        GetComponentInChildren<BeamAttacksSpell>().ManaCost = ManaCost;
        GetComponentInChildren<BeamAttacksSpell>().magicEffect = magicEffect;
        GetComponentInChildren<BeamAttacksSpell>().pushForce = pushForce;
        GetComponentInChildren<BeamAttacksSpell>().Center = Center;
        GetComponentInChildren<BeamAttacksSpell>().EffectTime = EffectTime;
        //GetComponentInChildren<BeamAttacksSpell>().Shape = Shape;
        firePoint = GameObject.Find("PlayerFirePoint").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = firePoint.position;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        fireDir = (mousePosition - FirePoint.position).normalized;

        // Rotate bullet towards mouse position
        float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }





}
