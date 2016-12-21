using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.unisys.rms.domain.user;
using com.unisys.rms.domain.resource;
using com.unisys.rms.domain.criteria;
using com.unisys.rms.domain.flight;
using System.Runtime.Serialization;
using com.unisys.rms.domain.criteria.group;
using com.unisys.rms.domain.task;
using com.unisys.rms.domain.system;
using com.unisys.rms.domain.task.generate;
using com.unisys.rms.domain.template;
using com.unisys.rms.domain.system.batch;

namespace ResourcesClient.Entity.Util
{
    static class EnumHelper
    {
        // dictionary containing enum to string value mapping
        // IMP: should match the Java enum codes defined in rms-entity
        private static readonly Dictionary<Type, Dictionary<int, string>> dict =
            new Dictionary<Type, Dictionary<int, string>>()
            {
                { typeof(AccessRight), new Dictionary<int, string>()
                    {
                        { (int)AccessRight.Manage, "M" },
                        { (int)AccessRight.View, "V" }
                    }    
                },

                { typeof(ResourceType), new Dictionary<int, string>()
                    {
                        { (int)ResourceType.Carousel, "C" },
                        { (int)ResourceType.Counter, "D" },
                        { (int)ResourceType.Gate, "G" },
                        { (int)ResourceType.Stand, "S" }
                    }    
                },

                { typeof(ClauseOperator), new Dictionary<int, string>()
                    {
                        { (int)ClauseOperator.AND, "A" },
                        { (int)ClauseOperator.OR, "O" }
                    }    
                },

                { typeof(FlightIndicatorType), new Dictionary<int, string>()
                    {
                        { (int)FlightIndicatorType.Domestic, "D" },
                        { (int)FlightIndicatorType.International, "I" },
                        { (int)FlightIndicatorType.Mixed, "M" },
                        { (int)FlightIndicatorType.Regional, "R" },
                        { (int)FlightIndicatorType.Schengen, "S" }
                    }    
                },

                { typeof(GateType), new Dictionary<int, string>()
                    {
                        { (int)GateType.Bus, "B" },
                        { (int)GateType.Contact, "C" }
                    }    
                },

                { typeof(GroupType), new Dictionary<int, string>()
                    {
                        { (int)GroupType.AircraftType, "A" },
                        { (int)GroupType.Airline, "L" },
                        { (int)GroupType.Airport, "P" },
                        { (int)GroupType.Flight, "F" },
                        { (int)GroupType.FlightCategory, "G" },
                        { (int)GroupType.FlightServiceType, "T" },
                        { (int)GroupType.Gate, "E" },
                        { (int)GroupType.Group, "R" },
                        { (int)GroupType.HandlingAgent, "H" },
                        { (int)GroupType.Miscellaneous, "M" },
                        { (int)GroupType.Registration, "O" },
                        { (int)GroupType.Stand, "S" },
                        { (int)GroupType.Terminal, "I" },
                        { (int)GroupType.DayOfWeek, "W" },
                        { (int)GroupType.Carousel, "C" },
                        { (int)GroupType.Counter, "D" }
                    }    
                },

                { typeof(IndicatorType), new Dictionary<int, string>()
                    {
                        { (int)IndicatorType.Domestic, "D" },
                        { (int)IndicatorType.International, "I" },
                        { (int)IndicatorType.Both, "B" }
                    }    
                },

                { typeof(LocationType), new Dictionary<int, string>()
                    {
                        { (int)LocationType.East, "E" },
                        { (int)LocationType.North, "N" },
                        { (int)LocationType.South, "S" },
                        { (int)LocationType.West, "W" }
                    }    
                },

                { typeof(MovementType), new Dictionary<int, string>()
                    {
                        { (int)MovementType.Arrival, "A" },
                        { (int)MovementType.Departure, "D" }
                    }    
                },

                { typeof(NonFlightTaskType), new Dictionary<int, string>()
                    {
                        { (int)NonFlightTaskType.Complete, "C" },
                        { (int)NonFlightTaskType.Partial, "P" }
                    }    
                },

                { typeof(ParameterDataType), new Dictionary<int, string>()
                    {
                        { (int)ParameterDataType.Date, "D" },
                        { (int)ParameterDataType.Numeric, "N" },
                        { (int)ParameterDataType.Other, "O" },
                        { (int)ParameterDataType.String, "S" },
                        { (int)ParameterDataType.Boolean, "B" }
                    }    
                },

                { typeof(PreferenceType), new Dictionary<int, string>()
                    {
                        { (int)PreferenceType.Benefit, "B" },
                        { (int)PreferenceType.Cost, "C" }
                    }    
                },

                { typeof(RuleType), new Dictionary<int, string>()
                    {
                        { (int)RuleType.Mandatory, "M" },
                        { (int)RuleType.Preference, "P" }
                    }    
                },

                { typeof(StandTaskType), new Dictionary<int, string>()
                    {
                        { (int)StandTaskType.Arrival, "A" },
                        { (int)StandTaskType.Both, "B" },
                        { (int)StandTaskType.Departure, "D" },
                        { (int)StandTaskType.LongStay, "L" },
                        { (int)StandTaskType.Tow, "T" }
                    }    
                },

                { typeof(StandType), new Dictionary<int, string>()
                    {
                        { (int)StandType.Apron, "A" },
                        { (int)StandType.Contact, "C" },
                        { (int)StandType.Remote, "R" }
                    }    
                },

                { typeof(GenerateListType), new Dictionary<int, string>()
                    {
                        { (int)GenerateListType.AbsoluteTime, "A" },
                        { (int)GenerateListType.FlightTime, "F" }
                    }    
                },

                { typeof(ConfirmType), new Dictionary<int, string>()
                    {
                        { (int)ConfirmType.Confirm, "C" },
                        { (int)ConfirmType.SendUnconfirmMessage, "M" },
                        { (int)ConfirmType.Unconfirm, "U" }
                    }    
                },

                { typeof(TemplateAccessType), new Dictionary<int, string>()
                    {
                        { (int)TemplateAccessType.Both, "B" },
                        { (int)TemplateAccessType.East, "E" },
                        { (int)TemplateAccessType.West, "W" }
                    }    
                },

                { typeof(DataCaptureType), new Dictionary<int, string>()
                    {
                        { (int)DataCaptureType.AfterImage, "A" },
                        { (int)DataCaptureType.BeforeAfterImage, "X" },
                        { (int)DataCaptureType.BeforeImage, "B" },
                        { (int)DataCaptureType.None, "N" }
                    }    
                },

                { typeof(ModuleName), new Dictionary<int, string>()
                    {
                        { (int)ModuleName.Carousel, "C" },
                        { (int)ModuleName.Counter, "D" },
                        { (int)ModuleName.Gate, "G" },
                        { (int)ModuleName.Interface, "I" },
                        { (int)ModuleName.Internal, "N" },
                        { (int)ModuleName.Job, "J" },
                        { (int)ModuleName.Other, "O" },
                        { (int)ModuleName.Stand, "S" }
                    }    
                },

                { typeof(ParameterModule), new Dictionary<int, string>()
                    {
                        { (int)ParameterModule.Admin, "A" },
                        { (int)ParameterModule.All, "X" },
                        { (int)ParameterModule.Carousel, "C" },
                        { (int)ParameterModule.Counter, "D" },
                        { (int)ParameterModule.Gate, "G" },
                        { (int)ParameterModule.Stand, "S" }
                    }    
                },

                { typeof(ParameterType), new Dictionary<int, string>()
                    {
                        { (int)ParameterType.Application, "A" },
                        { (int)ParameterType.User, "U" }
                    }    
                },

                { typeof(FlightDataSource), new Dictionary<int, string>()
                    {
                        { (int)FlightDataSource.Current, "C" },
                        { (int)FlightDataSource.Future, "F" }
                    }    
                },

                { typeof(GanttArea), new Dictionary<int, string>()
                    {
                        { (int)GanttArea.Allocated, "A" },
                        { (int)GanttArea.TempAcChange, "T" },
                        { (int)GanttArea.Unallocated, "U" }
                    }    
                },

                { typeof(JobStatus), new Dictionary<int, string>()
                    {
                        { (int)JobStatus.Completed, "C" },
                        { (int)JobStatus.InProgress, "I" },
                        { (int)JobStatus.Scheduled, "S" }
                    }    
                }
            };

        private static Dictionary<int, string> GetInnerMap(Type enumType)
        {
            // get inner dictionary
            Dictionary<int, string> map = null;
            if (!dict.TryGetValue(enumType, out map) || map == null)
            {
                throw new SerializationException("Invalid enum type: " + enumType);
            }
            return map;
        }
        
        public static T EnumFromValue<T>(string stringValue)
        {
            Type enumType = typeof(T);

            // check if Type is Nullable
            bool isNullable = false;
            Type type = Nullable.GetUnderlyingType(enumType);
            if (type != null)
            {
                isNullable = true;
                enumType = type;
            }

            // is null?
            if (stringValue == null)
            {
                if (isNullable)
                {
                    //  since T is Nullable, will return null
                    return default(T);
                }
                else
                {
                    // error
                    throw new SerializationException("Invalid null in non-nullable enum");
                }
            }

            // get inner dictionary
            Dictionary<int, string> map = GetInnerMap(enumType);
            foreach (int key in map.Keys)
            {
                if (map[key] == stringValue)
                {
                    try
                    {
                        return (T)Enum.ToObject(enumType, key);
                    }
                    catch (Exception e)
                    {
                        // cannot convert from int to passed type T
                        // programming error
                        throw new SerializationException("Cannot convert value: " + stringValue + " for enum type: " + enumType, e);
                    }
                }
            }
            // could not find existing enum
            throw new SerializationException("Invalid value: " + stringValue + " for enum type: " + enumType);
        }

        public static string ValueFromEnum<T>(T param)
        {
            Type enumType = typeof(T);
            int enumValue;

            // check if Type is Nullable
            Type type = Nullable.GetUnderlyingType(enumType);
            if (type != null)
            {
                if (!GetNullableInt(enumType, param, out enumValue))
                {
                    // is Nullable and has no value
                    return null;
                }
                enumType = type;
            }
            else
            {
                // should be enum type
                try
                {
                    enumValue = (int)Convert.ChangeType(param, typeof(int));
                }
                catch (Exception e)
                {
                    throw new SerializationException("Invalid type passed to ValueFromEnum: " + enumType, e);
                }
            }

            // get inner dictionary
            Dictionary<int, string> map = GetInnerMap(enumType);
            string value = null;
            if (!map.TryGetValue(enumValue, out value) || value == null)
            {
                throw new SerializationException("Invalid value: " + enumValue + " for enum type: " + enumType);
            }
            return value;
        }

        // extract the enum int from passed Nullable<T> object
        // returns true if value was not null
        // returns false if value was null
        // throws exception if non nullable or if generic type is not Enum
        private static bool GetNullableInt(Type nullableType, object param, out int val)
        {
            val = 0;
            try
            {
                if (param == null)
                {
                    return false;
                }
                val = (int)nullableType.GetProperty("Value").GetValue(param, null);

                return true;
            }
            catch (Exception e)
            {
                throw new SerializationException("Invalid type found while extracting int from Nullable: "+param.GetType(), e);
            }
        }
    }
}
