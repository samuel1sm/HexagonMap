using UnityEngine;
using Utils;

public class HexCell : MonoBehaviour
{

    public HexCoordinates coordinates;
    public Color color;
    [SerializeField] private HexCell[] neighbors;

    public HexCell GetNeighbor (HexDirection direction) {
        return neighbors[(int)direction];
    }

    public void SetNeighbor (HexDirection direction, HexCell cell) {
        neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this;
    }


}
