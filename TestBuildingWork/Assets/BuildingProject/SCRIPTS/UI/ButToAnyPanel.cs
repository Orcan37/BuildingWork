 
using UnityEngine;
using UnityEngine.EventSystems;
public class ButToAnyPanel : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{
    public GameObject panel;
    public byte numClick;
    public GameObject Bouder;

    void Awake() {
      
   //     Bouder = this.transform.Find("Bouder").gameObject;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
     if (Bouder)  Bouder.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        panel.GetComponent<ISelectPanel>().SelectNum(numClick);
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Bouder) Bouder.SetActive(false); 
    }
   

}
