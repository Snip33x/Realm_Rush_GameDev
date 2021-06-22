using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeReference] int cost = 75;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank = null)
        {
            return false;
        }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false; // CreateTower by³ b³êdny poniewa¿ nie by³o sprecyzowanego returna ze wzglêdu na to ¿e powy¿sze dwa returny objêcte s¹ ifami
    }
}
