using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UINavigation : MonoBehaviour
{
    //Adding the static tag to variables/functions remove them from the traditional instance hierarchy making them far more accessible.
    //We can access GetNext, GetPrevious & SelectCell without needing a specific instance of UINavigation / Accessed in Game script

    public static EventSystem system;   //Find the EventSystem gameObject in our Canvas

    private void Awake()
    {
        system = GameObject.FindAnyObjectByType<EventSystem>();
    }

    //Use the EventSystem to get the currently selected object's navigation flow / See if someone is linked on it's RIGHT node, if so select the object
    public static void GetNext()
    {
        Selectable nextCell = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnRight();

        if (nextCell != null)
        {
            system.SetSelectedGameObject(nextCell.gameObject);
        }
    }

    //Use the EventSystem to get the currently selected object's navigation flow / See if someone is linked on it's LEFT node, if so select the object
    public static void GetPrevious()
    {
        Selectable previousCell = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnLeft();

        if (previousCell != null)
        {
            system.SetSelectedGameObject(previousCell.gameObject);
        }
    }

    //Directly set the EventSystem's selected node to a specific, given Cell
    public static void SelectCell(Cell cell)
    {
        if (cell.GetComponent<Selectable>() != null)
        {
            system.SetSelectedGameObject(cell.gameObject);
        }
    }
}
