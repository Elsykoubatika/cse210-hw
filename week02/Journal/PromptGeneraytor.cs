using System;

public class PromptGenerator
{
    private Random random = new Random();
    private List<string> _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was the moment I felt most grateful for today?",
        "What interaction surprised me the most today?",
        "What did I learn new today?",
        "What was the bravest thing I did today?", "What brought me the most joy today?",
        "How did I show patience today?",
        "Did I accomplish something difficult today?",
        "How did I have a positive impact on someone's life today?",
        "What am I most proud of today?",
        "Did I encounter a challenge today?", "How did I handle it?",
        "What was the smallest thing that had a big impact on my day?",
        "If I could thank one person today, who would it be and why?",
        "What was the biggest step I took towards my goal today?",
        "Did I have a meaningful conversation today?",
        "What was the best compliment or positive comment I received?",
        "What did I do today that nourished my spirit or soul?",
        "How did I show kindness today? When did I feel the most inner peace?",
        "Did I get closer to a dream or goal today?",
        "If I could sum up my day in one word, what would it be and why?"
        };

    public string GetRandomPrompt()
    {
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}