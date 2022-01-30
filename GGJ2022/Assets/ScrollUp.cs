using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUp : MonoBehaviour
{
    float speed = 1f;

    private void OnEnable() {
        StartCoroutine(Scroll());
    }

    IEnumerator Scroll () {
        if (PlayerController.instance)
            transform.position = PlayerController.instance.transform.position;
        else
            transform.position = Vector2.zero;

        Vector3 target = transform.position + Vector3.up * 10f;

        while (Vector2.Distance(transform.position, target) > 1f) {
            transform.position = Vector2.Lerp(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }

        gameObject.SetActive(false);
        yield return null;
    }
}
