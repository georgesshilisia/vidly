using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Controllers.Api;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Evy.Models;
using Vidly.Models.Meetup;


namespace Vidly.Controllers
{
    public class EvyEventsController : Controller
    {
        private EvyEventDbContext db = new EvyEventDbContext();
         
        private const string EventbriteAPIToken = "65ZR4NWR2F4XONLSO2EL";
        private const string MeetupAPIKey = "a7e653715d7c442a3d2011279384b";

        public ActionResult SearchEvent()
        {
            return View();
        }

        // GET: EvyEvents
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.MyEntities.ToListAsync());
        //}


        // GET: EvyEvents
        [HandleError()]
        public async Task<ActionResult> SearchResults(string searchTerm)
        {

            //var meetupEvents = new MeetupModel();
            //var eventBriteEvents = new Rootobject();
            //var allEvents = new List<EvyEvent>();


            //meetupEvents = await GetMeetupEvents(searchTerm);
            //eventBriteEvents = await GetEventBriteEvents(searchTerm);

            //if (meetupEvents.results != null)
            //{
            //    foreach (var meetupEvent in meetupEvents.results)
            //    {
            //        allEvents.Add(new EvyEvent()
            //        {
            //            Name = meetupEvent.name,
            //            Description = meetupEvent.description,
            //        });

                    //EventsEventsRepository repo = new EventsEventsRepository();

                    //return View(await repo.SearchEvents(searchTerm));

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://api.meetup.com/2/");

                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = new HttpResponseMessage();
                        response = await client.GetAsync(string.Format("open_events.json?topic={0}&time=,1w&key={1}", searchTerm, MeetupAPIKey));


                        if (response.IsSuccessStatusCode)
                        {
                            string eventsJson = await response.Content.ReadAsStringAsync();

                            var allMeetupEvents = JsonConvert.DeserializeObject<Vidly.Models.Rootobject>(eventsJson);

                            var list = allMeetupEvents.results.ToList();

                            for (int i = 0; i < list.Count; i++)
                            {
                                var item = list[i];

                                var dbResults = db.Result.FirstOrDefault(k => k.id == item.id);

                                if (dbResults == null)
                                {
                                    db.Result.Add(list[i]);
                                }
                                

                            }
                            db.SaveChanges();



                            return View(allMeetupEvents.results.ToList());

                            
                            
                        }
                    }
                    return null;
                }
       
       
       
            }
        }

        //private Task<MeetupModel> GetMeetupEvents(string searchTerm)
        //{
        //    throw new NotImplementedException();
        //}

//        private Task<Rootobject> GetEventBriteEvents(string searchTerm)
//        {
//            throw new NotImplementedException();
//        }
 
//    }
//}
       
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://www.eventbriteapi.com/v3/");
        //        var address = string.Format("events/search/?token={0}&q={1}", EventbriteAPIToken, _searchTerm);

        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = new HttpResponseMessage();
        //        response = await client.GetAsync(address);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string eventsJson = await response.Content.ReadAsStringAsync();
        //            var allEventBriteEvents = JsonConvert.DeserializeObject<EventbriteModel>(eventsJson);

        //            return View(allEventBriteEvents.results.ToList());
        //        }
        //    }
        //    return null;
        //}
//        public async Task <ActionResult> Edit(int? id)
//        {

//            if (id == null)
//                return HttpNotFound();
            


//            EvyEvent evyEvent = await db.MyEntities.FindAsync(id);
//            if (evyEvent == null)
//            {
//                return HttpNotFound();
//            }
//            return View(evyEvent);
//        }

        
//        // GET: EvyEvents/Details/5
//        public async Task<ActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            EvyEvent evyEvent = await db.MyEntities.FindAsync(id);
//            if (evyEvent == null)
//            {
//                return HttpNotFound();
//            }
//            return View(evyEvent);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
