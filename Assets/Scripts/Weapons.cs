using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform parentTransform;

    public void EnableWeapon(bool isEnabled)
    {
        gameObject.SetActive(isEnabled);
    }
}




