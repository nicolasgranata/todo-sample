using System;
using System.Collections.Generic;
using System.Text;

namespace TodoSample.ApplicationCore.Interfaces
{
    public interface IEntity
    {
        long Version { get; set; }
    }
}
