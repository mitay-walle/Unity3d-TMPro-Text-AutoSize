/// based on this: https://forum.unity.com/threads/textmeshpro-precull-dorebuilds-performance.762968/#post-5083490

using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Plugins.mitaywalle.UI.Layout
{
    public enum eResizePattern
    {
        IgnoreRichText,
        AllCharacters,
    }

    [ExecuteAlways]
    public class TMPTextAutoSize : MonoBehaviour
    {
        [SerializeField] private List<TMP_Text> _labels = new List<TMP_Text>();
        [SerializeField] private eResizePattern _pattern;
        [SerializeField] private bool _executeOnUpdate;
        private int _currentIndex;

        private void Update()
        {
            if (_executeOnUpdate) Execute();

            OnUpdateCheck();
        }

        public void Execute()
        {
            if (_labels.Count == 0) return;

            int count = _labels.Count;

            int index = 0;
            float maxLength = 0;

            for (int i = 0; i < count; i++)
            {
                float length = 0;

                switch (_pattern)
                {
                    case eResizePattern.IgnoreRichText:
                        length = _labels[i].GetParsedText().Length;

                        break;

                    case eResizePattern.AllCharacters:
                        length = _labels[i].text.Length;

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (length > maxLength)
                {
                    maxLength = length;
                    index = i;
                }
            }

            if (_currentIndex != index)
            {
                OnChanged(index);
            }
        }
        private void OnChanged(int index)
        {
            // Disable auto size on previous
            _labels[_currentIndex].enableAutoSizing = false;

            _currentIndex = index;

            // Force an update of the candidate text object so we can retrieve its optimum point size.
            _labels[index].enableAutoSizing = true;
            _labels[index].ForceMeshUpdate();
        }
        private void OnUpdateCheck()
        {
            float optimumPointSize = _labels[_currentIndex].fontSize;

            // Iterate over all other text objects to set the point size
            int count = _labels.Count;

            for (int i = 0; i < count; i++)
            {
                if (_currentIndex == i) continue;

                _labels[i].enableAutoSizing = false;

                _labels[i].fontSize = optimumPointSize;
            }
        }
    }
}
