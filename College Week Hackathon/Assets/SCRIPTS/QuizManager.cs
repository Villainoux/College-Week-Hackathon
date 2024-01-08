using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public GameObject Weapon;
    public GameObject EnemyWeapon;

    public Text questionText;
    public Button[] answerButtons;
    public Text feedbackText;

    private List<int> questionOrder; // Use a list to store the order of questions

    private string[] questions = {
        "Question 1: What is the capital of France?",
        "Question 2: What is the largest planet in our solar system?",
        "Question 3: Who wrote 'Romeo and Juliet'?"
    };

    private string[][] choices = {
        new string[] { "Paris", "Berlin", "Madrid", "Rome" },
        new string[] { "Earth", "Mars", "Jupiter", "Saturn" },
        new string[] { "William Shakespeare", "Jane Austen", "Charles Dickens", "Mark Twain" }
    };

    private int currentQuestion = 0;
    private int correctAnswers = 0;

    void Start()
    {
        InitializeQuestionOrder();
        ShowQuestion();
    }

    void InitializeQuestionOrder()
    {
        // Initialize the questionOrder list with shuffled indices
        questionOrder = new List<int>();
        for (int i = 0; i < questions.Length; i++)
        {
            questionOrder.Add(i);
        }
        ShuffleList(questionOrder);
    }

    // Helper method to shuffle a list
    void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    void ShowQuestion()
    {
        feedbackText.text = ""; // Clear previous feedback

        int questionIndex = questionOrder[currentQuestion];
        questionText.text = questions[questionIndex];

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = choices[questionIndex][i];

            int buttonIndex = i; // To capture the correct index in the lambda expression
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(buttonIndex));
        }
    }

    void CheckAnswer(int choiceIndex)
    {
        Weapon Weapons = Weapon.GetComponent<Weapon>();
        EnemyWeapon Weapons2 = EnemyWeapon.GetComponent<EnemyWeapon>();
        int questionIndex = questionOrder[currentQuestion];
        string selectedAnswer = choices[questionIndex][choiceIndex];

        string correctAnswer = GetCorrectAnswer(questionIndex);

        if (selectedAnswer == correctAnswer)
        {
            feedbackText.text = "Correct!";
            correctAnswers++;
            Weapons.Shoot(); // player
        }
        else
        {
            feedbackText.text = "Incorrect. The correct answer is: " + correctAnswer;
            Weapons2.Shoot(); // enemy shoots
        }

        currentQuestion++;

        if (currentQuestion < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            DisplayQuizResults();
        }
    }

    string GetCorrectAnswer(int questionIndex)
    {
        return choices[questionIndex][0];
    }

    void DisplayQuizResults()
    {
        questionText.text = "Quiz Completed!";
        feedbackText.text = "You got " + correctAnswers + " out of " + questions.Length + " questions correct.";
    }
}
