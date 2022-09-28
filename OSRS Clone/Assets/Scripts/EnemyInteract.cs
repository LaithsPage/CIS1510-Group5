using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : Interactable
{
    //PrimaryAction action = PrimaryAction.Attack;

    public override void Interact()
    {
        this.player.GetComponent<Attack>().startAttack(this.transform);
    }
}
