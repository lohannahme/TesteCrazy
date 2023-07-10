using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    public float speed = 10;
    public DIRECTION direction;
    public bool destroyOnHit;
    public bool UseFirePointRotation;

    public GameObject EffectOnSpawn;
    public GameObject hitEffect;
    private DamageObject damage;
    public GameObject[] Detached;

    public Vector3 rotationOffset = new Vector3(0, 0, 0);

    private ParticleSystem _projectileParticle;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector2((int)direction * speed, 0);
        GetComponent<Collider>().isTrigger = true;

        _projectileParticle = GetComponent<ParticleSystem>();

        //turn projectile to travel direction
        transform.rotation = Quaternion.Euler(0f, (direction == DIRECTION.Right ? -90 : 90), 0f);

        //show an effect when this projectile is spawned
        if (EffectOnSpawn)
        {
            GameObject effect = GameObject.Instantiate(EffectOnSpawn) as GameObject;
            effect.transform.position = transform.position;

            var flashPs = EffectOnSpawn.GetComponent<ParticleSystem>();

            Destroy(effect, flashPs.main.duration);
        }
    }

    //tell the player that an item is in range
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Enemy"))
        {

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<SphereCollider>().enabled = false;
            speed = 0;

            //hit a damagable object
            IDamagable<DamageObject> damagableObject = coll.GetComponent(typeof(IDamagable<DamageObject>)) as IDamagable<DamageObject>;


            if (damagableObject != null)
            {
                damagableObject.Hit(damage);
                var hitInstance = Instantiate(hitEffect, transform.position, Quaternion.identity);
                if (UseFirePointRotation) { hitInstance.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180f, 0); }
                else if (rotationOffset != Vector3.zero) { hitInstance.transform.rotation = Quaternion.Euler(rotationOffset); }
                //else { hitInstance.transform.LookAt(contact.point + contact.normal); }

                //Destroy hit effects depending on particle Duration time
                var hitPs = hitInstance.GetComponent<ParticleSystem>();
                if (hitPs != null)
                {
                    Destroy(hitInstance, hitPs.main.duration);
                }
                else
                {
                    var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(hitInstance, hitPsParts.main.duration);
                }
                Destroy(gameObject);
            }
        }
    }

    //sets the damage of this projectile
    public void SetDamage(DamageObject d)
    {
        damage = d;
    }

    public void SetKnock()
    {
        damage.knockDown = true;
    }
}
