using UnityEngine;
using UnityEngine.UI;

public class PuzzleSlot : MonoBehaviour
{
    [SerializeField] private string targetPuzzleName;
    [SerializeField] private bool slotOccupied = false;

    private RectTransform rect;
    private Image puzzleImage;

    public delegate void PuzzleSlotDelegate(bool status);
    public static event PuzzleSlotDelegate OnSlotOccupied;

    private void Start()
    {
        puzzleImage = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    private void EnableImage()
    {
        puzzleImage.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(slotOccupied)
        {
            return;
        }

        if (col.GetComponent<DragObject>() != null)
        {
            DragObject dragObject = col.GetComponent<DragObject>();

            if (dragObject.isDragging)
            {
                return;
            }

            if (targetPuzzleName != dragObject.PuzzleName)
            {
                OnSlotOccupied?.Invoke(false);
                dragObject.SetPostion(rect);
                slotOccupied = true;
                return;
            }

            slotOccupied = true;
            OnSlotOccupied?.Invoke(true);
            dragObject.DeactiveObj();
            EnableImage();
        }
    }
}
