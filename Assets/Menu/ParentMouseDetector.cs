using UnityEngine;

public class ParentMouseDetector : MonoBehaviour
{
    private BreathingAnimation[] childBreathingAnimations;

    void Start()
    {
        // Get all BreathingAnimation components in child objects
        childBreathingAnimations = GetComponentsInChildren<BreathingAnimation>();
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse entered parent object: " + gameObject.name);
        foreach (BreathingAnimation anim in childBreathingAnimations)
        {
            anim.SetHovered(true);
        }
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse exited parent object: " + gameObject.name);
        foreach (BreathingAnimation anim in childBreathingAnimations)
        {
            anim.SetHovered(false);
        }
    }
}
