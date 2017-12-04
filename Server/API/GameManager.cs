using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServerHandler;
using ServerHandler.API;

namespace Server.API
{
    public class GameManager
    {

        private Config _config;
        
        public GameManager()
        {
            _config = new Config();
            new Listener().longPooling(async (fPlayer, sPlayer) =>
            {
                fPlayer.send("go");
                sPlayer.send("go");
                gameLoop(fPlayer, sPlayer);
            });
        }

        private void gameLoop(Player fPlayer, Player sPlayer)
        {
            while (true)
            {
                // TODO реализовать gameLoop
                JObject fInfo = fPlayer.info();
                JObject sInfo = sPlayer.info();
                JObject ballPosition = JObject.Parse((string) fInfo["ballPosition"]);
                if ((string) ballPosition["go"] == "right")
                {
                    ballPosition["margin"] = (double) ballPosition["margin"] - _config.ballSpeed;
                }
                else
                {
                    ballPosition["margin"] = (double) ballPosition["margin"] + _config.ballSpeed;
                }

                fInfo["ballPosition"] = ballPosition;
                sInfo["ballPosition"] = ballPosition;
                fPlayer.send(JsonConvert.SerializeObject(sInfo));
                sPlayer.send(JsonConvert.SerializeObject(fInfo));
            }
        }
        
    }
}