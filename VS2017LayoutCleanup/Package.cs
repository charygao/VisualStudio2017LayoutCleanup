using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VS2017LayoutCleanup
{
    internal class Package
    {

        /// <summary>
        /// 获取目录下所有包信息列表。
        /// </summary>
        /// <param name="layoutDirectory"></param>
        /// <returns></returns>
        internal List<PackageInfo> GetPackages(string layoutDirectory)
        {
            List<PackageInfo> list = new List<PackageInfo>();

            if (Directory.Exists(layoutDirectory))
            {
                string[] directories = Directory.GetDirectories(layoutDirectory);
                foreach (string dir in directories)
                {
                    PackageInfo pi = this.Parse(new DirectoryInfo(dir).Name);
                    if (pi != null)
                        list.Add(pi);
                }
            }

            return list;

        }

        /// <summary>
        /// 根据目录名称解析包信息。
        /// </summary>
        /// <param name="DirectoryName"></param>
        /// <returns></returns>
        PackageInfo Parse(string directoryName)
        {
            string[] listInfo = directoryName.Split(',');
            if (listInfo.Length > 1)
            {
                PackageInfo pi = new PackageInfo();
                pi.DirectoryName = directoryName;
                pi.Name = listInfo[0];

                if (listInfo[1].StartsWith("version="))
                {
                    pi.Version = Version.Parse(listInfo[1].Substring(8));
                }
                else
                {
                    throw new Exception("惨了，跟想的不一样……");
                }
                if (listInfo.Length > 2)
                {
                    pi.OtherInfo = new List<string>();
                    for (int i = 2; i < listInfo.Length; i++)
                    {
                        pi.OtherInfo.Add(listInfo[i]);
                    }
                }
                return pi;
            }

            return null;


        }


        /// <summary>
        /// 清理过时包
        /// </summary>
        /// <param name="packageDirectory"></param>
        /// <param name="allPackages"></param>
        /// <param name="moveTo"></param>
        /// <returns></returns>
        internal int Cleanup(string packageDirectory, List<PackageInfo> allPackages, string moveTo)
        {
            int moveCount = 0;
            var packageNames = (from v in allPackages select v.Name).Distinct().ToList();
            foreach (string packageName in packageNames)
            {
                List<PackageInfo> packages = allPackages.Where(p => p.Name == packageName).ToList();
                if (packages.Count > 1)
                {
                    List<PackageInfo> last = this.GetLast(packages);
                    foreach(PackageInfo pi in last)
                    {
                        packages.Remove(pi);
                    }
                    foreach (PackageInfo pi in packages)
                    {
                        moveCount++;
                        Directory.Move(packageDirectory + "\\" + pi.DirectoryName, moveTo + "\\" + pi.DirectoryName);
                    }

                }

            }

            return moveCount;
        }


        /// <summary>
        /// 获取最新的包列表
        /// </summary>
        /// <param name="packages"></param>
        /// <returns></returns>
        private List<PackageInfo> GetLast(List<PackageInfo> packages)
        {
            List<PackageInfo> last = new List<PackageInfo>();

            foreach (PackageInfo pi in packages)
            {
                bool find = false;
                for (int i = 0; i < last.Count; i++)
                {
                    if (this.IsSamePackage(pi, last[i]))
                    {
                        find = true;
                        if (pi.Version > last[i].Version)
                        {
                            last[i] = pi;
                        }
                        break;
                    }

                }
                if (!find)
                {
                    last.Add(pi);
                }
            }

            return last;
        }
        /// <summary>
        /// 判断是否为相同的包。
        /// </summary>
        /// <param name="one"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        private bool IsSamePackage(PackageInfo one, PackageInfo other)
        {
            if (one.Name == other.Name)
            {
                if (one.OtherInfo == null && other.OtherInfo == null)
                {
                    return true;
                }
                else if (one.OtherInfo != null && other.OtherInfo != null && one.OtherInfo.Count == other.OtherInfo.Count)
                {
                    if (string.Join(",", one.OtherInfo) == string.Join(",", other.OtherInfo))
                        return true;

                }
            }
            return false;
        }
    }
}
