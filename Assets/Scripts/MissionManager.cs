using System.Collections;
using UnityEngine;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public TextMeshProUGUI missionText;
    public TextMeshProUGUI hintText;
    public TextMeshProUGUI statusText;

    public TargetMarkerController mercuryMarker;
    public TargetMarkerController venusMarker;
    public TargetMarkerController earthMarker;

    public AudioSource audioSource;
    public AudioClip missionCompleteSound;
    public AudioSource voiceSource;

    public AudioClip mercuryVoice;
    public AudioClip venusVoice;
    public AudioClip earthVoice;

    public Transform mercuryTarget;
    public Transform venusTarget;
    public Transform earthTarget;

    public CameraMover cameraMover;

    private int currentMission = 0;
    private bool isTransitioning = false;

    void Start()
    {
        LoadMission();
    }

    void HideAllMarkers()
    {
        if (mercuryMarker != null) mercuryMarker.ShowMarker(false);
        if (venusMarker != null) venusMarker.ShowMarker(false);
        if (earthMarker != null) earthMarker.ShowMarker(false);
    }

    void LoadMission()
    {
        HideAllMarkers();

        if (voiceSource != null)
        {
            voiceSource.Stop();
        }

        if (currentMission == 0)
        {
            missionText.text = "Scan Mercury";
            hintText.text = "Hint: Closest planet to the Sun";
            statusText.text = "Progress: 0/1";

            if (mercuryMarker != null)
                mercuryMarker.ShowMarker(true);

            if (voiceSource != null && mercuryVoice != null)
                voiceSource.PlayOneShot(mercuryVoice);
        }
        else if (currentMission == 1)
        {
            missionText.text = "Find the hottest planet";
            hintText.text = "Hint: 2nd planet from the Sun";
            statusText.text = "Progress: 0/1";

            if (venusMarker != null)
                venusMarker.ShowMarker(true);

            if (voiceSource != null && venusVoice != null)
                voiceSource.PlayOneShot(venusVoice);
        }
        else if (currentMission == 2)
        {
            missionText.text = "Scan Earth";
            hintText.text = "Hint: The blue planet";
            statusText.text = "Progress: 0/1";

            if (earthMarker != null)
                earthMarker.ShowMarker(true);

            if (voiceSource != null && earthVoice != null)
                voiceSource.PlayOneShot(earthVoice);
        }
        else
        {
            missionText.text = "All Missions Completed!";
            hintText.text = "You have completed Guided Learning.";
            statusText.text = "Progress: Complete";
        }
    }

    public void ObjectScanned(string objectName)
    {
        if (isTransitioning) return;

        if (currentMission == 0 && objectName == "Mercury")
        {
            StartCoroutine(CompleteMission());
        }
        else if (currentMission == 1 && objectName == "Venus atmosphere")
        {
            StartCoroutine(CompleteMission());
        }
        else if (currentMission == 2 && objectName == "Earth clouds")
        {
            StartCoroutine(CompleteMission());
        }
    }

    IEnumerator CompleteMission()
    {
        isTransitioning = true;

        int completedMission = currentMission;

        HideAllMarkers();

        missionText.text = "Mission Complete!";
        hintText.text = "Good job, Explorer.";
        statusText.text = "Progress: 1/1";

        if (audioSource != null && missionCompleteSound != null)
        {
            audioSource.PlayOneShot(missionCompleteSound);
        }

        yield return new WaitForSeconds(2f);

        currentMission++;

        if (cameraMover != null)
        {
            if (completedMission == 0 && venusTarget != null)
            {
                cameraMover.MoveToTarget(venusTarget);
            }
            else if (completedMission == 1 && earthTarget != null)
            {
                cameraMover.MoveToTarget(earthTarget);
            }
        }

        isTransitioning = false;
        LoadMission();
    }
}