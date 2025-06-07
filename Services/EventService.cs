using EventEase.Models;

namespace EventEase.Services
{
	public class EventService
	{
		public EventService()
		{
			cards = [];
			attendees = [];
		}
		public void AddCard(Card card)
		{
			cards.Add(card);
			attendees.Add(card.Id, []);
		}
		public Card? GetCard(int id)
		{
			return cards.Find(card => card.Id == id);
		}
		public void AddAttendee(int eventID, User user)
		{
			attendees[eventID].Add(user);
		}
		public IEnumerable<Card> GetCards() => cards;
		public IEnumerable<User> GetAttendees(int eventID) => attendees[eventID];
		private List<Card> cards;
		private Dictionary<int, List<User>> attendees;
	}
}