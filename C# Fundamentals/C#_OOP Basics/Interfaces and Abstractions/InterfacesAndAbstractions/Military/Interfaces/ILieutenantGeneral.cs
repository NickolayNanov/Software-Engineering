using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; set; }
    }
}
