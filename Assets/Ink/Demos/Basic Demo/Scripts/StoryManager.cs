using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

/// For UI updates based on Ink variables
/// Updates character images and background visuals depending on story state
public class StoryManager : MonoBehaviour
{
    [Header("UI References")]
    public Image storyImage; // Character image for mystery intro

    [Header("Background")]
    [SerializeField] private Image backgroundImage; // Background image
    [SerializeField] private Sprite defaultBackgroundSprite; // Default background when no garden detail is selected

    // Attitude images for mystery intro
    public Sprite cautiousSprite;
    public Sprite practicalSprite;
    public Sprite playfulSprite;

    // Garden images
    public Sprite veggieSprite;
    public Sprite flowerSprite;
    public Sprite succulentSprite;

    // Garden detail images for backgroundImage
    public Sprite tomatoSprite;
    public Sprite lettuceSprite;
    public Sprite fenceFlowerSprite;
    public Sprite wildFlowerSprite;
    public Sprite aloeSprite;
    public Sprite echeveriaSprite;

    private Story story;

    // Register event listener when script is enabled
    void OnEnable()
    {
        BasicInkExample.OnCreateStory += ResetStoryState;
    }

    // Unregister event listener when script is disabled
    void OnDisable()
    {
        BasicInkExample.OnCreateStory -= ResetStoryState;
    }

    /// Resets UI and sets up observers for Ink variables and called when a new story is created
    public void ResetStoryState(Story newStory)
    {
        story = newStory;

        // Clear story image
        if (storyImage != null)
        {
            storyImage.sprite = null;
            storyImage.enabled = false;
        }

        // Reset background to default
        if (backgroundImage != null)
        {
            backgroundImage.sprite = defaultBackgroundSprite;
            backgroundImage.enabled = true;
        }

        // Set up observers for Ink variables
        story.ObserveVariable("attitude", OnAttitudeChanged);
        story.ObserveVariable("garden_choice", OnGardenChoiceChanged);
        story.ObserveVariable("garden_detail", OnGardenDetailChanged);

        Debug.Log("Observers registered.");
    }

    /// Updates storyImage based on the 'attitude' variable.
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

        // Enable image only if a sprite is assigned
        storyImage.enabled = (storyImage.sprite != null);
    }

    /// Updates storyImage based on the 'garden_choice' variable.
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

    /// Updates backgroundImage based on the 'garden_detail' variable.
    void OnGardenDetailChanged(string varName, object newValue)
    {
        if (backgroundImage == null) return;

        string detail = newValue.ToString();

        switch (detail)
        {
            case "tomatoes":
                backgroundImage.sprite = tomatoSprite;
                break;
            case "lettuce":
                backgroundImage.sprite = lettuceSprite;
                break;
            case "fence_flowers":
                backgroundImage.sprite = fenceFlowerSprite;
                break;
            case "wild_flowers":
                backgroundImage.sprite = wildFlowerSprite;
                break;
            case "aloe":
                backgroundImage.sprite = aloeSprite;
                break;
            case "echeveria":
                backgroundImage.sprite = echeveriaSprite;
                break;
            default:
                backgroundImage.sprite = defaultBackgroundSprite;
                break;
        }

        backgroundImage.enabled = (backgroundImage.sprite != null);
    }
}