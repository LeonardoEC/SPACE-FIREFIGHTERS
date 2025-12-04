using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconRollManager : MonoBehaviour
{
    public static IconRollManager Instance;

    [SerializeField] private List<IconRoll> _iconRollList;


    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetSpriteRoll(RollDropDown roll)
    {
        foreach (IconRoll item in _iconRollList)
        {
            if (item._roll == roll)
            {
                return item._sprite;
            }
        }

        return null;
    }
}
