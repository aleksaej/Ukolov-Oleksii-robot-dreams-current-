using System.Collections.Generic;
using UnityEngine;

public class ListController : MonoBehaviour
{

    private List<string> items = new List<string>();


    [SerializeField]
    private string inputItem;


    [ContextMenu("Print List")]
    private void PrintList()
    {
        if (items.Count == 0)
        {
            Debug.Log("The list is empty.");
            return;
        }


        string result = string.Join(", ", items);
        Debug.Log("List items: " + result);
    }


    [ContextMenu("Add Item")]
    private void AddItem()
    {
        if (!string.IsNullOrWhiteSpace(inputItem))
        {
            items.Add(inputItem);
            Debug.Log($"Item '{inputItem}' added to the list.");
        }
        else
        {
            Debug.Log("Input field is empty. Enter a value to add.");
        }
    }


    [ContextMenu("Remove Item")]
    private void RemoveItem()
    {
        if (items.Remove(inputItem))
        {
            Debug.Log($"Item '{inputItem}' removed.");
        }
        else
        {
            Debug.Log($"Item '{inputItem}' not found.");
        }
    }


    [ContextMenu("Clear List")]
    private void ClearList()
    {
        items.Clear();
        Debug.Log("The list has been cleared.");
    }


    [ContextMenu("Sort List")]
    private void SortList()
    {
        if (items.Count > 0)
        {
            items.Sort();
            Debug.Log("The list has been sorted.");
        }
        else
        {
            Debug.Log("There is nothing to sort.");
        }
    }
}
