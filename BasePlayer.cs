using System;

public class BasePlayer
{
    private string name;
    private bool inGame;
    public string Name { get; set; }

    public BasePlayer(string name, bool inGame = false)
	{
        this.Name = name;
        this.inGame = inGame;
    }

    public bool JoinGame()
    {
        if (inGame)
            return false;
        else
        {
            inGame = true;
            return true;
        }
    }

    public bool IsInGame()
    {
        return inGame;
    }

}
