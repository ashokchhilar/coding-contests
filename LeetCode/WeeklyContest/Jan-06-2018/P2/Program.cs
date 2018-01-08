using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    class Program
    {

        public IList<Interval> mergeOverlaps(List<Interval> intervals)
        {
            List<Interval> overlaps = new List<Interval>();

            intervals.Sort(delegate (Interval i1, Interval i2)
            {
                return i1.start < i2.start ? -1 : i1 == i2 ? 0 : 1;
            });

            if (intervals.Count < 1) return intervals;
            Interval prev = intervals[0];

            for (int i = 1; i < intervals.Count; i++)
            {
                Interval inter = prev;
                if (prev.start <= intervals[i].start && prev.end >= intervals[i].start)
                {
                    inter = new Interval();
                    inter.start = prev.start;
                    if (intervals[i].end <= prev.end) inter.end = prev.end;
                    else inter.end = intervals[i].end;
                }

                else if (prev.start <= intervals[i].end && prev.end >= intervals[i].end)
                {
                    inter = new Interval();
                    inter.end = prev.end;
                    if (intervals[i].start <= prev.start) inter.start = intervals[i].start;
                    else inter.start = intervals[i].start;
                }

                else
                {
                    overlaps.Add(inter);
                    prev = intervals[i];
                }
            }
            overlaps.Add(prev);
            return overlaps;
        }

        public Interval HasOverlap(Interval i1, Interval i2)
        {
            Interval inter = null;

            if (i1.start <= i2.start && i1.end >= i2.start)
            {
                inter = new Interval();
                inter.start = i2.start;
                if (i2.end <= i1.end) inter.end = i2.end;
                else inter.end = i1.end;
            }

            else if (i1.start <= i2.end && i1.end >= i2.end)
            {
                inter = new Interval();
                inter.end = i2.end;
                if (i2.start <= i1.start) inter.start = i1.start;
                else inter.start = i2.start;
            }

            else if (i2.start <= i1.start && i2.end >= i1.start)
            {
                //one is completely inside the other, in this case, i1 is completely inside i2
                inter = new Interval(i1.start, i1.end);
            }

            return inter;
        }

        public IList<Interval> mergeIntervals(IList<Interval> interval1, IList<Interval> interval2)
        {
            List<Interval> merged = new List<Interval>();

            foreach (Interval inter in interval1)
            {
                foreach (Interval inter2 in interval2)
                {
                    var overlap = HasOverlap(inter, inter2);
                    if (overlap != null)
                    {
                        merged.Add(overlap);
                    }
                }
            }

            var result = mergeOverlaps(merged);
            return result;
        }

        public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> avails)
        {
            if (avails.Count == 1) return avails[0];

            IList<Interval> freetime = ConvertToFreeTime(avails[0]);
            for (int i = 1; i < avails.Count; i++)
            {
                freetime = mergeIntervals(freetime, ConvertToFreeTime(avails[i]));
            }

            return returnNonInf(freetime);
        }

        public List<Interval> returnNonInf(IList<Interval> inters)
        {
            List<Interval> final = new List<Interval>();
            for (int i = 0; i < inters.Count; i++)
            {
                if (inters[i].start != int.MinValue)
                {
                    if (inters[i].end != int.MaxValue)
                    {
                        if (inters[i].start != inters[i].end)
                            final.Add(inters[i]);
                    }
                }
                //if (!(inters[i].start == int.MinValue || inters[i].end == int.MaxValue)) final.Add(inters[i]);
            }

            return final;
        }

        public List<Interval> ConvertToFreeTime(IList<Interval> busyTime)
        {
            int start = int.MinValue;
            List<Interval> freetime = new List<Interval>();

            for (int i = 0; i < busyTime.Count; i++)
            {
                Interval inter = new Interval();
                inter.start = start;
                inter.end = busyTime[i].start;
                start = busyTime[i].end;

                freetime.Add(inter);
            }

            freetime.Add(new Interval(start, int.MaxValue));

            return freetime;
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            IList<IList<Interval>> avails = new List<IList<Interval>>();

            //[[[0,25],[29,31],[40,47],[57,87],[91,94]]]
            avails.Add(new List<Interval>() { new Interval(7, 24), new Interval(29, 33), new Interval(45, 57), new Interval(66, 69), new Interval(94, 99) });
            avails.Add(new List<Interval>() { new Interval(6, 24), new Interval(43, 49), new Interval(56, 59), new Interval(61, 75), new Interval(80, 81) });
            avails.Add(new List<Interval>() { new Interval(5, 16), new Interval(18, 26), new Interval(33, 36), new Interval(39, 57), new Interval(65, 74) });
            avails.Add(new List<Interval>() { new Interval(9, 16), new Interval(27, 35), new Interval(40, 55), new Interval(68, 71), new Interval(78, 81) });
            avails.Add(new List<Interval>() { new Interval(0, 25), new Interval(29, 31), new Interval(40, 47), new Interval(57, 87), new Interval(91, 94) });

            var result = p.EmployeeFreeTime(avails);
        }
    }
}
