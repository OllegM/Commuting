using System;
using System.Collections.Generic;

namespace Transportation
{
  public class Sorter
  {
    public static void SortTickets(List<Ticket> tickets)
    {
      int counter = 0;
      if (tickets.Count <= 1)
      {
        return;
      }

      bool swapped = false;
      // Пузырьковый сортировщик для билетов
      do
      {
        swapped = false;
        counter ++;
        for (int i = 0; i < tickets.Count - 1; i++)
        {
          Ticket first = tickets[i];
          Ticket second = tickets[i + 1];
          if (false == String.Equals(first.ToStation, second.FromStation, StringComparison.InvariantCultureIgnoreCase))
          {
            tickets[i + 1] = first;
            tickets[i] = second;
            swapped = true;
          }
        }

        // Прерыватель цепи, если невозможно построить маршрут после 1000 циклов перестановки
        if (counter > 1000) {
          throw new Exception("Can't find connections.");
        }
      } while (swapped);
    }
  }
}