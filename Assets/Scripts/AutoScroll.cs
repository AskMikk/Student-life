// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class ScrollingText : MonoBehaviour {
//     private ScrollView scrollView;
//     private bool dragging = false;
//     private float mouseYonDragStart = 0;
    
//     public void Start()
//     {
//     //...
//     scrollView.RegisterCallback<MouseDownEvent>(OnMouseDown, TrickleDown.TrickleDown);
//         scrollView.RegisterCallback<MouseUpEvent>(OnMouseUp, TrickleDown.TrickleDown);
//         scrollView.RegisterCallback<MouseMoveEvent>(OnMouseMove, TrickleDown.TrickleDown);
//     }
    
//     public void OnMouseMove(MouseMoveEvent evt)
//     {
//         if (dragging)
//         {
//             scrollView.scrollOffset = new Vector2(0, mouseYonDragStart-evt.localMousePosition.y);
//         }
//     }
    
//     private void OnMouseUp(MouseUpEvent evt)
//     {
//         dragging = false;
//         Debug.Log("on mouse up");
//         if (Vector2.Distance(dragStart,evt.localMousePosition) > 5)
//         {
//             evt.StopImmediatePropagation();
//         }
//     }
    
//     private void OnMouseDown(MouseDownEvent evt)
//     {
//         dragging = true;
//         mouseYonDragStart = evt.localMousePosition.y+scrollView.scrollOffset.y;
//     }
// }


