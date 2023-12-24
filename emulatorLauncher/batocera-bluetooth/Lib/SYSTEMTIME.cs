﻿// 32feet.NET - Personal Area Networking for .NET
//
// InTheHand.Win32.SYSTEMTIME
// 
// Copyright (c) 2003-2020 In The Hand Ltd, All rights reserved.
// This source code is licensed under the MIT License

using System;
using System.Runtime.InteropServices;

namespace InTheHand.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SYSTEMTIME
    {
        private ushort year;
        private short month;
        private short dayOfWeek;
        private short day;
        private short hour;
        private short minute;
        private short second;
        private short millisecond;

        public static SYSTEMTIME FromByteArray(byte[] array, int offset)
        {
            SYSTEMTIME st = new SYSTEMTIME();
            st.year = BitConverter.ToUInt16(array, offset);
            st.month = BitConverter.ToInt16(array, offset+2);
            st.day = BitConverter.ToInt16(array, offset + 6);
            st.hour = BitConverter.ToInt16(array, offset + 8);
            st.minute = BitConverter.ToInt16(array, offset + 10);
            st.second = BitConverter.ToInt16(array, offset + 12);

            return st;
        }
        public static SYSTEMTIME FromDateTime(DateTime dt)
        {
            SYSTEMTIME st = new SYSTEMTIME();
            st.year = (ushort)dt.Year;
            st.month = (short)dt.Month;
            st.dayOfWeek = (short)dt.DayOfWeek;
            st.day = (short)dt.Day;
            st.hour = (short)dt.Hour;
            st.minute = (short)dt.Minute;
            st.second = (short)dt.Second;
            st.millisecond = (short)dt.Millisecond;

            return st;
        }

        public DateTime ToDateTime(DateTimeKind kind)
        {
            if (year == 0 && month == 0 && day == 0 && hour == 0 && minute == 0 && second == 0)
            {
                return DateTime.MinValue;
            }
            return new DateTime(year, month, day, hour, minute, second, millisecond, kind);
        }
    }
}