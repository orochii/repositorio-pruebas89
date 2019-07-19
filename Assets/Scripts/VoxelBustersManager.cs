using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VoxelBusters;
using VoxelBusters.NativePlugins;

public class VoxelBustersManager : MonoBehaviour
{
    private bool isSharing = false;
    
    public void ShareSocialMedia() {
        isSharing = true;
    }

    private void LateUpdate() {
        if (isSharing == true) {
            isSharing = false;
            StartCoroutine(CaptureScreenshot());
        }
    }

    private IEnumerator CaptureScreenshot() {
        yield return new WaitForEndOfFrame();
        Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture();
        ShareSheet(texture);
        //Object.Destroy(texture);
    }

    private void ShareSheet (Texture2D texture) {
        ShareSheet _shareSheet = new ShareSheet();
        _shareSheet.Text = "Hello world!";
        _shareSheet.AttachImage(texture);
        _shareSheet.URL = "http://twitter.com/z_orochii";
        
        NPBinding.Sharing.ShowView(_shareSheet, FinishSharing);
    }

    private void FinishSharing(eShareResult result) {
        Debug.Log(result);
    }
}
