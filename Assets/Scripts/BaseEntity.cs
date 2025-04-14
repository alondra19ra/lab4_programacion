using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    #region Protected Properties
    public string Name { get; private set; }           // Solo lectura pública
    public int Life { get; protected set; }            // Lectura pública, escritura protegida
    public int Attack { get; protected set; }          
    public int Defense { get; protected set; }        
    #endregion

    #region Constructor
    public BaseEntity(string name, int life, int attack, int defense)
    {
        Name = name;
        Life = life;
        Attack = attack;
        Defense = defense;
    }
    #endregion

    #region Methods
    public virtual void ReceiveDamage(int damage)
    {
        int damageTaken = damage - Defense;
        if (damageTaken < 0) damageTaken = 0;
        Life -= damageTaken;
        Debug.Log(Name + " recibió " + damageTaken + " de daño. Vida restante: " + Life);

        if (Life <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log(Name + " ha muerto.");
    }

    public virtual void ShowStats()
    {
        Debug.Log("[Stats] " + Name + " | Vida: " + Life + " | Ataque: " + Attack + " | Defensa: " + Defense);
    }
    #endregion
}


