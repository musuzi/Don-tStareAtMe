using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTalentManager : MonoBehaviour
{
    public static PlayerTalentManager Instance;

    [SerializeField] private Attribute playerAttribute;
    [SerializeField] private Button[] talentButtons = new Button[3];

    public List<TalentList> AllTalents;

    public TalentData[] talentDatas = new TalentData[3];
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        playerAttribute = GameObject.Find("Player").GetComponent<Attribute>();
    }

    public void TalentChoiceState()
    {
        TalentUIEnable();
        GetRandomTalentDatas();
        ChangeButtonUI();
    }

    private void GetRandomTalentDatas()
    {
        for(int i = 0; i < talentDatas.Length; i++)
        {
            talentDatas[i] = AllTalents[Random.Range(0,AllTalents.Count)].GetRandomTalentInList();
        }
    }

    private void ChangeButtonUI()
    {
        for(int i = 0;i < talentButtons.Length;i++)
        {
            talentButtons[i].image.sprite = talentDatas[i].talentSprite;
            talentButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = talentDatas[i].talentName;
            talentButtons[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = talentDatas[i].talentDescription;
        }
    }

    public void TalentUIEnable()
    {
        for (int i = 0; i < 3; i++)
        {
            talentButtons[i].gameObject.SetActive(true);

        }
    }

    public void TalentUIUnable()
    {
        for (int i = 0; i < 3; i++)
        {
            talentButtons[i].gameObject.SetActive(false);

        }
    }

    public void ApplyRandomTalent0()
    {
        playerAttribute.AttributeTalentAdd(talentDatas[0]);
        TalentUIUnable();
    }

    public void ApplyRandomTalent1()
    {
        playerAttribute.AttributeTalentAdd(talentDatas[1]);
        TalentUIUnable();
    }

    public void ApplyRandomTalent2() 
    {
        playerAttribute.AttributeTalentAdd(talentDatas[2]);
        TalentUIUnable();
    }
}
