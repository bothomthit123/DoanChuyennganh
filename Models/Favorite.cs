using SmartTravelAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Favorite
{
    public int FavoriteId { get; set; }
    public int AccountId { get; set; }
    public int PlaceId { get; set; }
    public DateTime SavedAt { get; set; }

    public Account Account { get; set; }
    public Place Place { get; set; }
}
