using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InsertNameHere.Controller
{
    public class ContentLoader
    {
        /// <summary>
        /// Basic ContentManager to Load from basetexture Catalog
        /// </summary>
        ContentManager content;

        /// <summary>
        /// TextureCache
        /// </summary>
        public ConcurrentDictionary<string, Texture2D> textureCache;

        /// <summary>
        /// SoundEffect
        /// </summary>
        public ConcurrentDictionary<string, SoundEffect> sfxCache;

        /// <summary>
        /// BasePath for Levelspecific modified Files (Pythons/png/wav)
        /// </summary>
        string basepath;

        /// <summary>
        /// GraphicDevice for Loading and Converting the Textures
        /// </summary>
        GraphicsDevice g;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="c"></param>
        /// <param name="basepath"></param>
        public ContentLoader(ContentManager c, string basepath)
        {
            content = c;
            this.basepath = basepath;
        }

        /// <summary>
        /// Loads a given pngfile as a named Texture and stores it in the TextureCache
        /// </summary>
        /// <param name="texturename"></param>
        /// <returns></returns>
        public Texture2D LoadTexture(string texturename)
        {
            string texPath = Path.Combine(basepath, "/Textures/", texturename + ".png");
            Texture2D res;

            try
            {
                Logger.Shoot("Trying to Load " + texturename + " from basepath");
                if (textureCache.ContainsKey(texturename))
                {
                    Logger.Shoot(texturename + " is already loaded");
                    return textureCache[texturename];
                }
                else
                {
                    res = Texture2D.FromStream(g, File.Open(texPath, FileMode.Open));
                    textureCache.TryAdd(texturename, res);
                    return res;
                }
            }
            catch (Exception)
            {
                Logger.Shoot(texturename + " in basepath not found or wrong format");
            }

            try
            {
                Logger.Shoot("Loading DefaultTexture from the Gamefolder");
                res = content.Load<Texture2D>(texturename + ".png");
                textureCache.TryAdd(texturename, res);
                return res;
            }
            catch (Exception e)
            {
                Logger.Shoot("ERROR LOADING TEXTURE! \n\n" + e.Message);
                res = new SolidColorTexture2D(g, Color.Red);
                textureCache.TryAdd(texturename, res);
                return res;
            }
        }

        /// <summary>
        /// Loads a given wavfile as a named SoundEffect and stores it in the sfxCache
        /// </summary>
        /// <param name="sfxname"></param>
        /// <returns></returns>
        public SoundEffect LoadSFX(string sfxname)
        {
            string sfxPath = Path.Combine(basepath, "/SFX/", sfxname + ".wav");
            SoundEffect res;

            try
            {
                Logger.Shoot("Trying to Load SFX " + sfxname + " from basepath");
                if (textureCache.ContainsKey(sfxname))
                {
                    Logger.Shoot(sfxname + " is already loaded");
                    return sfxCache[sfxname];
                }
                else
                {
                    res = SoundEffect.FromStream(File.Open(sfxPath, FileMode.Open));
                    sfxCache.TryAdd(sfxname, res);
                    return res;
                }
            }
            catch (Exception)
            {
                Logger.Shoot(sfxname + " in basepath not found or wrong format");
            }

            try
            {
                Logger.Shoot("Loading DefaultSFX from the Gamefolder");
                res = content.Load<SoundEffect>(sfxname + ".wav");
                sfxCache.TryAdd(sfxname, res);
                return res;
            }
            catch (Exception e)
            {
                Logger.Shoot("ERROR LOADING SFX! \n\n" + e.Message);
                res = null;
                return res;
            }
        }

        /// <summary>
        /// Loads PythonScript by name
        /// </summary>
        /// <param name="name">something like "KI\\swarm.py</param>
        /// <param name="classname"></param>
        /// <returns></returns>
        public PythonLoader LoadScript(string name, string classname = "INH")
        {
            Logger.Shoot("Trying to Load PythonScript " + name + " from basepath");
            string scrPath = Path.Combine(basepath, "/Scripts/", name + ".py");
            PythonLoader res = new PythonLoader(File.ReadAllText(scrPath), classname);
            return res;

        }
           
    }
}
