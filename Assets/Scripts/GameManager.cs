using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        #region Creación
        FinalBoss boss = new FinalBoss("Destructor Omega", 100, 20, 10);
        Player player = new Player("Héroe Sombra", 90, 15, 8);
        #endregion

        #region Buffs
        boss.ApplyBuff("ataque", 5);
        boss.ApplyBuff("defensa", 3);
        boss.ApplyBuff("salud", 10);
        boss.ApplyBuff("ataque", -2);  // Buff negativo para verificar la validación
        #endregion

        #region Simulación de Combate
        while (boss.Life > 0 && player.Life > 0)
        {
            int playerDamage = player.AttackEnemy();
            Debug.Log("[Jugador] Ataque al jefe: " + playerDamage);
            boss.ReceiveDamage(playerDamage);  // El jugador ataca al jefe

            if (boss.Life <= 0) break;

            int bossDamage = Random.Range(boss.Attack - 2, boss.Attack + 4);
            Debug.Log("[Jefe Final] Ataque al jugador: " + bossDamage);
            player.ReceiveDamage(bossDamage);  // El jefe ataca al jugador

            if (player.Life <= 0) break;
        }
        #endregion

        #region Resultado Final
        if (player.Life > 0)
        {
            Debug.Log("¡El jugador ha derrotado al jefe final!");
            player.GainExperience(120); // El jugador gana experiencia por vencer al jefe
        }
        else if (boss.Life > 0)
        {
            Debug.Log("El jefe final ha vencido al jugador.");
        }
        else
        {
            Debug.Log("Ambos han caído en batalla.");
        }
        #endregion
    }
}


