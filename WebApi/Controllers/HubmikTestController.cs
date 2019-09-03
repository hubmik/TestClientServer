using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class HubmikTestController : ApiController
    {
        //[Route(Name = "api/HubmikTest/WypiszKomunikatDnia")]
        public string Get(DateTime dzisiejszyDzien)
        {
            string komunikat = "";

            switch (dzisiejszyDzien.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    komunikat = "Dzisiaj poniedziałek.";
                    break;
                case DayOfWeek.Tuesday:
                    komunikat = "Dziś wtorek.";
                    break;
                case DayOfWeek.Wednesday:
                    komunikat = "Dzisiaj środa.";
                    break;
                case DayOfWeek.Thursday:
                    komunikat = "Dziś czwartek.";
                    break;
                case DayOfWeek.Friday:
                    komunikat = "Piątek wreszcie.";
                    break;
                case DayOfWeek.Saturday:
                    komunikat = "Dzisiaj sobota.";
                    break;
                case DayOfWeek.Sunday:
                    komunikat = "Dziś niedziela.";
                    break;
            }

            return komunikat;
        }
    }
}