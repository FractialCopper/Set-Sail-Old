using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perklist
{
    List<Ability> list_ability;

    public Perklist(List<Ability> ability_list) {
        list_ability = ability_list;
    }

    public struct Ability {
        Perk perk;
        int level;
    }

}
