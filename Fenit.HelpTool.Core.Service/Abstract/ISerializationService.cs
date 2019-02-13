﻿using System.Collections.Generic;
using Fenit.HelpTool.Core.Service.Model.Shifter;

namespace Fenit.HelpTool.Core.Service.Abstract
{
    public interface ISerializationService
    {
        bool SaveShifterConfig(List<ShifterConfig> shifterConfig);
        List<ShifterConfig> LoadConfig();

    }
}