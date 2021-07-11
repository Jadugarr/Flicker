using UnityEngine;

public class TileOutlineController : MonoBehaviour
{
    public bool IsOutlineTop;
    public bool IsOutlineLeft;
    public bool IsOutlineRight;
    public bool IsOutlineBottom;

    private void Awake()
    {
        Material outlineMaterial = GetComponent<SpriteRenderer>().material;
        
        outlineMaterial.SetInteger("IsOutlineTop", IsOutlineTop ? 1 : 0);
        outlineMaterial.SetInteger("IsOutlineLeft", IsOutlineLeft ? 1 : 0);
        outlineMaterial.SetInteger("IsOutlineRight", IsOutlineRight ? 1 : 0);
        outlineMaterial.SetInteger("IsOutlineBottom", IsOutlineBottom ? 1 : 0);
    }
}