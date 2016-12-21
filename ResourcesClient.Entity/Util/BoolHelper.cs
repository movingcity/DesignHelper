using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ResourcesClient.Entity.Util
{
    static class BoolHelper
    {
        public static T BoolFromValue<T>(string value)
        {
            Type boolType = typeof(T);

            // check if Type is Nullable
            bool isNullable = false;
            Type type = Nullable.GetUnderlyingType(boolType);
            if (type != null)
            {
                isNullable = true;
                boolType = type;
            }

            // check if boolType is bool
            if (boolType != typeof(bool))
            {
                throw new SerializationException("Invalid type in BoolFromValue: " + boolType);
            }

            // is null?
            if (value == null)
            {
                if (isNullable)
                {
                    //  since T is Nullable, will return null
                    return default(T);
                }
                else
                {
                    // error
                    throw new SerializationException("Invalid null in non-nullable boolean");
                }
            }

            return (T)Convert.ChangeType(value == "Y", typeof(bool));
        }

        public static string ValueFromBool<T>(T param)
        {
            Type boolType = typeof(T);
            bool boolValue;

            // check if Type is Nullable
            Type type = Nullable.GetUnderlyingType(boolType);
            if (type != null)
            {
                if (!GetNullableBool(boolType, param, out boolValue))
                {
                    // is Nullable and has no value
                    return null;
                }
                boolType = type;
            }
            else
            {
                // should be bool type
                try
                {
                    boolValue = (bool)Convert.ChangeType(param, typeof(bool));
                }
                catch (Exception e)
                {
                    throw new SerializationException("Invalid type passed to ValueFromBool: " + boolType, e);
                }
            }

            return boolValue ? "Y" : "N";
        }

        // extract the bool from passed Nullable<T> object
        // returns true if value was not null
        // returns false if value was null
        // throws exception if non nullable or if generic type is not bool
        private static bool GetNullableBool(Type nullableType, object param, out bool val)
        {
            val = false;
            try
            {
                if (param == null)
                {
                    return false;
                }
                val = (bool)nullableType.GetProperty("Value").GetValue(param, null);

                return true;
            }
            catch (Exception e)
            {
                throw new SerializationException("Invalid type found while extracting int from Nullable: " + param.GetType(), e);
            }
        }
    }
}
