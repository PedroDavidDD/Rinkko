using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILifeSystem
{
    void TakeDamage(int damageAmount);

    void Die();
}
