using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerWeb.Models
{
    public class Schedule
    {
        public List<slot> schedule { get; set; }
        public int clashes { get; set; }

        List<TeacherTiming> teacherTimings = new connection().GetTeacherTimings();
        List<Room> rooms = new connection().GetRooms();
        List<Days> day = new connection().GetDays();
        List<Timeslots> timeSlots = new connection().GetTimeslots();
        List<TeacherClass> courseTeachers = new connection().GetTeacherClasses();
        List<TeacherClass> courseTeacherstemp = new connection().GetTeacherClasses();
        List<Classes> classes = new connection().GetClasses();
        List<slot> Initial = new List<slot>();
        List<slot> slots1 = new List<slot>();
        List<slot> slots2 = new List<slot>();
        List<slot> slots3 = new List<slot>();
        Schedule s1;
        Schedule s2;
        Schedule s3;
        Schedule s4;
        Schedule selected1;
        Schedule selected2;

        public void population()
        {
            Random random = new Random();
            Initial = new List<slot>();
            for (int i = 0; i < classes.Count - 1; i++)
            {
                slot s = new slot();
                int x = random.Next(0, courseTeachers.Count);
                s.classid = courseTeachers[x];
                courseTeacherstemp.Add(courseTeachers[x]);
                courseTeachers.RemoveAt(x);

                x = random.Next(0, day.Count);
                s.Days = day[x];

                x = random.Next(0, rooms.Count);
                s.room = rooms[x];

                x = random.Next(0, timeSlots.Count);
                s.Timeslots = timeSlots[x];
                Initial.Add(s);
            }
            courseTeachers = courseTeacherstemp;
            courseTeacherstemp = new List<TeacherClass>();

            slots1 = new List<slot>();
            for (int i = 0; i < classes.Count - 1; i++)
            {
                slot s = new slot();
                int x = random.Next(0, courseTeachers.Count);
                s.classid = courseTeachers[x];
                courseTeacherstemp.Add(courseTeachers[x]);
                courseTeachers.RemoveAt(x);

                x = random.Next(0, day.Count);
                s.Days = day[x];

                x = random.Next(0, rooms.Count);
                s.room = rooms[x];

                x = random.Next(0, timeSlots.Count);
                s.Timeslots = timeSlots[x];
                slots1.Add(s);
            }
            courseTeachers = courseTeacherstemp;
            courseTeacherstemp = new List<TeacherClass>();
            slots2 = new List<slot>();
            for (int i = 0; i < classes.Count - 1; i++)
            {
                slot s = new slot();
                int x = random.Next(0, courseTeachers.Count);
                s.classid = courseTeachers[x];
                courseTeacherstemp.Add(courseTeachers[x]);
                courseTeachers.RemoveAt(x);

                x = random.Next(0, day.Count);
                s.Days = day[x];

                x = random.Next(0, rooms.Count);
                s.room = rooms[x];

                x = random.Next(0, timeSlots.Count);
                s.Timeslots = timeSlots[x];
                slots2.Add(s);
            }
            courseTeachers = courseTeacherstemp;
            courseTeacherstemp = new List<TeacherClass>();
            slots3 = new List<slot>();
            for (int i = 0; i < classes.Count - 1; i++)
            {
                slot s = new slot();
                int x = random.Next(0, courseTeachers.Count);
                s.classid = courseTeachers[x];
                courseTeacherstemp.Add(courseTeachers[x]);
                courseTeachers.RemoveAt(x);

                x = random.Next(0, day.Count);
                s.Days = day[x];

                x = random.Next(0, rooms.Count);
                s.room = rooms[x];

                x = random.Next(0, timeSlots.Count);
                s.Timeslots = timeSlots[x];
                slots3.Add(s);
            }
            courseTeachers = courseTeacherstemp;
            courseTeacherstemp = new List<TeacherClass>();
        }


        public void fitness()
        {
            int fitnessscore = -1;
            for (int i = 0; i < Initial.Count; i++)
            {
                bool check = true;
                for (int j = 0; j < Initial.Count; j++)
                {
                    
                    if (Initial[i].Days == Initial[j].Days && Initial[i].room == Initial[j].room && Initial[i].Timeslots == Initial[j].Timeslots)
                    {
                        fitnessscore++;
                        check = false;
                    }
                    
                }
                if(check)
                {
                    bool check2 = true;
                    for (int j = 0; j < teacherTimings.Count; j++)
                    {
                        if (Initial[i].classid.teacher.ID == teacherTimings[j].Teacher.ID)
                        {
                            if (Initial[i].Days.ID == teacherTimings[j].Days.ID && Initial[i].Timeslots.ID == teacherTimings[j].Timeslots.ID)
                            {
                                check2 = false;
                                break;
                            }

                        }
                    }

                    if (check2)
                    {
                        fitnessscore++;
                    }
                }
            }


            s1 = new Schedule();
            s1.schedule = Initial;
            s1.clashes = fitnessscore;
            fitnessscore = -1;


            for (int i = 0; i < slots1.Count; i++)
            {
                bool check = true;
                for (int j = 0; j < slots1.Count; j++)
                {

                    if (slots1[i].Days == slots1[j].Days && slots1[i].room == slots1[j].room && slots1[i].Timeslots == slots1[j].Timeslots)
                    {
                        fitnessscore++;
                        check = false;
                    }

                }
                if (check)
                {
                    bool check2 = true;
                    for (int j = 0; j < teacherTimings.Count; j++)
                    {
                        if (slots1[i].classid.teacher.ID == teacherTimings[j].Teacher.ID)
                        {
                            if (slots1[i].Days.ID == teacherTimings[j].Days.ID && slots1[i].Timeslots.ID == teacherTimings[j].Timeslots.ID)
                            {
                                check2 = false;
                                break;
                            }

                        }
                    }

                    if (check2)
                    {
                        fitnessscore++;
                    }
                }
            }


            s2 = new Schedule();
            s2.schedule = slots1;
            s2.clashes = fitnessscore;
            fitnessscore = -1;


            for (int i = 0; i < slots2.Count; i++)
            {
                bool check = true;
                for (int j = 0; j < slots2.Count; j++)
                {

                    if (slots2[i].Days == slots2[j].Days && slots2[i].room == slots2[j].room && slots2[i].Timeslots == slots2[j].Timeslots)
                    {
                        fitnessscore++;
                        check = false;
                    }

                }
                if (check)
                {
                    bool check2 = true;
                    for (int j = 0; j < teacherTimings.Count; j++)
                    {
                        if (slots2[i].classid.teacher.ID == teacherTimings[j].Teacher.ID)
                        {
                            if (slots2[i].Days.ID == teacherTimings[j].Days.ID && slots2[i].Timeslots.ID == teacherTimings[j].Timeslots.ID)
                            {
                                check2 = false;
                                break;
                            }

                        }
                    }

                    if (check2)
                    {
                        fitnessscore++;
                    }
                }
            }


            s3 = new Schedule();
            s3.schedule = slots2;
            s3.clashes = fitnessscore;
            fitnessscore = -1;


            for (int i = 0; i < slots3.Count; i++)
            {
                bool check = true;
                for (int j = 0; j < slots3.Count; j++)
                {

                    if (slots3[i].Days == slots3[j].Days && slots3[i].room == slots3[j].room && slots3[i].Timeslots == slots3[j].Timeslots)
                    {
                        fitnessscore++;
                        check = false;
                    }

                }
                if (check)
                {
                    bool check2 = true;
                    for (int j = 0; j < teacherTimings.Count; j++)
                    {
                        if (slots3[i].classid.teacher.ID == teacherTimings[j].Teacher.ID)
                        {
                            if (slots3[i].Days.ID == teacherTimings[j].Days.ID && slots3[i].Timeslots.ID == teacherTimings[j].Timeslots.ID)
                            {
                                check2 = false;
                                break;
                            }

                        }
                    }

                    if (check2)
                    {
                        fitnessscore++;
                    }
                }
            }


            s4 = new Schedule();
            s4.schedule = slots3;
            s4.clashes = fitnessscore;
        }

        public void crossover()
        {
            selected1 = new Schedule();
            selected2 = new Schedule();
            int[] clashes = new int[] { s1.clashes, s2.clashes, s3.clashes, s4.clashes };
            Array.Sort(clashes);

            Random r = new Random();
            if (clashes[0] == s1.clashes)
            {
                selected1.schedule = new List<slot>();
                for (int i = 0; i < s1.schedule.Count; i++)
                {
                    selected1.schedule.Add(s1.schedule[i]);
                }
                selected1.clashes = s1.clashes;
            }
            else if (clashes[0] == s2.clashes)
            {
                selected1.schedule = new List<slot>();
                for (int i = 0; i < s1.schedule.Count; i++)
                {
                    selected1.schedule.Add(s2.schedule[i]);
                }
                selected1.clashes = s2.clashes;
            }
            else if (clashes[0] == s3.clashes)
            {
                selected1.schedule = new List<slot>();
                for (int i = 0; i < s1.schedule.Count; i++)
                {
                    selected1.schedule.Add(s3.schedule[i]);
                }
                selected1.clashes = s3.clashes;
            }
            else if (clashes[0] == s4.clashes)
            {
                selected1.schedule = new List<slot>();
                for (int i = 0; i < s1.schedule.Count; i++)
                {
                    selected1.schedule.Add(s4.schedule[i]);
                }
                selected1.clashes = s4.clashes;
            }

            if (clashes[1] == s4.clashes)
            {
                selected2.schedule = new List<slot>();
                for (int i = 0; i < s1.schedule.Count; i++)
                {
                    selected2.schedule.Add(s4.schedule[i]);
                }
                selected2.clashes = s4.clashes;
            }
            else if (clashes[1] == s3.clashes)
            {
                selected2.schedule = new List<slot>();
                for (int i = 0; i < s1.schedule.Count; i++)
                {
                    selected2.schedule.Add(s3.schedule[i]);
                }
                selected2.clashes = s3.clashes;
            }
            else if (clashes[1] == s2.clashes)
            {
                selected2.schedule = new List<slot>();
                for (int i = 0; i < s1.schedule.Count; i++)
                {
                    selected2.schedule.Add(s2.schedule[i]);
                }
                selected2.clashes = s2.clashes;
            }
            else if (clashes[1] == s1.clashes)
            {
                selected2.schedule = new List<slot>();
                for (int i = 0; i < s1.schedule.Count; i++)
                {
                    selected2.schedule.Add(s1.schedule[i]);
                }
                selected2.clashes = s1.clashes;
            }

            List<slot> temp = selected1.schedule;
            for (int i = 0; i < selected1.schedule.Count / 2; i++)
            {
                selected1.schedule[i] = selected2.schedule[i];
                selected2.schedule[i] = temp[i];
            }
        }

        public void mutation()
        {
            int repitition = 0;
            for (int i = 0; i < selected1.schedule.Count; i++)
            {
                for (int j = 0; j < selected1.schedule.Count; j++)
                {
                    if (selected1.schedule[i].classid.classes.ID == selected1.schedule[j].classid.classes.ID)
                    {
                        repitition++;
                        if (repitition > 1)
                        {
                            selected1.schedule.RemoveAt(j);

                            break;
                        }
                    }

                }
                repitition = 0;
            }


            for (int i = 0; i < selected2.schedule.Count; i++)
            {
                for (int j = 0; j < selected2.schedule.Count; j++)
                {
                    if (selected2.schedule[i].classid.classes.ID == selected2.schedule[j].classid.classes.ID)
                    {
                        repitition++;
                        if (repitition > 1)
                        {
                            selected2.schedule.RemoveAt(j);

                            break;
                        }
                    }

                }
                repitition = 0;
            }



            for (int i = 0; i < Initial.Count; i++)
            {
                bool check = false;
                for (int j = 0; j < selected1.schedule.Count; j++)
                {
                    if (selected1.schedule[j].classid.classes.ID == Initial[i].classid.classes.ID)
                    {
                        check = true;
                        break;
                    }
                }
                if (!check)
                {
                    selected1.schedule.Add(Initial[i]);
                }
            }

            for (int i = 0; i < slots2.Count; i++)
            {
                bool check = false;
                for (int j = 0; j < slots2.Count; j++)
                {
                    if (selected2.schedule[j].classid.classes.ID == slots2[i].classid.classes.ID)
                    {
                        check = true;
                        break;
                    }
                }
                if (!check)
                {
                    selected1.schedule.Add(slots2[i]);
                }
            }

        }

        public List<slot> GetSchedule()
        {
            int fitness1;
            int fitness2;
            int x = 0;
            while (true)
            {
                population();
                fitness();
                crossover();
                mutation();
                x++;
                fitness1 = -1;
                for (int i = 0; i < selected1.schedule.Count; i++)
                {
                    for (int j = 0; j < selected1.schedule.Count; j++)
                    {
                        if (selected1.schedule[i].Days == selected1.schedule[j].Days && selected1.schedule[i].room == selected1.schedule[j].room && selected1.schedule[i].Timeslots == selected1.schedule[j].Timeslots)
                        {
                            fitness1++;
                        }
                    }
                }
                if (fitness1 == 0)
                {
                    return selected1.schedule;
                }
                fitness2 = -1;
                for (int i = 0; i < selected2.schedule.Count; i++)
                {
                    for (int j = 0; j < selected2.schedule.Count; j++)
                    {
                        if (selected2.schedule[i].Days == selected2.schedule[j].Days && selected2.schedule[i].room == selected2.schedule[j].room && selected2.schedule[i].Timeslots == selected2.schedule[j].Timeslots)
                        {
                            fitness2++;
                        }
                    }
                }
                if (fitness2 == 0)
                {
                    return selected2.schedule;
                }
                if (x == 50)
                    break;
            }
            if (fitness1 > fitness2)
            {
                return selected2.schedule;
            }
            else
            {
                return selected1.schedule;
            }
            //population();
            //fitness();
            //crossover();
            //mutation();
            //return selected1.schedule;
        }

    }
}