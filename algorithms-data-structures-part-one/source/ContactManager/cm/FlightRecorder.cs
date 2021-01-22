using System;
using System.Collections.Generic;
using ContactManager;
using DataStructures;

namespace cm
{
    public struct Record
    {
        public readonly DateTime When;
        public readonly LogLevel Level;
        public readonly string Message;

        public Record(LogMessageEventArgs e)
        {
            When = e.When;
            Level = e.Level;
            Message = e.Message;
        }
    }

    public class FlightRecorder
    {
        readonly Deque<Record> records = new Deque<Record>();
        readonly uint maxLength;

        public FlightRecorder(uint length = 100)
        {
            maxLength = length;
        }

        public IEnumerable<Record> Dump()
        {
            return records;
        }

        public void Record(object sender, LogMessageEventArgs e)
        {
            if(records.Count >= maxLength)
            {
                records.DequeueHead();
            }

            records.EnqueueTail(new Record(e));
        }
    }
}
