// https://www.codewars.com/kata/5790bd38671cb57f7900012f

namespace EventAndDelegate;

using System.Collections.Generic;
using System;

public class PersonEventArgs : EventArgs
{
    public required string Name;

}

public class Publisher
{
    public event Action<object, PersonEventArgs> ContactNotify;

    public void CountMessages(List<string> peopleList)
    {
        Dictionary<string, int> messageCounts = [];
        foreach (string person in peopleList)
        {
            int count = messageCounts.ContainsKey(person)? ++messageCounts[person]: 1;
            messageCounts[person] = count;
            if (count % 3 == 0)
            {
                ContactNotify.Invoke(this, new PersonEventArgs{ Name = person });
            }            
        }
    }
}
