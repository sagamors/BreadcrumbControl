using System.Collections.Generic;

namespace BreadcrumbControl.Helpers
{
    class PathHelper
    {
        public Breadcrumb Root { get; set; }

        public PathHelper(Breadcrumb root)
        {
            Root = root;
        }

        public List<string> GetAppropriatePaths(string partPath)
        {
            var result = new List<string>();
            foreach (var item in Root.Items)
            {
                var breadcrumbItem = item as BreadcrumbItem;
                if (breadcrumbItem != null)
                {
                    if (breadcrumbItem.FullPath.Contains(partPath))
                    {
                        result.Add(breadcrumbItem.FullPath);
                    }
                }
            }

            /*  var split = partPath.Split(new [] {Path.DirectorySeparatorChar},StringSplitOptions.RemoveEmptyEntries);
                  var result = new List<string>();
                  foreach (var part in split)
                  {
                      foreach (var item in Root.Items)
                      {
                          //todo fix
                          var breadcrumbItem = item as BreadcrumbItem;
                          if (item != null)
                          {
                              //todo fix no string
                              string header = (string)breadcrumbItem.Header;
                              //complex path
                              if (header == part)
                              {

                              }
                              if (header.Contains(part))
                              {
                                  result.Add(header);
                              }
                          }
                      }
                  }*/
                return result;
        }

/*        public string SearchPathInDepth(BreadcrumbItem root, string partPath)
        {
            var split = partPath.Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<string>();
            foreach (var part in split)
            {
                foreach (var item in Root.Items)
                {
                    //todo fix
                    var breadcrumbItem = item as BreadcrumbItem;
                    if (item == null) continue;
                    if (breadcrumbItem == null) continue;
                    // todo fix
                    string header = (string)breadcrumbItem.Header;
                    //complex path
                    if (header == part)
                    {

                    }
                    if (header.Contains(part))
                    {
                        result.Add(header);
                    }
                }
            }
            return result.Aggregate(string.Empty, (current, v) => current + (Path.DirectorySeparatorChar + v));
        }*/
    }
}
