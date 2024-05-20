using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Calculations
    {
        //multiple tests on correct working
        //invalid data test:
        // array sizes are not equals = exception
        // endWorking time < beginWorkingTime = Exception
        // consultTime < 0 = excception 
        // endWorkingTime great than 24 hours = exception
        // begin time must be less or equals that StartTimes[0]

        public string[] AvailablePeriod(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            if (startTimes.Length != durations.Length)
            {
                throw new Exception("набор стартов должен равняться набору продолжительностей");

            }
            else if (endWorkingTime < beginWorkingTime)
            {
                throw new Exception("рабочий день не может заканчиваться, не начавшись");
            }
            else if (consultationTime < 0)
            {
                throw new Exception("время консультации не может быть отрицательным");
            }
            else if (endWorkingTime.TotalHours > 24)
            {
                throw new Exception("в сутках всего 24 часа!!");
            }
            else if (startTimes.Length != 0 && beginWorkingTime >= startTimes[0])
            {

                throw new Exception("часы приема не могут начинаться раньше рабочего дня");
            }

            List<string> result = new List<string>();
            //массивы занятых интервалов пустые, тогда возвращаем интервал = конец дня - начало дня, если он больше consultTime
            if (startTimes.Length == 0)
            {
                if ((endWorkingTime - beginWorkingTime).TotalMinutes >= consultationTime)
                {
                    return new string[]
                    {
                    $"{beginWorkingTime.ToString("hh':'mm")}-{endWorkingTime.ToString("hh':'mm")}"
                    };
                }
            }


            if ((startTimes[0] - beginWorkingTime).TotalMinutes >= consultationTime)
            {
                result.Add($"{beginWorkingTime.ToString("hh':'mm")}-{startTimes[0].ToString("hh':'mm")}");

            }

            for (int i = 0; i < startTimes.Length - 1; i++)
            {
                TimeSpan current = startTimes[i].Add(new TimeSpan(0, durations[i], 0));
                TimeSpan next = startTimes[i + 1];
                if ((next - current).TotalMinutes >= consultationTime)
                {
                    result.Add($"{current.ToString("hh':'mm")}-{next.ToString("hh':'mm")}");


                }
            }

            //аналогичная проверка для конца интервала (после приема и между концом дня есть время)
            //но проверяем не просто эндТаймс, а эндТаймс + дуратион

            TimeSpan time = new TimeSpan(0, durations[(durations.Length - 1)], 0);
            if ((endWorkingTime - (startTimes[(startTimes.Length - 1)] + time)).TotalMinutes >= consultationTime)
            {
                result.Add($"{(startTimes[(startTimes.Length - 1)] + time).ToString("hh':'mm")}-{endWorkingTime.ToString("hh':'mm")}");

            }

            return result.ToArray();

        }
    }
}
