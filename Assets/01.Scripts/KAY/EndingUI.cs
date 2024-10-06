using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine.UIElements.Experimental;

public class EndingUI : MonoBehaviour
{
    private Label text1;
    private Label text2;
    private Label credit;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        text1 = root.Q<Label>("Text1");
        text2 = root.Q<Label>("Text2");
        credit = root.Q<Label>("Credit");



    }
    
   
    

}
