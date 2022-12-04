using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerCamera : MonoBehaviour
{
   
    [SerializeField] public Transform targetP1;
    [SerializeField] public Transform targetP2;
    [SerializeField] public Transform targetP3;
    [SerializeField] public Vector3 offset;
    public Vector3 shakeOffset;
    public float smoothSpeed = 0.125f;
    public float speed = 100f;

    Player player;
    Player2 player2;
    Player3 player3;
   internal Volume Volume;
   internal Vignette Vignette;
   internal DepthOfField DepthOfField;
   internal ColorAdjustments colorAdjustments;
   internal Bloom bloom;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Volume = GetComponent<Volume>();
        Volume.profile.TryGet(out Vignette);
        Volume.profile.TryGet(out DepthOfField);
        Volume.profile.TryGet(out colorAdjustments);
        Volume.profile.TryGet(out bloom);
    }

    void LateUpdate()
    {

        PostProcessing();
        //Vector3 wantedPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, wantedPosition, smoothSpeed);
        //transform.position = smoothedPosition + shakeOffset;

        if (HeroManger.playerIndex == 1)
        {
            if (targetP1 != null)
            {

                float playerX = targetP1.transform.position.x;
                float playerY = targetP1.transform.position.y;
                float cameraZ = transform.position.z;
                var targetPosition = new Vector3(playerX, playerY, cameraZ);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);
                //transform.position = targetPosition;
            }
        }
        if (HeroManger.playerIndex == 2)
        {
            if (targetP2 != null)
            {

                float playerX = targetP2.transform.position.x;
                float playerY = targetP2.transform.position.y;
                float cameraZ = transform.position.z;
                var targetPosition = new Vector3(playerX, playerY, cameraZ);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);
                //transform.position = targetPosition;
            }
        }
        if (HeroManger.playerIndex == 3)
        {
            if (targetP3 != null)
            {

                float playerX = targetP3.transform.position.x;
                float playerY = targetP3.transform.position.y;
                float cameraZ = transform.position.z;
                var targetPosition = new Vector3(playerX, playerY, cameraZ);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);
                //transform.position = targetPosition;
            }
        }
    }
    public IEnumerator CameraShake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-.5f, .5f) * magnitude;
            float y = Random.Range(-.5f, .5f) * magnitude;

            shakeOffset.x = x;
            shakeOffset.y = y;
            elapsed += Time.deltaTime;
            yield return 0;
        }
        shakeOffset = Vector3.zero;
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(CameraShake(duration, magnitude));
    }

    public void PostProcessing()
    {
        Vignette.intensity.Override(1 - player.GetHPRatio());
    }
}