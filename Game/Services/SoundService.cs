using Raylib_cs;
///using Batter.Casting;
using System.Collections.Generic;

namespace cse210_cycles.Game.Services
{
    public class AudioService
    {
        private Dictionary<string, Raylib_cs.Sound> _sounds
            = new Dictionary<string, Raylib_cs.Sound>();

        public AudioService()
        {
        }

        public void PlaySound(string filename)
        {
            
            if (!_sounds.ContainsKey(filename))
            {
                Raylib_cs.Sound loaded = Raylib.LoadSound(filename);
                _sounds[filename] = loaded;
            }
            Raylib_cs.Sound sound = _sounds[filename];
            Raylib.PlaySound(sound);
        }

        public void StartAudio()
        {
            Raylib.InitAudioDevice();
        }

        public void StopAudio()
        {
            Raylib.CloseAudioDevice();
        }
    }
}