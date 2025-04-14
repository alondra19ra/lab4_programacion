using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseEntity
{
    #region ExtraStats
    private int experience = 0;
    private int level = 1;
    #endregion

    #region Constructor
    public Player(string name, int life, int attack, int defense) : base(name, life, attack, defense)
    {
        Debug.Log("¡El jugador " + name + " ha entrado al combate!");
        ShowStats();
    }
    #endregion

    #region Combate
    public int AttackEnemy()
    {
        bool isCritical = Random.value < 0.2f; // 20% de probabilidad de golpe crítico
        int damage = Random.Range(Attack - 3, Attack + 4); // Daño aleatorio
        if (isCritical)
        {
            Debug.Log("¡Golpe crítico!");
            damage *= 2; // Doble daño en golpe crítico
        }
        return damage;
    }

    public override void ReceiveDamage(int damage)
    {
        bool esquiva = Random.value < 0.1f; // 10% de probabilidad de esquivar
        if (esquiva)
        {
            Debug.Log(Name + " esquivó el ataque!");
            return; // No recibe daño si esquiva
        }

        base.ReceiveDamage(damage); // Llamar al método base para recibir el daño
    }

    public void GainExperience(int amount)
    {
        experience += amount;
        Debug.Log(Name + " ganó " + amount + " de experiencia. Total: " + experience);

        if (experience >= 100) // Subir nivel
        {
            level++;
            experience = 0;
            Attack += 2;  // Incrementar ataque
            Life += 10;   // Incrementar vida
            Debug.Log("¡" + Name + " subió a nivel " + level + "! Nuevos stats: Vida: " + Life + ", Ataque: " + Attack);
        }
    }
    #endregion
}

