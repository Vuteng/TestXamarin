using System;

namespace TestXamarin
{
    public interface ITasks
    {
        string Description { get; set; }
        string Details { get; set; }
        DateTime DueDate { get; set; }
        int ID { get; set; }
    }
}