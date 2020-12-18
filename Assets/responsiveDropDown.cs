using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class responsiveDropDown : MonoBehaviour
{
    public GameObject[] objectsToAddOnMIDropDown, objectsToAddOnPCDropDown, objectsToAddOnCADropDown, objectsToAddOnValuesDropDown, objectsToAddOnEduDropDown, objectsToAddOnPossessDropDown, objectsToAddOnSkillsDropDown;
    public bool miDroppedDown, pcDroppedDown, cADroppedDown, valuesDroppedDown, eduDroppedDown, possessDroppedDown, skillsDroppedDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onMiDropDown()
    {
        if (!miDroppedDown)
        {
            foreach (var item in objectsToAddOnMIDropDown)
            {
                item.SetActive(true);
                miDroppedDown = true;
            }
        }

        else
        {
            foreach (var item in objectsToAddOnMIDropDown)
            {
                item.SetActive(false);
                miDroppedDown = false;
            }
        }
    }


    public void onPCDropDown()
    {
        if (!pcDroppedDown)
        {
            foreach (var item in objectsToAddOnPCDropDown)
            {
                item.SetActive(true);
                pcDroppedDown = true;
            }
        }

        else
        {
            foreach (var item in objectsToAddOnPCDropDown)
            {
                item.SetActive(false);
                pcDroppedDown = false;
            }
        }
    }


    public void onCADropDown()
    {
        if (!cADroppedDown)
        {
            foreach (var item in objectsToAddOnCADropDown)
            {
                item.SetActive(true);
                cADroppedDown = true;
            }
        }

        else
        {
            foreach (var item in objectsToAddOnCADropDown)
            {
                item.SetActive(false);
                cADroppedDown = false;
            }
        }
    }


    public void onValuesDropDown() {
        if (!valuesDroppedDown) {
            foreach (var item in objectsToAddOnValuesDropDown) {
                item.SetActive(true);
                valuesDroppedDown = true;
            }
        } else {
            foreach (var item in objectsToAddOnValuesDropDown) {
                item.SetActive(false);
                valuesDroppedDown = false;
            }
        }
    }
    public void onEduDropDown() {
        if (!eduDroppedDown) {
            foreach (var item in objectsToAddOnEduDropDown) {
                item.SetActive(true);
                eduDroppedDown = true;
            }
        } else {
            foreach (var item in objectsToAddOnEduDropDown) {
                item.SetActive(false);
                eduDroppedDown = false;
            }
        }
    }
    public void onPossessDropDown() {
        if (!possessDroppedDown) {
            foreach (var item in objectsToAddOnPossessDropDown) {
                item.SetActive(true);
                possessDroppedDown = true;
            }
        } else {
            foreach (var item in objectsToAddOnPossessDropDown) {
                item.SetActive(false);
                possessDroppedDown = false;
            }
        }
    }
    public void onSkillsDropDown() {
        if (!skillsDroppedDown) {
            foreach (var item in objectsToAddOnSkillsDropDown) {
                item.SetActive(true);
                skillsDroppedDown = true;
            }
        } else {
            foreach (var item in objectsToAddOnSkillsDropDown) {
                item.SetActive(false);
                skillsDroppedDown = false;
            }
        }
    }


    public void generalFunction(GameObject[] array)
    {
        if (!valuesDroppedDown)
        {
            foreach (var item in objectsToAddOnValuesDropDown)
            {
                item.SetActive(true);
                valuesDroppedDown = true;
            }
        }

        else
        {
            foreach (var item in objectsToAddOnValuesDropDown)
            {
                item.SetActive(false);
                valuesDroppedDown = false;
            }
        }
    }

}
