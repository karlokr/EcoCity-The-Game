using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectMenu : MonoBehaviour
{
    public Text nameText;
    public Text description;
    public List<Text> statTexts;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNameText(string s)
    {
        nameText.text = s;
    }

    public void SetDescriptionText(string s)
    {
        description.text = s;
    }

    public void SetStatTexts(string[] s)
    {
        for (int i = 0; i < statTexts.Count; i++)
        {
            statTexts[i].text = s[i];
        }
    }

    public void SetInspecting(bool b)
    {
        animator.SetBool("Inspecting", b);
    }
}
