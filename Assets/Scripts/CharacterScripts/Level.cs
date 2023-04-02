using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private int experience = 0;
    [SerializeField] Experience _experience;
    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        _experience.UpdateExperience(experience,TO_LEVEL_UP);
        _experience.SetLevelText(level);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        _experience.UpdateExperience(experience,TO_LEVEL_UP);
    }

    private void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
            _experience.SetLevelText(level);
        }
    }
}
