using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : BaseEntity
{
    #region Constructor
    public FinalBoss(string name, int life, int attack, int defense) : base(name, life, attack, defense)
    {
        Debug.Log("¡El jefe final " + name + " ha aparecido!");
        ShowStats();
    }
    #endregion

    #region Buffs
    public void ApplyBuff(string tipo, int cantidad)
    {
        tipo = tipo.ToLower();

        switch (tipo)
        {
            case "ataque":
                if (Attack + cantidad < 0)
                    Attack = 0;
                else
                    Attack += cantidad;
                Debug.Log(Name + " recibió un buff de ATAQUE. Nuevo ataque: " + Attack);
                break;

            case "defensa":
                if (Defense + cantidad < 0)
                    Defense = 0;
                else
                    Defense += cantidad;
                Debug.Log(Name + " recibió un buff de DEFENSA. Nueva defensa: " + Defense);
                break;

            case "salud":
                if (Life + cantidad < 0)
                    Life = 0;
                else
                    Life += cantidad;
                Debug.Log(Name + " recibió un buff de SALUD. Nueva vida: " + Life);
                break;

            default:
                Debug.Log("Buff inválido.");
                break;
        }
    }
    #endregion

    #region Damage
    public override void ReceiveDamage(int damage)
    {
        int damageTaken = damage - Defense;
        if (damageTaken < 0) damageTaken = 0;
        Life -= damageTaken;

        Debug.Log("[Jefe Final] " + Name + " recibió " + damageTaken + " de daño. Vida restante: " + Life);

        if (Life <= 0)
        {
            Die();
        }
    }
    #endregion

    #region Death
    protected override void Die()
    {
        Debug.Log(Name + ", el jefe final ha sido derrotado.");
    }
    #endregion
}

