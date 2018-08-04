﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MogwaicoinMiner.Model.FileIO
{
    interface IFileIO
    {
        string FileName { get;  }
        string FolderName { get;  }
        Boolean Verify();
    }
}
