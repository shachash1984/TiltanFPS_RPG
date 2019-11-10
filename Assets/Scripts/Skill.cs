using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType { Strength, Craft, Dexterity, Vitality, Magic, Luck}
[CreateAssetMenu(fileName ="Skill", menuName = "Skills/Create New Skill", order = 0)]
public class Skill : ScriptableObject {

    public SkillType skilltype;
    public int value;
    public int level;
	
}
