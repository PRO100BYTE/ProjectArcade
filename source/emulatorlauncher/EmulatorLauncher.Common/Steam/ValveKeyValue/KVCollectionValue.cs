﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ValveKeyValue
{
    class KVCollectionValue : KVValue, IEnumerable<KVObject>
    {
        public KVCollectionValue()
        {
            children = new List<KVObject>();
        }

        readonly List<KVObject> children;

        public override KVValueType ValueType { get { return KVValueType.Collection;}}

        public override KVValue this[string key]
        {
            get
            {
                Require.NotNull(key, "key");

                var ret = Get(key);
                if (ret != null)
                    return ret.Value;

                return null;
            }
        }

        public void Add(KVObject value)
        {
            Require.NotNull(value, "value");
            children.Add(value);
        }

        public void AddRange(IEnumerable<KVObject> values)
        {
            Require.NotNull(values, "values");
            children.AddRange(values);
        }

        public KVObject Get(string name)
        {
            Require.NotNull(name, "name");
            return children.FirstOrDefault(c => c.Name == name);
        }

        public void Set(string name, KVValue value)
        {
            Require.NotNull(name, "name");
            Require.NotNull(value, "value");

            children.RemoveAll(kv => kv.Name == name);
            children.Add(new KVObject(name, value));
        }

        #region IEnumerable<KVObject>

        public IEnumerator<KVObject> GetEnumerator() { return children.GetEnumerator(); }

        #endregion

        #region IConvertible

        public override TypeCode GetTypeCode()
        {
            throw new NotSupportedException();
        }

        public override bool ToBoolean(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override byte ToByte(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override char ToChar(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override double ToDouble(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override short ToInt16(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override int ToInt32(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override long ToInt64(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override float ToSingle(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override string ToString(IFormatProvider provider) { return ToString();}

        public override object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override uint ToUInt32(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        public override ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator() { return children.GetEnumerator(); }

        #endregion

        public override string ToString() { return "[Collection]"; }
    }
}
