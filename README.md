# TMPTextAutoSize
Resize TMP_Text.fontSize on multiplie labels, using most long text 
<br>Based on [this post](https://forum.unity.com/threads/textmeshpro-precull-dorebuilds-performance.762968/#post-5083490)
<br>![alt text](https://github.com/mitay-walle/Unity3d-TMPro-Text-AutoSize/blob/master/TMPTextAutoSize_example.gif)
<br>![alt text](https://github.com/mitay-walle/Unity3d-TMPro-Text-AutoSize/blob/master/inspector_preview.png)
# Problem

## I. Multiplie TMPro + AutoSize + different string.Length = fontSize is inconsistent
## II. TMP.AutoSize is slow
Especialy with ScrollRect and Multiplie TMPro-labels

# Solution
1 TMPro.AutoSize is enabled at once, on most-long-string label
<br>I. fontSize is always copied from longiest TMPro
<br>II. only 1 most-long-label.AutoSize is enabled

# Summary
- 1 MonoBehavior script
- Editor-time executes too
