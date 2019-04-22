using UnityEngine;
using System.Collections;

public class Share : MonoBehaviour {
    
    public GameLogic gamelogic;
    // Use this for initialization

    /* TWITTER VARIABLES*/

    //Twitter Share Link
    string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";

    //Language
    string TWEET_LANGUAGE = "en";

    //This is the text which you want to show
    string textToDisplay = "#Free #Game #indiedev #PlayStore #RocketSquirrel #App #Mobile \n"+"https://play.google.com/store/apps/details?id=com.xulipasoftworks.RocketSquirrel \nHey Guys! Check out my score on Rocket Squirrel: ";

    /*END OF TWITTER VARIABLES*/

    /* FACEBOOK VARAIBLES */

    //App ID
    string AppID = "796444554029196";

    //This link is attached to this post
    string Link = "https://play.google.com/store/apps/details?id=com.xulipasoftworks.RocketSquirrel";

    //The URL of a picture attached to this post. The Size must be atleat 200px by 200px.
    string Picture = "https://i.imgur.com/s6eqDGb.png";

    //The Caption of the link appears beneath the link name
    string Caption = "Check out My Score on Rocket Squirrel: ";

    //The Description of the link
    string Description = "Rocket Squirrel, available now on the Google Play Store. Play it for FREE";

    /* END OF FACEBOOK VARIABLES */

    // Twitter Share Button	
    public void shareScoreOnTwitter()
    {
        Application.OpenURL(TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(textToDisplay) + gamelogic.Pontuacao + "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
    }

    // Facebook Share Button
    public void shareScoreOnFacebook()
    {
        Application.OpenURL("https://www.facebook.com/dialog/feed?" + "app_id=" + AppID + "&link=" + Link + "&picture=" + Picture
                             + "&caption=" + Caption + gamelogic.Pontuacao + "&description=" + Description);
    }
    
}
