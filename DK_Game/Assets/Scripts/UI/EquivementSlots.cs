using UnityEngine;
using UnityEngine.UI;

public class EquivementSlots : MonoBehaviour
{
    public Sprite item1, item2, item3, item4, item5;

    public GameObject slot1, slot2, slot3, slot4, slot5;

    private void Update()
    {
        if (item1 == null &&
            item2 == null &&
            item3 == null &&
            item4 == null &&
            item5 == null)
            return;
        else
        {
            slot1.GetComponent<Image>().sprite = item1;
            slot2.GetComponent<Image>().sprite = item2;
            slot3.GetComponent<Image>().sprite = item3;
            slot4.GetComponent<Image>().sprite = item4;
            slot5.GetComponent<Image>().sprite = item5;
        }

    }
}
