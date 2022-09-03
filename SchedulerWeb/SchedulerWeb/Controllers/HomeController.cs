using SchedulerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulerWeb.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Schedule()
        {
            List<slot> list = new Schedule().GetSchedule();
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j].Days.ID > list[j + 1].Days.ID)
                    {
                        slot temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                    else if (list[j].Days.ID == list[j+1].Days.ID)
                    {
                        if (list[j].Timeslots.ID > list[j + 1].Timeslots.ID)
                        {
                            slot temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].clash != true)
                {
                    for ( int j = 0; j < list.Count; j++)
                    {
                        if (i != j)
                        {
                            if (list[i].Days.ID == list[j].Days.ID && list[i].room.ID == list[j].room.ID && list[i].Timeslots.ID == list[j].Timeslots.ID || list[i].Days.ID == list[j].Days.ID && list[i].classid.teacher.ID == list[j].classid.teacher.ID && list[i].Timeslots.ID == list[j].Timeslots.ID)
                            {
                                list[i].clash = true;
                                list[j].clash = true;
                            }
                        }
                    }
                }
            }
            return View(list);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        static void bubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i] 
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}