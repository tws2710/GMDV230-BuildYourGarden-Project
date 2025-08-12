using System;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class BasicInkExample : MonoBehaviour {
    public static event Action<Story> OnCreateStory;

    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public Story story;

    [SerializeField]
    private Canvas canvas = null;

    [SerializeField]
    private Text textPrefab = null;
    [SerializeField]
    private Button buttonPrefab = null;

	[SerializeField]
	private AudioSource DogBark;

    [SerializeField]
    private Transform textBackgroundTransform = null;

    void Awake () {
        RemoveChildren();
        StartStory();
    }

    void StartStory () {
        story = new Story(inkJSONAsset.text);
        if (OnCreateStory != null) OnCreateStory(story);
        RefreshView();
    }

    void RefreshView () {
		RemoveChildren();

		while (story.canContinue) {
			string text = story.Continue().Trim();
			CreateContentView(text);

			List<string> currentTags = story.currentTags;
			HandleTags(currentTags);
		}

		if (story.currentChoices.Count > 0) {
			for (int i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices[i];
				Button button = CreateChoiceView(choice.text.Trim());
				button.onClick.AddListener(delegate {
					OnClickChoiceButton(choice);
				});
			}
		} else {
			Button choice = CreateChoiceView("End of story.\nRestart?");
			choice.onClick.AddListener(delegate {
				StartStory();
			});
		}
	}

    void OnClickChoiceButton(Choice choice) {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    void CreateContentView(string text) {
        Text storyText = Instantiate(textPrefab, textBackgroundTransform, false);
        storyText.text = text;
    }

    Button CreateChoiceView(string text) {
        Button choice = Instantiate(buttonPrefab, textBackgroundTransform, false);
        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;

        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        if (layoutGroup != null) layoutGroup.childForceExpandHeight = false;

        return choice;
    }

	private void HandleTags(List<string> tags)
	{
		foreach (string tag in tags)
		{
			switch (tag)
			{
				case "dog_bark":
					if (DogBark != null)
						DogBark.Play();
					break;
			}
		}
	}

    void RemoveChildren() {
        int childCount = textBackgroundTransform.childCount;
        for (int i = childCount - 1; i >= 0; --i) {
            Destroy(textBackgroundTransform.GetChild(i).gameObject);
        }
    }
}