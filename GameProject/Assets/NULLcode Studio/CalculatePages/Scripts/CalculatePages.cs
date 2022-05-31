using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CalculatePages : MonoBehaviour
{
	[SerializeField] private string loadBook = "MainBook"; // имя текстового файла
	[SerializeField] private string booksPath = "Books"; // имя папки с текстовым файлов в Resources
    [SerializeField] private List<int> pagesArray = new List<int>(); // страницы конца темы(это для вывода новых подсказок)
	[SerializeField] private Text leftPage; // левая страница
	[SerializeField] private Text rightPage; // правая страница
	[SerializeField] private Text LPN; // номер левой страницы
	[SerializeField] private Text RPN; // номер правой страницы
	[SerializeField] private Button nextButton; // листаем вперед
	[SerializeField] private Button prevButton; // листаем назад
	private List<string> pagesList = new List<string>();
    private int pageCount;

    public static int quantityAvailableSentences = 0;
    public static int mtsBorder = 7;
	public static int sberBorder = 12;

	void Start()
	{
		nextButton.onClick.AddListener(() => { Next(); });
		prevButton.onClick.AddListener(() => { Prev(); });
		leftPage.rectTransform.sizeDelta = rightPage.rectTransform.sizeDelta;

        Calculate(loadBook);
	}

	void SetPages()
	{
		leftPage.text = pagesList[pageCount];
		rightPage.text = (pageCount + 1 > pagesList.Count - 1) ? string.Empty : pagesList[pageCount + 1];
		LPN.text = (pageCount + 1).ToString();
		RPN.text = (pageCount + 2).ToString();
	}

	void Next()
	{
		pageCount += 2;
		SetPages();
		prevButton.interactable = true;
        unchecked
		{
			if (quantityAvailableSentences <= pagesArray.Count && (pageCount == pagesArray[quantityAvailableSentences] - 1 || pageCount == pagesArray[quantityAvailableSentences]))
                nextButton.interactable = false;
			else if (pageCount + 1 >= pagesList.Count - 1)
                nextButton.interactable = false;
		}
        
    }

	void Prev()
    {
        pageCount -= 2;
        SetPages();

        if (pageCount == 0)
        {
            prevButton.interactable = false;
        }

        nextButton.interactable = true;
    }

	void Calculate(string fileName)
	{
        TextAsset binary = Resources.Load<TextAsset>(booksPath + "/" + fileName);

        if (binary != null && !string.IsNullOrEmpty(binary.text))
        {
            pagesList.Clear();
            pagesList = Pages(binary.text, leftPage);
            leftPage.text = string.Empty;
            rightPage.text = string.Empty;
            LPN.text = string.Empty;
            RPN.text = string.Empty;
            nextButton.interactable = true;
            prevButton.interactable = false;
            pageCount = -2;
        }
	}

	List<string> Pages(string text, Text page) // определяем на сколько страниц нужно разбить текст
	{
		if (string.IsNullOrEmpty(text) || page == null) return new List<string>();

		TextGenerationSettings settings = page.GetGenerationSettings(page.rectTransform.rect.size);
		TextGenerator textGenerator = new TextGenerator();

		string current = text;
		int index = 0;
		List<string> pages = new List<string>();

		while (current.Length != 0)
		{
			textGenerator.Populate(current, settings);
			index = textGenerator.characterCountVisible;
			pages.Add(current.Substring(0, index));
			current = current.Substring(index).Trim();
		}

		return pages;
	}
}
