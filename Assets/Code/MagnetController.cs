using UnityEngine;

public class MagnetController : MonoBehaviour
{
    [SerializeField] private PointEffector2D forceField;
    [SerializeField] private float magneticStreng = -100f;
    [SerializeField] private float magneticDamping = 30f;
    [SerializeField] private GameObject particlePivot;
    
    private void Start() {
        OnOff(false);
        forceField.drag = magneticDamping;
        forceField.forceMagnitude = magneticStreng;
    }

    public void OnOff(bool isOn)
    {
        forceField.enabled = isOn;
        particlePivot.SetActive(isOn);
    }
    
}
