using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScannerBehavior : MonoBehaviour
{
    [SerializeField] Transform raycastOffset;
    [SerializeField] TextMeshProUGUI elementDisplay;
    [SerializeField] TextMeshProUGUI batteryDisplay;
    [SerializeField] int batteryLife = 3;

    private void Start()
    {
        batteryDisplay.text = "Battery: " + batteryLife;
        elementDisplay.text = "Scan a mineral to start";
    }
    public void StartScanning()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastOffset.position, raycastOffset.forward, out hit, 1f, LayerMask.GetMask("Minerals")) && batteryLife > 0)
        {
            MineralChemicalProperty chemicalProperty = hit.transform.gameObject.GetComponent<MineralChemicalPropertyBehavior>().GetChemicalProperty();
            int randomIndex = Random.Range(0, chemicalProperty.elements.Length);
            MineralChemicalProperty.Elements randomElement = chemicalProperty.elements[randomIndex];
            elementDisplay.text = "Detected Element: \n" + randomElement.ToString() + "\n" +  "Is Oxide: " + chemicalProperty.isOxide.ToString();
            batteryLife--;
            batteryDisplay.text = "Battery: " + batteryLife;
        }
    }
}
