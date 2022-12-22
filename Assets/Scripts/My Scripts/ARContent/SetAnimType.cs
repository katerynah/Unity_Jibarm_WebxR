using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimType : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    [SerializeField] private AnimatorOverrider overrider;

    public void Set(int value)
    {
        overrider.SetAnimations(overrideControllers[value]);
   }
}
