using UnityEngine;
using UnityEngine.UI;

public class MobileCameraFeed : MonoBehaviour
{
    public RawImage cameraRawImage;
    private WebCamTexture webCamTexture;

    void OnEnable()
    {
        StartCamera();
    }

    void OnDisable()
    {
        StopCamera();
    }

    private void StartCamera()
    {
        if (webCamTexture == null)
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            string backCamName = null;

            for (int i = 0; i < devices.Length; i++)
            {
                if (!devices[i].isFrontFacing)
                {
                    backCamName = devices[i].name;
                    break;
                }
            }

            if (backCamName != null)
            {
                webCamTexture = new WebCamTexture(backCamName, Screen.width, Screen.height);
                cameraRawImage.texture = webCamTexture;
                cameraRawImage.material.mainTexture = webCamTexture;
            }
            else
            {
                Debug.LogWarning("�ĸ� ī�޶� ã�� �� �����ϴ�.");
                return;
            }
        }

        if (!webCamTexture.isPlaying)
        {
            webCamTexture.Play();
            Debug.Log("ī�޶� ����");
        }
    }

    private void StopCamera()
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            webCamTexture.Stop();
            Debug.Log("ī�޶� ����");
        }
    }
}
