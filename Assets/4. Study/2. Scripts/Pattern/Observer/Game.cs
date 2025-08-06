using UnityEngine;
using Pattern.Observer;

namespace Pattern
{
    public class Game : MonoBehaviour
    {
        void Start()
        {
            Player player = new Player();

            player.Scroe += 100;
            player.Scroe += 500;
            player.Scroe += 1000;
        }
    }
}