using com.unisys.rms.domain.resource;
using System.Collections.Generic;
using System;
using ResourcesClient.Entity.Util;

///<p>Entities related to application batch jobs</p>
namespace com.unisys.rms.domain.system.batch
{
    ///<p>Represents a scheduler job that save the results of various resource allocations within RMS as PDF files.</p>
    public partial class SavePDFJob : SchedulerJob
    {
        [NonSerialized]
        private List<ResourceType> types = null;

        [NonSerialized]
        private List<GanttArea> areas = null;

        /// <summary>
        /// Returns list of resource types - readonly
        /// </summary>
        public IList<ResourceType> ResourceTypes
        {
            get
            {
                if (types == null)
                {
                    types = InitializeTypes();
                }
                return types.AsReadOnly();
            }
        }

        /// <summary>
        /// Returns list of GanttArea - readonly
        /// </summary>
        public IList<GanttArea> AreasIncluded
        {
            get
            {
                if (areas == null)
                {
                    areas = InitializeAreas();
                }
                return areas.AsReadOnly();
            }
        }

        /// <summary>
        /// Add a new ResourceType to the ResourceTypes list
        /// </summary>
        /// <param name="type"></param>
        public void AddResourceType(ResourceType type)
        {
            if (types == null)
            {
                types = InitializeTypes();
            }

            string s = EnumHelper.ValueFromEnum(type);
            // check for duplicates
            if (resourceType.Contains(s))
            {
                return;
            }

            resourceType.Add(s);
            types.Add(type);
        }

        /// <summary>
        /// Remove a ResourceType from ResourceTypes list
        /// </summary>
        /// <param name="type"></param>
        public void RemoveResourceType(ResourceType type)
        {
            if (types == null)
            {
                types = InitializeTypes();
            }

            string s = EnumHelper.ValueFromEnum(type);
            // check for exist
            if (!resourceType.Contains(s))
            {
                return;
            }

            resourceType.Remove(s);
            types.Remove(type);
        }

        /// <summary>
        /// Clear the ResourceTypes list
        /// </summary>
        public void ClearResourceTypes()
        {
            if (types == null)
            {
                types = InitializeTypes();
            }

            resourceType.Clear();
            types.Clear();
        }

        /// <summary>
        /// Add a new GanttArea to the AreasIncluded list
        /// </summary>
        /// <param name="type"></param>
        public void AddGanttArea(GanttArea area)
        {
            if (areas == null)
            {
                areas = InitializeAreas();
            }

            string s = EnumHelper.ValueFromEnum(area);
            // check for duplicates
            if (areasIncluded.Contains(s))
            {
                return;
            }

            areasIncluded.Add(s);
            areas.Add(area);
        }

        /// <summary>
        /// Remove a GanttArea from AreasIncluded list
        /// </summary>
        /// <param name="type"></param>
        public void RemoveGanttArea(GanttArea area)
        {
            if (areas == null)
            {
                areas = InitializeAreas();
            }

            string s = EnumHelper.ValueFromEnum(area);
            // check for exist
            if (!areasIncluded.Contains(s))
            {
                return;
            }

            areasIncluded.Remove(s);
            areas.Remove(area);
        }

        /// <summary>
        /// Clear the AreasIncluded list
        /// </summary>
        public void ClearAreasIncluded()
        {
            if (areas == null)
            {
                areas = InitializeAreas();
            }

            areasIncluded.Clear();
            areas.Clear();
        }

        // create the types internal list
        private List<ResourceType> InitializeTypes()
        {
            List<ResourceType> list = new List<ResourceType>();

            if (resourceType == null)
            {
                resourceType = new List<string>();
            }

            foreach (string s in resourceType)
            {
                list.Add(EnumHelper.EnumFromValue<ResourceType>(s));
            }

            return list;
        }

        // create the areas internal list
        private List<GanttArea> InitializeAreas()
        {
            List<GanttArea> list = new List<GanttArea>();

            if (areasIncluded == null)
            {
                areasIncluded = new List<string>();
            }

            foreach (string s in areasIncluded)
            {
                list.Add(EnumHelper.EnumFromValue<GanttArea>(s));
            }

            return list;
        }
    }
}



