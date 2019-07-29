using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;


namespace MathNet.Examples {

  public class MathNETExamplesDisplay : MonoBehaviour {

    public GameObject TextBlockPrefab;
    public GameObject TextBlockContainer;

    [SerializeField]
    int _fontSize = 14;

    int _maxTextBlocks = 40000;
    List<GameObject> _textBlocks;

    void Awake() {
      _textBlocks = new List<GameObject>();
    }

    void OnEnable() {
      Application.logMessageReceived += DisplayLog;
    }

    void OnDisable() {
      Application.logMessageReceived -= DisplayLog;
    }


    void DisplayLog(string message, string stackTrace, LogType type) {

      var go = Instantiate(TextBlockPrefab);
      go.transform.SetParent(TextBlockContainer.transform);
      var txt = go.GetComponent<Text>();
      txt.text = message;
      txt.fontSize = _fontSize;
      _textBlocks.Add(go);

      if(_textBlocks.Count > _maxTextBlocks) {
        var b = _textBlocks[0];
        Destroy(b);
        _textBlocks.RemoveAt(0);
      }
//      Content.text = Content.text + "\n" + message;
//      Content.text = Content.text.Substring(0, _maxChars);
    }

    public void ClearAll() {
      for(int i = _textBlocks.Count - 1; i >= 0; i--) {
        var b = _textBlocks[i];
        Destroy(b);
        _textBlocks.RemoveAt(i);
      }
    }

  }

}