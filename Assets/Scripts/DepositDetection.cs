using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DepositDetection : MonoBehaviour
{
    [SerializeField] string[] mineralsInThisLevel;
    [SerializeField] int[] mineralGoal;
    [SerializeField] TextMeshProUGUI[] depositResultDisplay;
    [SerializeField] TextMeshProUGUI failureDisplay;
    [SerializeField] GameObject nextLevelButton;
    int[] depositNumber;
    int failureCount = 0;

    private void Start()
    {
        depositNumber = new int[mineralsInThisLevel.Length];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shard"))
        {
            MineralChemicalProperty chemicalProperty = other.gameObject.GetComponent<MineralChemicalPropertyBehavior>().GetChemicalProperty();
            for(int i = 0; i < mineralsInThisLevel.Length; i++)
            {
                string mineralName = mineralsInThisLevel[i];
                if(mineralName.ToLower() == chemicalProperty.name.ToLower())
                {
                    depositNumber[i]++;
                    depositResultDisplay[i].text = mineralName + ": " + depositNumber[i];
                    Destroy(other.gameObject);
                    DetectGoal();
                    return;
                }
            }
            failureCount++;
            failureDisplay.text = new string('X', failureCount);
            if(failureCount > 3) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
            Destroy(other.gameObject);
        }
        else
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (!rb) { rb = other.gameObject.transform.parent.GetComponent<Rigidbody>(); }
            rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }  
    }

    void DetectGoal()
    {
        for(int i = 0; i < depositNumber.Length; i++)
        {
            if (depositNumber[i] < mineralGoal[i]) return;
        }
        nextLevelButton.SetActive(true);
    }
}
