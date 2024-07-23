using bugtracker.Data;
using bugtracker.Models.Projects;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bugtracker.Models.CacheObjects
{
    public class CacheObjects
    {
        public static List<ProjectItemViewModel> GetProjectList(BugtrackerContext context, IMemoryCache cache)
        {
            List<ProjectItemViewModel> projectList;
            if (!cache.TryGetValue("ProjectList", out projectList))
            {
                projectList = context.Projects.OrderBy(p => p.Title).Select(p => new ProjectItemViewModel(p)).ToList();
                cache.Set("ProjectList", projectList, TimeSpan.FromMinutes(10));
            }
            return projectList;
        }
    }
}
