﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Contracts
{
    public interface IBird : IAnimal
    {
        double WingSize { get; }
    }
}
