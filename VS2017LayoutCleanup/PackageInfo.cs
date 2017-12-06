using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2017LayoutCleanup
{

    /// <summary>
    /// 包信息类
    /// </summary>
    internal class PackageInfo
    {
        /// <summary>
        /// 所在目录名称
        /// </summary>
        internal string DirectoryName { get; set; }

        /// <summary>
        /// 包名称
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// 包版本号
        /// </summary>
        internal Version Version { get; set; }

        /// <summary>
        /// 其它包信息
        /// </summary>
        internal List<string> OtherInfo { get; set; }

    }
}
