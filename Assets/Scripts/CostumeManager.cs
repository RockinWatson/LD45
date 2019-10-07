using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts;

public class CostumeManager : MonoBehaviour
{
    [SerializeField]
    private List<RuntimeAnimatorController> _mainAnimatorControllers = null;

    public void SetCostume(int index)
    {
        Player player = Player.PlayerInstance;

        Animator animator = player.GetComponent<Animator>();
        animator.runtimeAnimatorController = _mainAnimatorControllers[index];
    }

    private void Update()
    {
        //@TEMP:
        DebugInput();
    }

    private void DebugInput()
    {
        int numCostumes = _mainAnimatorControllers.Count;
        for (int i = 0; i < numCostumes; ++i)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SetCostume(i);
            }
        }
    }
}
