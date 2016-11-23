using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts
{
    public class Background : MonoBehaviour
    {
        public GameObject Tile;
        private float tileScale;
        private readonly HashSet<GameObject> tiles;
        private float viewportHalfHeight;
        private float viewportHalfWidth;
        private UnityEngine.Camera camera;

        public Background()
        {
            this.tiles = new HashSet<GameObject>();
        }

        private void Start()
        {
            this.tileScale = this.Tile.GetComponent<Renderer>().bounds.size.x;
            this.camera = this.GetComponent<UnityEngine.Camera>();

            this.viewportHalfHeight = camera.orthographicSize;
            this.viewportHalfWidth = viewportHalfHeight * camera.aspect;

            for(int x = 0; x < viewportHalfWidth / tileScale + 2; x++)
            {
                for(int y = 0; y < viewportHalfHeight / tileScale + 2; y++)
                {
                    this.CreateTile(x, y);

                    if(x != 0)
                    {
                        this.CreateTile(-x, y);
                    }

                    if(y != 0)
                    {
                        this.CreateTile(x, -y);
                    }

                    if(x != 0 && y != 0)
                    {
                        this.CreateTile(-x, -y);
                    }
                }
            }
        }

        private void Update()
        {
        }

        private void CreateTile(int x, int y)
        {
            var tilePosition = new Vector2(x * this.tileScale, y * this.tileScale);
            var tile = Instantiate(this.Tile, tilePosition, Quaternion.identity) as GameObject;
            this.tiles.Add(tile);
        }
    }
}
