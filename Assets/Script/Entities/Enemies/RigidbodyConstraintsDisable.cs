using System.Collections;
using UnityEngine;

public class RigidbodyConstraintsDisable : MonoBehaviour
{
    public GameObject normal;  // O objeto do personagem normal
    public GameObject ragdoll; // O objeto do ragdoll

    void Start()
    {
        ragdoll.SetActive(false);
        normal.SetActive(true);
    }

    public void ActivateRagdoll()
    {
        StartCoroutine(DisableConstraints());
    }

    IEnumerator DisableConstraints()
    {
        yield return new WaitForSeconds(0.0f); // Ativa imediatamente

        ragdoll.SetActive(true);
        normal.SetActive(false);
    }
}
