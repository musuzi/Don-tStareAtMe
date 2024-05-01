using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalentList", menuName = "data/TalentList")]

public class TalentList : ScriptableObject
{
    public List<TalentData> talentDatas;

    public TalentData GetRandomTalentInList()
    {
        TalentData result;

        result = talentDatas[Random.Range(0, talentDatas.Count)];

        return result;
    }
}
