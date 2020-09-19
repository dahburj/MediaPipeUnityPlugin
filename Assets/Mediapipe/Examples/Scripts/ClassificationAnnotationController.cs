using Mediapipe;
using UnityEngine;

public class ClassificationAnnotationController : MonoBehaviour {
  public void Clear() {
    gameObject.GetComponent<TextMesh>().text = "";
  }

  /// <summary>
  ///   Renders a text on a screen.
  ///   It is assumed that the screen vertical to terrain and not inverted.
  /// </summary>
  public void Draw(Transform screenTransform, ClassificationList classificationList) {
    var arr = classificationList.Classification;
    if (arr.Count == 0 || arr[0].Score < 0.5) {
      Clear();
      return;
    }

    gameObject.GetComponent<TextMesh>().text = arr[0].Label;

    var localScale = screenTransform.localScale;
    var scaleVec = new Vector3(10 * localScale.x, 10 * localScale.z, 1);

    gameObject.transform.position = new Vector3(-10 * localScale.x / 2, 10 * localScale.z / 2, screenTransform.position.z);
  }
}