using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_hours_select
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] event_start_list = {10.00, 10.00, 11.00, 11.30, 12.30, 13.00, 13.00, 13.30, 14.00, 14.00, 15.00, 16.00 };
            double[] event_end_list =   {10.30, 11.30, 14.00, 12.30, 14.30, 15.50, 16.15, 14.00, 15.15, 14.40, 16.30, 17.00 };
            List<int> max_event_list = max_event(event_start_list, event_end_list);
        }

        static List<int> max_event(double[] event_start_list, double[] event_end_list)
        {
            List<int> event_list_main = new List<int>();
            List<int> event_list_temp = new List<int>();

            event_list_temp.Add(0);
            for(int i = 0; i < event_start_list.Length;i++)
            {
                for(int j = 0; j < event_end_list.Length; j++)
                {
                    if (event_list_tempCount(0) == 0) ;
                }
            }




            return event_list_main;
        }
    }
}
