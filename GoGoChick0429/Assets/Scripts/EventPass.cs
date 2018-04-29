using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventPass : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter (PointerEventData eventData)
	{
		MainAI.IsPress = true;
	}
	public void OnPointerExit (PointerEventData eventData)
	{
		MainAI.IsPress = false;
	}
}
