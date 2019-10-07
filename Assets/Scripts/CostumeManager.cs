using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts;

using System.Linq;

public class CostumeManager : MonoBehaviour
{
    [SerializeField]
    private List<RuntimeAnimatorController> _mainAnimatorControllers = null;

    private Animator _costumeAnimator = null;
    private SpriteRenderer _costumeRenderer = null;
    private Animator[] _upgradeAnimators = null;
    private SpriteRenderer[] _upgradeRenderers = null;

    private int _currentCostume = 0;
    public int GetCurrentCostume() { return _currentCostume; }

    static private CostumeManager _instance = null;
    static public CostumeManager Get() { return _instance; }

    private void Awake()
    {
        _instance = this;

        Player player = Player.PlayerInstance;
        _costumeAnimator = player.GetComponent<Animator>();
        _costumeRenderer = player.GetComponent<SpriteRenderer>();
        _upgradeAnimators = player.GetComponentsInChildren<Animator>(true).Where(go => go.gameObject != player.gameObject).ToArray();
        _upgradeRenderers = player.GetComponentsInChildren<SpriteRenderer>(true).Where(go => go.gameObject != player.gameObject).ToArray();
    }

    public void SetCostume(int index)
    {
        _currentCostume = index;
        _costumeAnimator.runtimeAnimatorController = _mainAnimatorControllers[index];
    }

    public void SetUpgrade(int index)
    {
        _upgradeRenderers[index].gameObject.SetActive(true);
    }

    public void FlipRenderersX(bool flipX)
    {
        _costumeRenderer.flipX = flipX;
        foreach (SpriteRenderer renderer in _upgradeRenderers)
        {
            if (renderer.gameObject.activeSelf)
            {
                renderer.flipX = flipX;
                //renderer.transform.position.x *= -1f;
            }
        }
    }

    public void SetWalking(bool isWalking)
    {
        _costumeAnimator.SetBool("isWalking", isWalking);
        foreach(Animator animator in _upgradeAnimators)
        {
            if (animator.gameObject.activeSelf)
            {
                animator.SetBool("isWalking", isWalking);
            }
        }
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

        int numUpgrades = _upgradeRenderers.Length;
        for(int i = 0; i < numUpgrades; ++i)
        {
            if (Input.GetKeyDown(KeyCode.Alpha5 + i))
            {
                SetUpgrade(i);
            }
        }
    }
}
