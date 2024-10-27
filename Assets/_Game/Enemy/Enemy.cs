using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Slider healthfill;
    public float health;
    public float damagePerHit;

    [SerializeField] int timeBetweenAttacks;

    [SerializeField] LaserAttack laserAttack;
    [SerializeField] SawAttack sawAttack;
    int lastAttack = -1;
    public void TakeDamage()
    {
        health -= damagePerHit ;
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(5f);

        while (health > 0) 
        {

            int range = 0;

                range = Random.Range(1, 3);

            if (range == 1)
            {
                laserAttack.StartAttack();
                yield return new WaitUntil(() => laserAttack.isAttacking == false);

            }
            else if (range == 2)
            {
                sawAttack.StartAttack();
                yield return new WaitUntil(() => sawAttack.isAttacking == false);

            }

            yield return new WaitForSeconds(timeBetweenAttacks);

        }
    }

    private void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        LeanTween.value(healthfill.value, health / 200f, .3f).setOnUpdate((float x) => { healthfill.value = x;});
        if(health == 0)
        {
            Debug.Log("gg");
        }
    }



}
