using UnityEngine.UI;

public class Game : GameController<Game> //extends GameController abstract base class with type parameter for specification of internal methods types
{
    /// <summary>  
    ///  This component allows to keep specific Game state, by extending GameController base class. In this case the game is SRR (Savage Robot Run!).    
    /// </summary> 

    public Text hpUi; //reference to health points UI object
    public Text itemsUi; //reference to items score UI object

    private int items = 0; //initial number of items. 
    private int hp; //number of health points, to be retrieved from config on Start()
    private int damageAmount; //damage amount, to be retrieved from config on Start()

    void Start()
    {        
        hp = Config.intSetting(Config.IntSettings.playerHp);
        damageAmount = Config.intSetting(Config.IntSettings.damageAmount);
    }
    
    //raises number of items
    public void itemsUp()
    {
        items++;
    }

    //lowers health points based on damage amount. Eventually triggers game over through GameController base class
    public void hpDown()
    {
        hp -= damageAmount;
        if (hp <= 0) over();
    }
    
    void Update()
    {
        hpUi.text = "HP: " + hp.ToString(); //updates number of health points UI display
        itemsUi.text = "Items: " + items.ToString(); //updates items score UI display
    }
    
}
