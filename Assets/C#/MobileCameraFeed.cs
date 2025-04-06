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
                Debug.LogWarning("후면 카메라를 찾을 수 없습니다.");
                return;
            }
        }

        if (!webCamTexture.isPlaying)
        {
            webCamTexture.Play();
            Debug.Log("카메라 시작");
        }
    }

    private void StopCamera()
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            webCamTexture.Stop();
            Debug.Log("카메라 정지");
        }
    }
}
