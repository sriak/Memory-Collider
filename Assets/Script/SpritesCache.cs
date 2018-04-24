﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesCache : MonoBehaviour {
    private static SpritesCache _instance;

    private Dictionary<string, Sprite> spriteCache = new Dictionary<string, Sprite>();

    public static SpritesCache instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.

            if (_instance == null)
                _instance = GameObject.FindObjectOfType<SpritesCache>();
            return _instance;
        }
    }

    public Sprite LoadSprite(string path)
    {
        Sprite sprite = null;
        if (!spriteCache.TryGetValue(path, out sprite))
        {
            sprite = IMG2Sprite.instance.LoadNewSprite(path);
            spriteCache.Add(path, sprite);
        }

        return sprite;
    }

}