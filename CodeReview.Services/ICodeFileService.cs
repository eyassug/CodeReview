﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview.Services
{
    public interface ICodeFileService
    {
        CodeFile Create(string filePath);
    }
}