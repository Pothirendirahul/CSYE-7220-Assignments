using Microsoft.AspNetCore.Mvc;
using SongLyricsAPI.Models;

namespace SongLyricsAPI.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class SongsController : ControllerBase
{
    private static readonly List<Song> Songs = new List<Song>
    {
        new Song { Title = "Bohemian Rhapsody", Artist = "Queen", Lyrics = "Is this the real life? Is this just fantasy?..." },
        new Song { Title = "Lose Yourself", Artist = "Eminem", Lyrics = "Look, if you had one shot or one opportunity..." },
        new Song { Title = "Imagine", Artist = "John Lennon", Lyrics = "Imagine all the people..." },
        new Song { Title = "Shape of You", Artist = "Ed Sheeran", Lyrics = "The club isn't the best place to find a lover..." }
    };

    [HttpGet]
    public IEnumerable<Song> GetSongs() => Songs;


    [HttpGet("search")]
    public ActionResult<Song> GetSongByTitle([FromQuery] string title)
    {
        var song = Songs.FirstOrDefault(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (song == null) return NotFound();
        return song;
    }
}

}
