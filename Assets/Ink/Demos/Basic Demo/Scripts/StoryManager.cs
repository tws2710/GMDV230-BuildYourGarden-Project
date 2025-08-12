using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [Header("UI References")]
    public Image storyImage;

    public Sprite cautiousSprite;
    public Sprite practicalSprite;
    public Sprite playfulSprite;
    public Sprite veggieSprite;
    public Sprite flowerSprite;
    public Sprite succulentSprite;
    public Sprite tomatoSprite;
    public Sprite lettuceSprite;
    public Sprite fenceFlowerSprite;
    public Sprite wildFlowerSprite;
    public Sprite aloeSprite;
    public Sprite echeveriaSprite;

    private Story story;

    void OnEnable()
    {
        BasicInkExample.OnCreateStory += ResetStoryState;
    }

    void OnDisable()
    {
        BasicInkExample.OnCreateStory -= ResetStoryState;
    }

    public void ResetStoryState(Story newStory)
    {
        story = newStory;

        if (storyImage != null)
        {
            storyImage.sprite = null;
            storyImage.enabled = false;
        }

        story.ObserveVariable("attitude", OnAttitudeChanged);
        story.ObserveVariable("garden_choice", OnGardenChoiceChanged);
        story.ObserveVariable("garden_detail", OnGardenDetailChanged);

        Debug.Log("Observers registered.");
    }

    void OnAttitudeChanged(string varName, object newValue)
    {
        if (storyImage == null) return;

        string attitude = newValue.ToString();

        switch (attitude)
        {
            case "cautious":
                storyImage.sprite = cautiousSprite;
                break;
            case "practical":
                storyImage.sprite = practicalSprite;
                break;
            case "playful":
                storyImage.sprite = playfulSprite;
                break;
            case "":
                storyImage.sprite = null;
                break;
        }

        storyImage.enabled = (storyImage.sprite != null);
    }

    void OnGardenChoiceChanged(string varName, object newValue)
    {
        if (storyImage == null) return;

        string choice = newValue.ToString();

        switch (choice)
        {
            case "veggie":
                storyImage.sprite = veggieSprite;
                break;
            case "flower":
                storyImage.sprite = flowerSprite;
                break;
            case "succulent":
                storyImage.sprite = succulentSprite;
                break;
            default:
                storyImage.sprite = null;
                break;
        }

        storyImage.enabled = (storyImage.sprite != null);
    }

    void OnGardenDetailChanged(string varName, object newValue)
    {
        if (storyImage == null) return;

        string detail = newValue.ToString();

        switch (detail)
        {
            case "tomatoes":
                storyImage.sprite = tomatoSprite;
                break;
            case "lettuce":
                storyImage.sprite = lettuceSprite;
                break;
            case "fence_flowers":
                storyImage.sprite = fenceFlowerSprite;
                break;
            case "wild_flowers":
                storyImage.sprite = wildFlowerSprite;
                break;
            case "aloe":
                storyImage.sprite = aloeSprite;
                break;
            case "echeveria":
                storyImage.sprite = echeveriaSprite;
                break;
            default:
                storyImage.sprite = null;
                break;
        }

        storyImage.enabled = (storyImage.sprite != null);
    }
}