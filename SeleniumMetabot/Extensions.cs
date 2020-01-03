﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumMetabot
{
    public static class Extensions
    {
        public static bool CaseInsensitiveContains(this string text, string value,
        StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }

        public static void DeleteOldFiles(string dirName, int days = 30)
        {
          Directory.GetFiles(dirName).Select(f => new FileInfo(f)).Where(f => f.LastAccessTime < DateTime.Now.AddDays(-days)).ToList().ForEach(f => f.Delete());
        }
    }
}
