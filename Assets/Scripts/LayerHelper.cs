using UnityEngine;
public class LayerHelper
{
    public static bool AreLayerMatching(int layer, string targetLayerName)
    {
        var targetLayer = LayerMask.GetMask(targetLayerName);
        return (((1 << layer) & targetLayer) != 0);
    }
}
