//using Vidly.Models.Meetup;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.Web.Http;
//using Newtonsoft.Json;
//using Vidly.Models.Eventbrite;
//using Evy.Models;

//namespace Vidly.Controllers.Api
//{
//    public class EventsController : ApiController
//    {
//        private const string EventbriteAPIToken = "65ZR4NWR2F4XONLSO2EL";
//        private const string MeetupAPIKey = "a7e653715d7c442a3d2011279384b";

//        // GET: api/Events/
//        public async Task<List<EvyEvent>> Get(string _searchTerm)
//        {
//            var meetupEvents = new MeetupModel();
//            var eventBriteEvents = new EventbriteModel();
//            var allEvents = new List<EvyEvent>();


//            meetupEvents = await GetMeetupEvents(_searchTerm);
//            eventBriteEvents = await GetEventBriteEvents(_searchTerm);
//            Console.WriteLine(meetupEvents);


//            //Organize Meetup events
//            if (meetupEvents.results != null)
//            {
//                foreach (var meetupEvent in meetupEvents.results)
//                {
//                    allEvents.Add(new EvyEvent()
//                    {
//                        Name = meetupEvent.name,
//                        Description = meetupEvent.description,
//                        StartDate = meetupEvent.time.ToString(),
//                        Url = meetupEvent.event_url,
//                        Source = "Meetup"
//                    });
//                }
//            }

//            //Organize EventBrite Events
//            if (eventBriteEvents.events != null)
//            {
//                foreach (var eventBriteEvent in eventBriteEvents.events)
//                {
//                    allEvents.Add(new EvyEvent()
//                    {
//                        Name = eventBriteEvent.name.text,
//                        Description = eventBriteEvent.description.text,
//                        StartDate = eventBriteEvent.start.local.ToShortDateString(),
//                        Url = eventBriteEvent.url,
//                        Source = "EventBrite"
//                    });
//                }
//            }

//            return allEvents;
//        }

//        private async Task<MeetupModel> GetMeetupEvents(string _serachTerm)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("https://api.meetup.com/2/");

//                client.DefaultRequestHeaders.Accept.Clear();
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                HttpResponseMessage response = new HttpResponseMessage();
//                response = await client.GetAsync(string.Format("open_events.json?topic={0}&time=,1w&key={1}", _serachTerm, MeetupAPIKey));

//                if (response.IsSuccessStatusCode)
//                {
//                    string eventsJson = await response.Content.ReadAsStringAsync();

//                    var allMeetupEvents = JsonConvert.DeserializeObject<MeetupModel>(eventsJson);

//                    return allMeetupEvents;
//                }
//            }
//            return null;
//        }
//        private async Task<EventbriteModel> GetEventBriteEvents(string _searchTerm)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("https://www.eventbriteapi.com/v3/");
//                var address = string.Format("events/search/?token={0}&q={1}", EventbriteAPIToken, _searchTerm);

//                client.DefaultRequestHeaders.Accept.Clear();
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                HttpResponseMessage response = new HttpResponseMessage();
//                response = await client.GetAsync(address);

//                if (response.IsSuccessStatusCode)
//                {
//                    string eventsJson = await response.Content.ReadAsStringAsync();
//                    var allEventBriteEvents = JsonConvert.DeserializeObject<EventbriteModel>(eventsJson);

//                    return allEventBriteEvents;
//                }
//            }
//            return null;
//        }

//        // POST: api/Events
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT: api/Events/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE: api/Events/5
//        public void Delete(int id)
//        {
//        }
//    }
//}
