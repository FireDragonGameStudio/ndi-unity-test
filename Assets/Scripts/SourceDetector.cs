using Klak.Ndi;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SourceDetector : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI textfield;

    NdiReceiver _receiver;
    List<string> _sourceNames;
    bool _disableCallback;

    void Start() => _receiver = GetComponent<NdiReceiver>();

    void Update() {

        // NDI source name retrieval
        _sourceNames = NdiFinder.sourceNames.ToList();

        if (_sourceNames.Count > 0) {
            textfield.text = _sourceNames[0];
        } else {
            textfield.text = "NO SOURCES FOUND!";
        }
    }

    public void OnChangeValue(int value) {
        if (_disableCallback) return;
        _receiver.ndiName = _sourceNames[value];
    }
}